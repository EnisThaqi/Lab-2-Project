import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Sidebar from './components/Sidebar';
import Home from './components/Home';
import { useState } from "react";



function App() {
  const [toggle, setoggle] = useState(true)
  const Toggle = () => {
    setoggle(!toggle)
  }
  return (
    <div className='bg-secondary min-vh-100'>
      <div className='row'>
       {toggle && <div className='col-2 bg-white vh-100'>
        <Sidebar />
        </div>}
        <div className='col'>
          <Home Toggle={Toggle}/>
        </div>
      </div>
    </div>
  );
}

export default App;
