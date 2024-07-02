import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import BusinessSidebar from "../BusinessSidebar";
import Porosite2 from "../pages/Porosite2";
import KrijoPorosite from "../pages/KrijoPorosite";
import Pagesat from "../pages/Pagesat";
import Reports from "../pages/Reports";

 const BussinesLayout = () =>{
    
    const [toggle, setToggle] = useState(true);
    const Toggle = () => {
        setToggle(!toggle)
    }
    return (
        <BusinessSidebar>
            <Routes>
            <Route exact path='/Porosite2' element={<Porosite2 Toggle={Toggle} />} />
            <Route exact path='/KrijoPorosite' element={<KrijoPorosite Toggle={Toggle} />} />
            <Route exact path='/Pagesat' element={<Pagesat Toggle={Toggle} />} />
            <Route exact path='/Reports' element={<Reports Toggle={Toggle} />} /> 
            </Routes>
        </BusinessSidebar>
    )
}

export default BussinesLayout;