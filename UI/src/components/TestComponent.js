import axios from "axios";
import { useEffect, useState } from "react";

const TestComponent = (props) => {

    const [notificationsType, setNotificationsType] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:7270/NotificationsType/read').then(response => {
            console.log(response)
            setNotificationsType(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <>
            {
                notificationsType && notificationsType?.map(item => (
                    
                    <>
                        <p style={{
                            color:'red'
                        }}>{item.notificationsTypeID}</p>
                        <p>{item.typeName}</p>
                    </>
                ))
            }
        </>
    )
}


export default TestComponent;