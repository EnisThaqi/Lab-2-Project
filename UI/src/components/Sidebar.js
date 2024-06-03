import React from 'react';
import './style.css';
import { NavLink } from 'react-router-dom';

function Sidebar({children}) {
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
                    <NavLink to="/" exact className='menu-item' activeClassName='active'>
                        <i className='bi bi-house me-2'></i>
                        <span>Ballina</span>
                    </NavLink>
                    <NavLink to="/Klientet" className='menu-item' activeClassName='active'>
                        <i className='bi bi-people me-2'></i>
                        <span>Klientet</span>
                    </NavLink>
                    <NavLink to="/Regjistro-klientet" className='menu-item' activeClassName='active'>
                        <i className='bi bi-person-add me-2'></i>
                        <span>Regjistro Klient</span>
                    </NavLink>
                    <NavLink to="/Perdoruesit" className='menu-item' activeClassName='active'>
                        <i className='bi bi-people me-2'></i>
                        <span>Perdoruesit</span>
                    </NavLink>
                    <NavLink to="/Regjistro-perdoruesit" className='menu-item' activeClassName='active'>
                        <i className='bi bi-person-add me-2'></i>
                        <span>Regjistro Perdoruesit</span>
                    </NavLink>
                    <NavLink to="/Financat" className='menu-item' activeClassName='active'>
                        <i className='bi bi-bank me-2'></i>
                        <span>Financat</span>
                    </NavLink>
                    <NavLink to="/Analitika" className='menu-item' activeClassName='active'>
                        <i className='bi bi-graph-up me-2'></i>
                        <span>Analitika</span>
                    </NavLink>
                    <NavLink to="/Porosite" className='menu-item' activeClassName='active'>
                        <i className='bi bi-bag-check me-2'></i>
                        <span>Porosite</span>
                    </NavLink>
                    <NavLink to="/RegjistroFaturen" className='menu-item' activeClassName='active'>
                        <i className='bi bi-file-earmark-plus-fill me-2'></i>
                        <span>Regjistro Fatura</span>
                    </NavLink>
                    <NavLink to="/Lajmerimet" className='menu-item' activeClassName='active'>
                        <i className='bi bi-bell me-2'></i>
                        <span>Lajmerimet</span>
                    </NavLink>
                    <NavLink to="/Reports" className='menu-item' activeClassName='active'>
                        <i className='bi bi-file-earmark-text me-2'></i>
                        <span>Raporte</span>
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

export default Sidebar;