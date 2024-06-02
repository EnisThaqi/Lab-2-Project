// Analitika.js
import React, { useEffect, useState } from "react";
import axios from "axios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUsers, faClipboardList, faMoneyBill } from "@fortawesome/free-solid-svg-icons";
import { Bar } from "react-chartjs-2";
import 'chart.js/auto';
import CountUp from "react-countup";
import Klientet from "./Klientet";
import Porosite from "./Porosite";
import Financat from "./Financat";

const Analitika = () => {
    const [clientsCount, setClientsCount] = useState(0);
    const [ordersCount, setOrdersCount] = useState(0);
    const [paymentsCount, setPaymentsCount] = useState(0);

    useEffect(() => {
        fetchClientsCount();
        fetchOrdersCount();
        fetchPaymentsCount();
    }, []);

    const fetchClientsCount = async () => {
        try {
            const response = await axios.get('https://localhost:7270/Subjects/get-all');
            setClientsCount(response.data.length);
        } catch (error) {
            console.error(error);
        }
    }

    const fetchOrdersCount = async () => {
        try {
            const response = await axios.get('https://localhost:7270/Orders/get-all');
            setOrdersCount(response.data.length);
        } catch (error) {
            console.error(error);
        }
    }

    const fetchPaymentsCount = async () => {
        try {
            const response = await axios.get('https://localhost:7270/Payments/get-all');
            setPaymentsCount(response.data.length);
        } catch (error) {
            console.error(error);
        }
    }

    const data = {
        labels: ['Clients', 'Orders', 'Payments'],
        datasets: [
            {
                label: 'Count',
                data: [clientsCount, ordersCount, paymentsCount],
                backgroundColor: ['#4caf50', '#ff9800', '#f44336'],
                borderColor: ['#388e3c', '#f57c00', '#d32f2f'],
                borderWidth: 1,
            },
        ],
    };

    const options = {
        indexAxis: 'y',
        scales: {
            x: {
                beginAtZero: true,
            },
        },
        responsive: true,
        maintainAspectRatio: false,
    };

    return (
        <>
            <div style={{ textAlign: 'center' }}>
                <h1>Analitika</h1>
                <div style={{ height: '400px', width: '80%', margin: '0 auto' }}>
                    <Bar data={data} options={options} />
                </div>
                <div style={{ display: 'flex', justifyContent: 'space-around', marginTop: '20px' }}>
                    <div className="analytics-card">
                        <FontAwesomeIcon icon={faUsers} className="icon" />
                        <h2>Klientët</h2>
                        <p>Total Clients:</p>
                        <CountUp end={clientsCount} duration={2} />
                    </div>
                    <div className="analytics-card">
                        <FontAwesomeIcon icon={faClipboardList} className="icon" />
                        <h2>Porositë</h2>
                        <p>Total Orders:</p>
                        <CountUp end={ordersCount} duration={2} />
                    </div>
                    <div className="analytics-card">
                        <FontAwesomeIcon icon={faMoneyBill} className="icon" />
                        <h2>Financat</h2>
                        <p>Total Payments:</p>
                        <CountUp end={paymentsCount} duration={2} />
                    </div>
                </div>
            </div>
        </>
    );
}

export default Analitika;
