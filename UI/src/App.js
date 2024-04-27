import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Sidebar from './components/Sidebar';



function App() {
  return (
    <div className='bg-secondary min-vh-100'>
      <div className='row'>
        <div className='col-2 bg-white vh-100'>
        <Sidebar />
        </div>
        <div className='col-auto'>

        </div>
      </div>
    </div>
  );
}

export default App;
