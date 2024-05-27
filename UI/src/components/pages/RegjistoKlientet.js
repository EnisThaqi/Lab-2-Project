import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";
import '../style.css';

const RegjistoKlientet = () => {
  const [Subjects, setSubjects] = useState({
    subjectName: '',
    bussinesNr: '',
    vaTnr: '',
    email: '',
    phoneNumber: '',
    subject_TypeID: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setSubjects({ ...Subjects, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7270/Subjects/create', Subjects);
      console.log('Klienti u shtua:', response.data);
      setSubjects({
        subjectName: '',
        bussinesNr: '',
        vaTnr: '',
        email: '',
        phoneNumber: '',
        subject_TypeID: '',
      });
    } catch (error) {
      console.error('Error adding client:', error);
    }
  };

  return (
    <div>
      <Nav/>{}
      <h1>Forma për krijimin e një klienti të ri.</h1>
      <p>
        Kujtesë! Krijimi i një klienti të ri nënkupton krijimin e skriptës në databazë për këtë klient. Kjo mund të rris kohën e ekzekutimit të këtij procesi.
      </p>
      <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Emri klientit:</label>
          <input
            type="text"
            name="subjectName"
            value={Subjects.subjectName}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Business Nr:</label>
          <input
            type="text"
            name="bussinesNr"
            value={Subjects.bussinesNr}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>VATnr:</label>
          <input
            type="text"
            name="vaTnr"
            value={Subjects.vaTnr}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Email:</label>
          <input
            type="email"
            name="email"
            value={Subjects.email}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Numri i Telefonit:</label>
          <input
            type="tel"
            name="phoneNumber"
            value={Subjects.phoneNumber}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Lloji klientit:</label>
          <select
            name="subject_TypeID"
            value={Subjects.subject_TypeID}
            onChange={handleChange}
            required
          >
            <option value="">Zgjedh llojin e klientit</option>
            <option value="1">Type1</option>
            <option value="3">Type2</option>
          </select>
        </div>
        <button type="submit" className="submit-button">Krijo klientin</button>
      </form>
      </div>
    </div>
  );
};

export default RegjistoKlientet;