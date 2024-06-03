import axios from "axios";
import { useState, useEffect } from "react";
import Nav from "../Nav";
import '../style.css';

const RegjistroFaturen = () => {
  const [invoice, setInvoice] = useState({
    issued_Date: new Date().toISOString().slice(0, 16),
    status: '',
    createdBy: '',
    date: '',
    dateFrom: '',
    dateTo: '',
    subjectId: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setInvoice({ ...invoice, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7270/Invoice/create', invoice);
      console.log('Fatura u shtua:', response.data);
      setInvoice({
        issued_Date: new Date().toISOString().slice(0, 16),
        status: '',
        createdBy: '',
        date: '',
        dateFrom: '',
        dateTo: '',
        subjectId: '',
      });
    } catch (error) {
      console.error('Error adding an invoice:', error);
    }
  };

  return (
    <div>
      <Nav />
      <h1>Forma për krijimin e një fature të re.</h1>
      <p>
        Kujtesë! Krijimi i një fature të re nënkupton krijimin e skriptës në databazë për këtë faturë. Kjo mund të rris kohën e ekzekutimit të këtij procesi.
      </p>
      <div className="form-container">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Data e lëshimit:</label>
            <input
              type="datetime-local"
              name="issued_Date"
              value={invoice.issued_Date}
              onChange={handleChange}
              required
              readOnly
            />
          </div>
          <div className="form-group">
            <label>Statusi:</label>
            <input
              type="text"
              name="status"
              value={invoice.status}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Krijuar nga:</label>
            <input
              type="text"
              name="createdBy"
              value={invoice.createdBy}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Data:</label>
            <input
              type="datetime-local"
              name="date"
              value={invoice.date}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Data nga:</label>
            <input
              type="datetime-local"
              name="dateFrom"
              value={invoice.dateFrom}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Data deri:</label>
            <input
              type="datetime-local"
              name="dateTo"
              value={invoice.dateTo}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Subject ID:</label>
            <input
              type="number"
              name="subjectId"
              value={invoice.subjectId}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="submit-button">Krijo faturën</button>
        </form>
      </div>
    </div>
  );
};

export default RegjistroFaturen;
