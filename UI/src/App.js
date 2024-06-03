import React, { useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { useState } from "react";
import Login from "./components/Login";
import AdminLayout from "./components/Layout/AdminLayout";
import BussinesLayout from "./components/Layout/BussinesLayout";
import NoAccount from "./components/NoAccount";

function App() {
  const [toggle, setToggle] = useState(true);
  const Toggle = () => {
    setToggle(!toggle)
  }

  const [role, setRole] = useState('');

  useEffect(() => {
    var tempRole = localStorage.getItem('userRole')

    if (tempRole) {
      setRole(tempRole.toString())
    }
  }, [localStorage])

  console.log(role,'test')

  return (
    <Router>
      <div>
        <div>

          {/* {toggle && <div className='col-2'>
        
        </div>} */}
          <div>
            <Routes>

              <Route path='/login' element={<Login />} />

              {/* Add route for NoAccount */}
              <Route path='/NoAccount' element={<NoAccount />} />

              {
                role == '3' ?
                  <Route path="/*" element={<AdminLayout />} />
                  :
                  <Route path="/*" element={<BussinesLayout />} />

              }

            </Routes>

          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
