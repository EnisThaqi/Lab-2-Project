import React, { useState } from 'react';
import axios from 'axios';
import Nav from "../Nav";
import "./Reports.css";

const Reports = () => {
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [receiverName, setReceiverName] = useState('');
    const [receiverCountry, setReceiverCountry] = useState('');
    const [status, setStatus] = useState('');

    const handleGenerateReport = async () => {
        const criteria = {
            startDate,
            endDate,
            receiverName,
            receiverCountry,
            status,
        };

        try {
            const response = await axios.post('/api/reports/generate', criteria);
            // Handle the response, e.g., display the report
            console.log(response.data);
        } catch (error) {
            console.error('Error generating report:', error);
        }
    };

    return (
        <div className="container">
            <h1>Generate Report</h1>
            <div className="input-group">
                <label>Start Date:</label>
                <input type="date" value={startDate} onChange={(e) => setStartDate(e.target.value)} />
            </div>
            <div className="input-group">
                <label>End Date:</label>
                <input type="date" value={endDate} onChange={(e) => setEndDate(e.target.value)} />
            </div>
            <div className="input-group">
                <label>Receiver Name:</label>
                <input type="text" value={receiverName} onChange={(e) => setReceiverName(e.target.value)} />
            </div>
            <div className="input-group">
                <label>Receiver Country:</label>
                <input type="text" value={receiverCountry} onChange={(e) => setReceiverCountry(e.target.value)} />
            </div>
            <div className="input-group">
                <label>Status:</label>
                <input type="text" value={status} onChange={(e) => setStatus(e.target.value)} />
            </div>
            <button onClick={handleGenerateReport}>Generate Report</button>
        </div>
    );
};

export default Reports;
