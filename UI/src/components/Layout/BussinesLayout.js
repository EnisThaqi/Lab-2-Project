import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import BusinessSidebar from "../BusinessSidebar";
import Porosite2 from "../pages/Porosite2";


 const BussinesLayout = () =>{
    
    const [toggle, setToggle] = useState(true);
    const Toggle = () => {
        setToggle(!toggle)
    }
    return (
        <BusinessSidebar>
            <Routes>
            <Route exact path='/Porosite2' element={<Porosite2 Toggle={Toggle} />} />
            </Routes>
        </BusinessSidebar>
    )
}

export default BussinesLayout;