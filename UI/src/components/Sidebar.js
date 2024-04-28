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
                    <i className='bi bi-house me-2'></i>
                    <span>Ballina</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-people me-2'></i>
                    <span>Klientet</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-person-add me-2'></i>
                    <span>Regjistro Klient</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-people me-2'></i>
                    <span>Perdoruesit</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-person-add me-2'></i>
                    <span>Regjistro Perdoruesit</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-person-add me-2'></i>
                    <span>Logjistika</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-bank me-2'></i>
                    <span>Financat</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-graph-up me-2'></i>
                    <span>Analitika</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-bag-check me-2'></i>
                    <span>Porosite</span>
                </a>
                <a href='#' className='menu-item'>
                    <i className='bi bi-bell me-2'></i>
                    <span>Notifications</span>
                </a>
            </div>
        </div>
    );
}

export default Sidebar;
