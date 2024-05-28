import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";



const Porosite = (props) => {

    const [Orders, setOrders] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:7270/Orders/get-all').then(response => {
            console.log(response)
            setOrders(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <>



            <>
                <div>
                    <Nav /> {}
                    <h2 style={{ textAlign: 'center' }}>Porositë</h2>
                    <p>Këtu mund ti shihni të gjitha porositë.</p>
                    <table className="table"> {}
                        <thead>
                            <tr> {}
                                <th>ID</th>
                                <th>Sasia</th>
                                <th>Pranuesi</th>
                                <th>Pesha</th>
                                <th>Shteti</th>
                                <th>Nr i pranuesit</th>
                                <th>Adresa</th>
                                <th>Pershkrimi</th>
                                <th>Infot</th>
                                <th>Kodi</th>
                                <th>Hapet</th>
                                <th>Kthehet</th>
                                <th>Madhesia</th>
                                <th>Statusi</th>
                    
                            </tr>
                        </thead>
                        <tbody>
                            {Array.isArray(Orders) && Orders.length > 0 ? (
                                Orders.map((item) => {
                                    return (
                                        <tr key={item.orderID}> {}
                                            <td>{item.orderID}</td>
                                            <td>{item.quantity}</td>
                                            <td>{item.receiver_Name}</td>
                                            <td>{item.weight}</td>
                                            <td>{item.receiver_Country}</td>
                                            <td>{item.receiver_Phone}</td>
                                            <td>{item.receiver_Address}</td>
                                            <td>{item.description}</td>
                                            <td>{item.additional_information}</td>
                                            <td>{item.reference_code}</td>
                                            <td>{item.can_open}</td>
                                            <td>{item.is_take_back}</td>
                                            <td>{item.packageSizeId}</td>
                                            <td>{item.statusId}</td>
                                           

                                        </tr>
                                    )
                                })
                            ) : (
                                <tr>
                                    <td colSpan="14">No orders were found.</td> {}
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </>


        </>
    )
}


export default Porosite;