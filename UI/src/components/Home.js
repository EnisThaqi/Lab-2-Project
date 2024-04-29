
import React from "react";
import Nav from "./Nav";

function Home({Toggle}){
    return(
        <div className='px-3'>
            <Nav Toggle={Toggle}/>
            <h3>Ballina</h3>
        </div>
    )
}

export default Home