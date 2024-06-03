import React, { useEffect, useState } from "react";
import Nav from "./Nav";
import 'chart.js/auto';
import { Pie } from 'react-chartjs-2';

const Home = ({ Toggle }) => {
    const [chartData, setChartData] = useState(null);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7270/Subjects/get-all');
            const data = await response.json();

            const counts = {};
            data.forEach(subject => {
                counts[subject.subject_TypeID] = (counts[subject.subject_TypeID] || 0) + 1;
            });

            const processedData = {
                labels: Object.keys(counts),
                datasets: [
                    {
                        label: 'Subject Types',
                        data: Object.values(counts),
                        backgroundColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            // shto sipas nevojes
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            // shto sipas nevojes
                        ],
                        borderWidth: 1,
                    },
                ],
            };

            setChartData(processedData);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const options = {
        plugins: {
            title: {
                display: false 
            }
        }
    };

    return (
    <div className='px-3'>
        <Nav Toggle={Toggle} />
        <h3>Ballina</h3>
        <h2 style={{ textAlign: 'center' }}>Klientet</h2>
        <div style={{ width: '80%', margin: '0 auto', textAlign: 'center' }}>
            <div style={{ width: '100%', maxWidth: '500px', margin: '0 auto' }}>
                {chartData && chartData.labels && <Pie data={chartData} options={options} />}
            </div>
        </div>
    </div>
);
};

export default Home;
