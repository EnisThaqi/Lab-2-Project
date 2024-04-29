import axios from "axios";
import { useEffect, useState } from "react";
import Nav from "../Nav";



const Klientet = (props) => {

    const [subjects, setSubjects] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:7270/Subjects/get-all').then(response => {
            console.log(response)
            setSubjects(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <>
            {
                subjects && subjects?.map(item => (
                    
                    <>
                        <div>
            <Nav /> {/* Optional navigation component */}
            <h2 style={{ textAlign: 'center' }}>Klientët</h2>
            <p>Këtu mund ti shihni të gjithë klientët.</p>
            <table className="table"> {/* Create a table structure */}
                <thead>
                    <tr> {/* Table headers */}
                        <th>ID</th>
                        <th>Emri Kliertit</th>
                        <th>Business Number</th>
                        <th>VAT Number</th>
                        <th>Email</th>
                        <th>Phone Number</th>
                        <th>Lloji Klientit</th>
                    </tr>
                </thead>
                <tbody>
                    {Array.isArray(subjects) && subjects.length > 0 ? (
                        subjects.map((item) => (
                            <tr key={item.SubjectsID}> {/* Create a row for each item */}
                                <td>{item.subjectsID}</td>
                                <td>{item.subjectName}</td>
                                <td>{item.bussinesNr}</td>
                                <td>{item.vaTnr}</td>
                                <td>{item.email}</td>
                                <td>{item.phoneNumber}</td>
                                <td>{item.subject_TypeID}</td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="7">No subjects found.</td> {/* Handle empty data */}
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
                    </>
                ))
            }
        </>
    )
}


export default Klientet;