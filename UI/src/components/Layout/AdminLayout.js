import React, { useState } from 'react';
import { Route, Routes } from "react-router-dom";
import Sidebar from "../Sidebar";
import Home from "../Home";
import Klientet from "../pages/Klientet";
import RegjistoKlientet from "../pages/RegjistoKlientet";
import Perdoruesit from "../pages/Perdoruesit";
import Lajmerimet from "../pages/Lajmerimet";
import Porosite from "../pages/Porosite";
import RegjistroPerdoruesit from "../pages/RegjistroPerdoruesit";
import Financat from "../pages/Financat"; 
import Analitika from "../pages/Analitika"; 

const AdminLayout = () => {
    const [toggle, setToggle] = useState(true);

    const Toggle = () => {
        setToggle(!toggle);
    }

    return (
        <Sidebar>
            <Routes>
                <Route exact path='/' element={<Home Toggle={Toggle} />} />
                <Route exact path='/Klientet' element={<Klientet Toggle={Toggle} />} />
                <Route exact path='/Regjistro-klientet' element={<RegjistoKlientet Toggle={Toggle} />} />
                <Route exact path='/Perdoruesit' element={<Perdoruesit Toggle={Toggle} />} />
                <Route excat path='/Lajmerimet' element={<Lajmerimet Toggle={Toggle} />} />
                <Route path='/Porosite' element={<Porosite Toggle={Toggle} />} />
                <Route excat path='/Regjistro-perdoruesit' element={<RegjistroPerdoruesit Toggle={Toggle} />} />
                <Route exact path='/Financat' element={<Financat Toggle={Toggle} />} />
                <Route exact path='/Analitika' element={<Analitika Toggle={Toggle} />} />
            </Routes>
        </Sidebar>
    )
}

export default AdminLayout;
