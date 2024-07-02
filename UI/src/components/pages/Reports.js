import React, { useState } from 'react';
import axios from 'axios';
import Nav from "../Nav";

const Reports = () => {
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [receiverName, setReceiverName] = useState('');
    const [receiverCountry, setReceiverCountry] = useState('');
    const [status, setStatus] = useState('');
    const [reportData, setReportData] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    const handleGenerateReport = async () => {
        setLoading(true);
        setError('');

        const criteria = {
            startDate: startDate,
            endDate: endDate,
            receiverName: receiverName,
            receiverCountry: receiverCountry,
            status: status,
        };

        console.log('Sending criteria:', criteria); 

        try {
            const response = await axios.post('https://localhost:7270/api/reports/generate', criteria);
            console.log('Response:', response.data);  
            setReportData(response.data); 
        } catch (error) {
            console.error('Error generating report:', error);
            if (error.response) {
                setError(error.response.data.message);
            } else {
                setError('An error occurred. Please try again.'); 
            }
        } finally {
            setLoading(false);
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
            <button onClick={handleGenerateReport} disabled={loading}>Generate Report</button>

            {/* Loading Indicator */}
            {loading && <p>Loading...</p>}

            {/* Error Message */}
            {error && <p className="error-message">{error}</p>}

            {/* Display the fetched report data */}
            {reportData && reportData.length > 0 && (
                <div>
                    <h2>Generated Report Data:</h2>
                    <ul>
                        {reportData.map((item, index) => (
                            <li key={index}>
                                Order ID: {item.orderID}, Receiver Name: {item.receiverName}, Status: {item.orderStatus}
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default Reports;
