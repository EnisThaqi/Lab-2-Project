import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Login.css';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7270/User/login', { username, password });
      const { role, subjectId } = response.data;

      localStorage.setItem('userRole', role);
      localStorage.setItem('subjectId', subjectId);

      if (role === 3) {
        navigate('/sidebar');
      } else {
        navigate('/BusinessSidebar');
      }
    } catch (error) {
      if (error.response) {
        setError(error.response.data);
      } else {
        setError('An error occurred. Please try again.');
      }
    }
  };

  const handleNoAccountClick = () => {
    navigate('/NoAccount');
  };

  return (
    <div className="login-container">
      <div className="login-form">
        <i className="bi bi-truck login-icon"></i>
        <h1>Login</h1>
        <input
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          placeholder="Username"
        />
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          placeholder="Password"
        />
        <button onClick={handleLogin}>Login</button>
        <div className="no-account-button" onClick={handleNoAccountClick}>
          No Account? Then use Tracking ID to track your order.
        </div>
        {error && <div className="error-message">{error}</div>}
      </div>
    </div>
  );
};

export default Login;