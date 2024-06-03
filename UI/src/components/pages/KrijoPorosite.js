import React, { useState } from 'react';
import axios from 'axios';
import './KrijoPorosite.css'; 

const KrijoPorosite = () => {
    const [Orders, setOrders] = useState({
        quantity: '',
        receiver_Name: '',
        weight: '',
        receiver_Country: '',
        receiver_Phone: '',
        receiver_address: '',
        description: '',
        additional_Information: '',
        reference_code: '',
        statusId: 1,
        packageSizeId: 1,
        can_open: false,
        is_take_back: false,
        subjectID: localStorage.getItem('subjectId')
    });
    const [error, setError] = useState('');

    const handleChange = (e) => {
        const { name, value } = e.target;
        setOrders({ ...Orders, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const subjectIdTemp = localStorage.getItem('subjectId');
            console.log(subjectIdTemp);

            const response = await axios.post('https://localhost:7270/orders/create', {
                ...Orders,
                statusId: 1,
                packageSizeId: 1,
                subjectID: subjectIdTemp
            });
            console.log('Porosia u shtua:', response.data);

            setError('');
            alert('Order created successfully!');
        } catch (error) {
            if (error.response) {
                const errorMessage = error.response.data.title || 'An error occurred. Please try again.';
                setError(errorMessage);
            } else {
                setError('An error occurred. Please try again.');
            }
        }
    };

    return (
        <div className="krijo-porosite-container">
            <h2>Forma për krijimin e Porosive</h2>
            <form onSubmit={handleSubmit} className="order-form">
                <div className="form-group">
                    <label>Quantity:</label>
                    <input
                        type="number"
                        name="quantity"
                        value={Orders.quantity}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Receiver Name:</label>
                    <input
                        type="text"
                        name="receiver_Name"
                        value={Orders.receiver_Name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Weight:</label>
                    <input
                        type="number"
                        name="weight"
                        value={Orders.weight}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Receiver Country:</label>
                    <input
                        type="text"
                        name="receiver_Country"
                        value={Orders.receiver_Country}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Receiver Phone:</label>
                    <input
                        type="text"
                        name="receiver_Phone"
                        value={Orders.receiver_Phone}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Receiver Address:</label>
                    <input
                        type="text"
                        name="receiver_address"
                        value={Orders.receiver_address}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Description:</label>
                    <textarea
                        name="description"
                        value={Orders.description}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Additional Information:</label>
                    <textarea
                        name="additional_Information"
                        value={Orders.additional_Information}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Reference Code:</label>
                    <input
                        type="text"
                        name="reference_code"
                        value={Orders.reference_code}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit">Krijo Porosin</button>
            </form>
            {error && <div className="error-message">{error}</div>}
        </div>
    );
};

export default KrijoPorosite;
