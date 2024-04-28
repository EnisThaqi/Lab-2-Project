
import React from "react";
import Nav from "./Nav";

function Home({Toggle}){
    return(
        <div className='px-3'>
            <Nav Toggle={Toggle}/>

        </div>
    )
}

export default Home