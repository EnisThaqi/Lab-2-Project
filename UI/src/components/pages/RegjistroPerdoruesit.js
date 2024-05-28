import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";
import '../style.css';

const RegjistroPerdoruesit = () => {
  const [User, setUser] = useState({
    username: '',
    email: '',
    password: '',
    address: '',
    phoneNumber: '',
    roletID: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({ ...User, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7270/User/create', User);
      console.log('Perdoruesi u shtua:', response.data);
      setUser({
        username: '',
        email: '',
        password: '',
        address: '',
        phoneNumber: '',
        roletID: '',
      
      });
    } catch (error) {
      console.error('Error adding a user:', error);
    }
  };

  return (
    <div>
      <Nav/>{}
      <h1>Forma për krijimin e një perdoruesi të ri.</h1>
      <p>
        Kujtesë! Krijimi i një perdoruesi të ri nënkupton krijimin e skriptës në databazë për këtë perdorues. Kjo mund të rris kohën e ekzekutimit të këtij procesi.
      </p>
      <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Emri userit:</label>
          <input
            type="text"
            name="username"
            value={User.username}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Email:</label>
          <input
            type="email"
            name="email"
            value={User.email}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Password:</label>
          <input
            type="text"
            name="password"
            value={User.password}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Address:</label>
          <input
            type="text"
            name="address"
            value={User.address}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Numri i Telefonit:</label>
          <input
            type="tel"
            name="phoneNumber"
            value={User.phoneNumber}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Roli:</label>
          <select
            name="roletID"
            value={User.roletID}
            onChange={handleChange}
            required
          >
            <option value="">Zgjedh llojin e userit</option>
            <option value="1">Klient</option>
            <option value="3">Biznes</option>
          </select>
        </div>
        <button type="submit" className="submit-button">Krijo perdoruesin</button>
      </form>
      </div>
    </div>
  );
};

export default RegjistroPerdoruesit;