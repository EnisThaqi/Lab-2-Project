import React, { useState } from "react";
import axios from "axios";
import "./NoAccount.css";

const NoAccount = () => {
    const [trackingId, setTrackingId] = useState("");
    const [trackingInfo, setTrackingInfo] = useState(null);
    const [error, setError] = useState(null);

    const handleInputChange = (e) => {
        setTrackingId(e.target.value);
    };

    const handleTrackOrder = async () => {
        try {
            const response = await axios.get(`https://localhost:7270/Tracking/Read/${trackingId}`);
            console.log(response.data); // Log the response data
            setTrackingInfo(response.data);
            setError(null);
        } catch (error) {
            setTrackingInfo(null);
            setError("Tracking ID not found. Please check and try again.");
        }
    };

    return (
        <div className="no-account-container">
            <h1>Ndjekni Porosine</h1>
            <div className="tracking-form">
                <input
                    type="text"
                    placeholder="Vendosni Tracking ID"
                    value={trackingId}
                    onChange={handleInputChange}
                    className="tracking-input"
                />
                <button onClick={handleTrackOrder} className="tracking-button">
                    Ndjeke
                </button>
            </div>
            {error && <p className="error-message">{error}</p>}
            {trackingInfo && (
                <div className="tracking-info">
                    <h2>Informacioni i Porosise se ndjekur</h2>
                    <p><strong>Status:</strong> {trackingInfo.status || 'N/A'}</p>
                    <p><strong>Location:</strong> {trackingInfo.location || 'N/A'}</p>
                    <p><strong>Last Updated:</strong> {trackingInfo.updatedAt ? new Date(trackingInfo.updatedAt).toLocaleString() : 'N/A'}</p>
                    <p><strong>Order ID:</strong> {trackingInfo.orderID || 'N/A'}</p>
                </div>
            )}
            <div className="truck-icon">
                <i className="bi bi-truck"></i>
            </div>
        </div>
    );
};

export default NoAccount;
