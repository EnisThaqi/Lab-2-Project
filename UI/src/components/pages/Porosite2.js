import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Porosite2 = () => {
    const [orders, setOrders] = useState([]);
    const [error, setError] = useState('');
    const [subjectId, setSubjectId] = useState('');

    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const storedSubjectId = localStorage.getItem('subjectId');
                setSubjectId(storedSubjectId);

                const response = await axios.get(`https://localhost:7270/orders/subject`, {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('token')}`
                    }
                });
                setOrders(response.data);
            } catch (error) {
                if (error.response) {
                    setError(error.response.data);
                } else {
                    setError('An error occurred. Please try again.');
                }
            }
        };

        fetchOrders();
    }, []);

    return (
        <div>
            <h1>Orders</h1>
            {error && <div className="error-message">{error} (Subject ID: {subjectId})</div>}
            {orders.length === 0 && <p>No orders found. (Subject ID: {subjectId})</p>}
            <ul>
                {orders.map(order => (
                    <li key={order.OrderID}>
                        {order.Receiver_Name} - {order.Quantity}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Porosite2;
