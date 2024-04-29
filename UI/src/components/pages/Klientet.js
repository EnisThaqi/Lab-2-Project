import React from "react";
import Nav from "../Nav";
import axios from "axios";
import { useEffect, useState } from "react";


function Klientet(Toggle){

    return(
        <div className='px-3'>
            <Nav Toggle={Toggle}/>
        </div>

    )
}

export default Klientet; 