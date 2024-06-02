// Sidebar.js
import React from 'react';
import './style.css';
import { NavLink } from 'react-router-dom';

function BusinessSidebar({children}) {
    return (
        <div style={{
            display:'flex'
        }}>
            <div className='p-1'>
                <div className='brand'>
                    <i className='bi bi-truck me-2'></i>
                    <span>Postify</span>
                </div>
                <hr />
                <div className='menu'>
                    <NavLink to="/Porosite2" exact className='menu-item' activeClassName='active'>
                        <i className='bi bi-bag me-2'></i>
                        <span>Porosite</span>
                    </NavLink>
                    <NavLink to="/KrijoPorosite" className='menu-item' activeClassName='active'>
                        <i className='bi bi-bag-plus-fill me-2'></i>
                        <span>Krijo Porosite</span>
                    </NavLink>
                    <NavLink to="/Pagesat" className='menu-item' activeClassName='active'>
                        <i className='bi bi-credit-card me-2'></i>
                        <span>Pagesat</span>
                    </NavLink>
                </div>
            </div>
            <div style={{
                background:'#f0f0f0',
                height:'100vh',
                flex:1
            }} className='ps-1'>
                {children}
            </div>
        </div>
    );
}
export default BusinessSidebar;