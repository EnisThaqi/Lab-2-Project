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
                    params: {
                        subjectId: storedSubjectId
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
        <>
            <div>
                <h2 style={{ textAlign: 'center' }}>Porositë</h2>
                <p>Këtu mund ti shihni të gjitha porositë.</p>
                {error && <div className="error-message">{error} (Subject ID: {subjectId})</div>}
                {orders.length === 0 && <p>No orders found. (Subject ID: {subjectId})</p>}
                <table className="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Sasia</th>
                            <th>Pranuesi</th>
                            <th>Pesha</th>
                            <th>Shteti</th>
                            <th>Nr i pranuesit</th>
                            <th>Adresa</th>
                            <th>Pershkrimi</th>
                            <th>Infot</th>
                            <th>Kodi</th>
                            <th>Hapet</th>
                            <th>Kthehet</th>
                            <th>Madhesia</th>
                            <th>Statusi</th>
                        </tr>
                    </thead>
                    <tbody>
                        {Array.isArray(orders) && orders.length > 0 ? (
                            orders.map((order) => (
                                <tr key={order.orderID}>
                                    <td>{order.orderID}</td>
                                    <td>{order.quantity}</td>
                                    <td>{order.receiver_Name}</td>
                                    <td>{order.weight}</td>
                                    <td>{order.receiver_Country}</td>
                                    <td>{order.receiver_Phone}</td>
                                    <td>{order.receiver_address}</td>
                                    <td>{order.description}</td>
                                    <td>{order.additional_Information}</td>
                                    <td>{order.reference_code}</td>
                                    <td>{order.can_open}</td>
                                    <td>{order.is_take_back}</td>
                                    <td>{order.packageSizeId}</td>
                                    <td>{order.statusId}</td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="14">No orders were found.</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default Porosite2;
