import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Home from './components/Home';
import { useState } from "react";
import Klientet from './components/pages/Klientet';
import Lajmerimet from './components/pages/Lajmerimet';
import Perdoruesit from "./components/pages/Perdoruesit";
import RegjistoKlientet from "./components/pages/RegjistoKlientet";
import Porosite from "./components/pages/Porosite";
import RegjistroPerdoruesit from "./components/pages/RegjistroPerdoruesit";



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
                <Route exact path='/Regjistro-klientet' element={<RegjistoKlientet Toggle={Toggle} />} />
                <Route exact path='/Perdoruesit' element={<Perdoruesit Toggle={Toggle} />} />
                <Route excat path='/Lajmerimet' element={<Lajmerimet Toggle={Toggle} />} />
                <Route excat path='/Porosite' element={<Porosite Toggle={Toggle} />} />
                <Route excat path='/Regjistro-perdoruesit' element={<RegjistroPerdoruesit Toggle={Toggle} />} />

              </Routes>
            </Sidebar>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
