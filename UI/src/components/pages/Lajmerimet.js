import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";



const Lajmerimet = (props) => {

    const [Notifications, setNotifications] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:7270/Notifications/read').then(response => {
            console.log(response)
            setNotifications(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <>



            <>
                <div>
                    <Nav /> {}
                    <h2 style={{ textAlign: 'center' }}>Lajmerimet</h2>
                    <p>Këtu mund ti shihni të gjitha Lajmërimet .</p>
                    <table className="table"> {}
                        <thead>
                            <tr> {}
                                <th>Mesazhi</th>
                                <th>U krijua</th>
                                <th>Lloji i lajmerimit</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            {Array.isArray(Notifications) && Notifications.length > 0 ? (
                                Notifications.map((item) => {
                                    return (
                                        <tr key={item.message}> {}
                                            <td>{item.createdAt}</td>
                                            <td>{item.notificationsTypeID}</td>
                                          
                                           
                                        </tr>
                                    )
                                })
                            ) : (
                                <tr>
                                    <td colSpan="7">No notifications were  found.</td> {}
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </>


        </>
    )
}


export default Lajmerimet;