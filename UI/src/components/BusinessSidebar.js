import React, { useState } from 'react';
import './style.css';
import { NavLink, useNavigate } from 'react-router-dom';

function BusinessSidebar({ children }) {
    const [menuOpen, setMenuOpen] = useState(true);
    const navigate = useNavigate();

    const toggleMenu = () => {
        setMenuOpen(!menuOpen);
    };

    const handleLogout = () => {
        localStorage.removeItem('userRole');
        localStorage.removeItem('subjectId');
        navigate('/login');
    };

    return (
        <div style={{ display: 'flex' }}>
            <div className={`sidebar-wrapper ${menuOpen ? 'open' : 'closed'}`}>
                <div className='sidebar'>
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
                        <NavLink to="/Reports" className='menu-item' activeClassName='active'>
                        <i className='bi bi-file-earmark-text me-2'></i>
                        <span>Raporte</span>
                    </NavLink>
                    </div>
                </div>
                <button onClick={toggleMenu} className='menu-toggle'>
                    <i className={`bi ${menuOpen ? 'bi-x' : 'bi-list'}`}></i>
                </button>
            </div>
            <div style={{ background: '#f0f0f0', height: '100vh', flex: 1 }} className='ps-1'>
                <div className='top-bar'>
                    <button onClick={handleLogout} className='btn btn-danger'>
                        <i className='bi bi-box-arrow-right me-2'></i>
                        <span>Logout</span>
                    </button>
                </div>
                <div className='content'>
                    {children}
                </div>
            </div>
        </div>
    );
}

export default BusinessSidebar;
