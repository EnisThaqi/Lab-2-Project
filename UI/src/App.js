import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Home from './components/Home';
import { useState } from "react";
import Klientet from './components/pages/Klientet';
import Notifications from './components/pages/Notifications';
import Perdoruesit from "./components/pages/Perdoruesit";



function App() {
  const [toggle, setToggle] = useState(true)
  const Toggle = () => {
    setToggle(!toggle)
  }
  return (
    <Router>
      <div>
        <div>
          
          {/* {toggle && <div className='col-2'>
        
        </div>} */}
          <div>
            <Sidebar>
              <Routes>
                <Route exact path='/' element={<Home Toggle={Toggle} />} />
                <Route exact path='/Klientet' element={<Klientet Toggle={Toggle} />} />
                <Route exact path='/Perdoruesit' element={<Perdoruesit Toggle={Toggle} />} />
                <Route excat path='/Notifications' element={<Notifications Toggle={Toggle} />} />

              </Routes>
            </Sidebar>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
