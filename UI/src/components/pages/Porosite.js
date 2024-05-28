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
                    <Nav /> {/* Optional navigation component */}
                    <h2 style={{ textAlign: 'center' }}>Porositë</h2>
                    <p>Këtu mund ti shihni të gjitha porositë.</p>
                    <table className="table"> {/* Create a table structure */}
                        <thead>
                            <tr> {/* Table headers */}
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
                                        <tr key={item.orderID}> {/* Create a row for each item */}
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
                                    <td colSpan="14">No orders were found.</td> {/* Handle empty data */}
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