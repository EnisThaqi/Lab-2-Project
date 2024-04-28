import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Sidebar from './components/Sidebar';
import Home from './components/Home';
import { useState } from "react";



function App() {
  const [toggle, setToggle] = useState(true)
  const Toggle = () => {
    setToggle(!toggle)
  }
  return (
    <div className='bg-custom'>
      <div className='row'>
       {toggle && <div className='col-2'>
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
