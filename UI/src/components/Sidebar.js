// Sidebar.js
import React from 'react';
import './style.css';

function Sidebar() {
    return (
        <div className='sidebar'>
            <div className='brand'>
                <i className='bi bi-truck me-2'></i>
                <span>Postify</span>
            </div>
            <hr />
            <div className='menu'>
                <a href='#' className='menu-item active'>
                    <i className='bi bi-speedometer2 me-2'></i>
                    <span>Dashboard</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-house me-2'></i>
                    <span>Home</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-table me-2'></i>
                    <span>Products</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-clipboard-data me-2'></i>
                    <span>Report</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-people me-2'></i>
                    <span>Customers</span>
                </a>
                <a href='#' className='menu-item logout'>
                    <i className='bi bi-power me-2'></i>
                    <span>Logout</span>
                </a>
            </div>
        </div>
    );
}

export default Sidebar;
