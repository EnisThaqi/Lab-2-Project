import React from "react";
import Nav from "../Nav";



function Notifications(Toggle){

    return(
        <div className='px-3'>
            <Nav Toggle={Toggle}/>
            <h3>Njoftimet</h3>
        </div>

    )
}

export default Notifications; 