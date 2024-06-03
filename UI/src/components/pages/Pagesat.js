import React, { useState, useEffect } from 'react';
import axios from 'axios';

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
                setInvoices(response.data);
            } catch (error) {
                if (error.response) {
                    setError(error.response.data);
                } else {
                    setError('An error occurred. Please try again.');
                }
            }
        };

        fetchInvoices();
    }, []);

    return (
        <>
            <div>
                <h2 style={{ textAlign: 'center' }}>Faturat</h2>
                <p>Këtu mund ti shihni të gjitha faturat.</p>
                {error && <div className="error-message">{error} (Subject ID: {subjectId})</div>}
                {invoices.length === 0 && <p>No invoices found. (Subject ID: {subjectId})</p>}
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
