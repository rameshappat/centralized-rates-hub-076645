import React, { useEffect, useState } from 'react';
import axios from 'axios';

const RateManagement = () => {
    const [rates, setRates] = useState([]);

    useEffect(() => {
        const fetchRates = async () => {
            const response = await axios.get('/api/rate');
            setRates(response.data);
        };
        fetchRates();
    }, []);

    return (
        <div>
            <h1>Rate Management</h1>
            <ul>
                {rates.map(rate => (<li key={rate.id}>{rate.name}: {rate.value}</li>))}
            </ul>
        </div>
    );
};

export default RateManagement;
