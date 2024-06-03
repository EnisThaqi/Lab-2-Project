import React, { useState, useEffect } from 'react';
import axios from 'axios';
import * as XLSX from 'xlsx';

const Pagesat = () => {
    const [invoices, setInvoices] = useState([]);
    const [error, setError] = useState('');
    const [subjectId, setSubjectId] = useState('');

    useEffect(() => {
        const fetchInvoices = async () => {
            try {
                const storedSubjectId = localStorage.getItem('subjectId');
                setSubjectId(storedSubjectId);

                const response = await axios.get('https://localhost:7270/Invoice/invoce', {
                    params: {
                        subjectId: storedSubjectId
                    }
                });
                console.log('Fetched Invoices:', response.data); // Debugging
                setInvoices(response.data);
            } catch (error) {
                console.error('Error fetching invoices:', error); // Debugging
                if (error.response) {
                    setError(error.response.data);
                } else {
                    setError('An error occurred. Please try again.');
                }
            }
        };

        fetchInvoices();
    }, []);

    const exportToExcel = () => {
        if (invoices.length === 0) {
            setError('No invoices to export');
            return;
        }

        const worksheet = XLSX.utils.json_to_sheet(invoices);
        const workbook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workbook, worksheet, 'Invoices');
        XLSX.writeFile(workbook, 'invoices.xlsx');
    };

    return (
        <>
            <div>
                <h2 style={{ textAlign: 'center' }}>Faturat</h2>
                <p>Këtu mund ti shihni të gjitha faturat.</p>
                {error && <div className="error-message">{error} (Subject ID: {subjectId})</div>}
                {invoices.length === 0 && <p>No invoices found. (Subject ID: {subjectId})</p>}
                <button onClick={exportToExcel} style={{ marginBottom: '10px' }}>Export to Excel</button>
                <table className="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Data e lëshimit</th>
                            <th>Statusi</th>
                            <th>Krijuar nga</th>
                            <th>Data</th>
                            <th>Data nga</th>
                            <th>Data deri</th>
                        </tr>
                    </thead>
                    <tbody>
                        {Array.isArray(invoices) && invoices.length > 0 ? (
                            invoices.map((invoice) => (
                                <tr key={invoice.invoiceID}>
                                    <td>{invoice.invoiceID}</td>
                                    <td>{new Date(invoice.issued_Date).toLocaleString()}</td>
                                    <td>{invoice.status}</td>
                                    <td>{invoice.createdBy}</td>
                                    <td>{new Date(invoice.date).toLocaleString()}</td>
                                    <td>{new Date(invoice.dateFrom).toLocaleString()}</td>
                                    <td>{new Date(invoice.dateTo).toLocaleString()}</td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="7">No invoices were found.</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default Pagesat;
