import React, { useEffect, useState } from "react";
import axios from "axios";
import Nav from "../Nav";

const Financat = () => {
    const [payments, setPayments] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get('https://localhost:7270/Payments/get-all');
            console.log(response);
            setPayments(response.data);
            setLoading(false);
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <>
            <div>
                <Nav />
                <h2 style={{ textAlign: 'center' }}>Financat</h2>
                <p>Këtu mund ti shihni të gjithë pagesat.</p>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Amount</th>
                                <th>Invoice ID</th>
                                <th>Payment Method ID</th>
                                <th>Paid</th>
                            </tr>
                        </thead>
                        <tbody>
                            {payments.map((payment) => (
                                <tr key={payment.paymentsID}>
                                    <td>{payment.paymentsID}</td>
                                    <td>{payment.amount}</td>
                                    <td>{payment.invoiceID}</td>
                                    <td>{payment.paymentMethodsID}</td>
                                    <td>{payment.payed.toString()}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>          
            </div>
        </>
    );
}

export default Financat;