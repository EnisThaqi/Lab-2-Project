import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";



const Perdoruesit = (props) => {

    const [User, setUser] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:7270/User/get-all').then(response => {
            console.log(response)
            setUser(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <>



            <>
                <div>
                    <Nav /> {}
                    <h2 style={{ textAlign: 'center' }}>Përdoruesit</h2>
                    <p>Këtu mund ti shihni të gjithë përdoruesit.</p>
                    <table className="table"> {}
                        <thead>
                            <tr> {}
                                <th>ID</th>
                                <th>Emri i Përdoruesit</th>
                                <th>Email</th>
                                <th>Password</th>
                                <th>Address</th>
                                <th>Phone Number</th>
                                <th>Krijuar me</th>
                                <th>Roli</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Array.isArray(User) && User.length > 0 ? (
                                User.map((item) => {
                                    return (
                                        <tr key={item.userID}> {}
                                            <td>{item.userID}</td>
                                            <td>{item.username}</td>
                                            <td>{item.email}</td>
                                            <td>{item.password}</td>
                                            <td>{item.address}</td>
                                            <td>{item.phoneNumber}</td>
                                            <td>{item.created_At}</td>
                                            <td>{item.roletID}</td>
                                        </tr>
                                    )
                                })
                            ) : (
                                <tr>
                                    <td colSpan="8">No user found.</td> {}
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </>


        </>
    )
}


export default Perdoruesit;