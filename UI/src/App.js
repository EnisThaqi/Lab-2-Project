import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Sidebar from './components/Sidebar';



function App() {
  return (
    <div className='container fluid' >
      <div className='row'>
        <div className='col-2'></div>
      </div>
      <Sidebar />
    </div>
  );
}

export default App;
