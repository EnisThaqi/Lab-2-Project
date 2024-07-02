import axios from "axios";
import { useEffect, useState } from "react";

//per lidhjen nje me shum .....
const Books = (props) => {

    const [books, setBooks] = useState([]);


    useEffect(() => {
        fetchData()

    }, [])

    const fetchData = async () => {
        axios.get('https://localhost:3000/Books/get-all').then(response => {
            console.log(response)
            setBooks(response.data)
        }).catch(error => {
            console.error(error)
        })
    }
    return (
        <div>
            <h1>Books</h1>
            <ul>
                {books.map(book => (
                    <li key={book.bookId}>
                        <h2>{book.title}</h2>
                        <p>Author: {book.author.name}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Books;

//shum me shum ndryshon veq returni kto tjerat mesin njejt
return (
    <div>
        <h1>Books and Authors</h1>
        {books.map(book => (
            <div key={book.bookId}>
                <h2>{book.bookTitle}</h2>
                <p>Authors:</p>
                <ul>
                    {book.authorNames.map((authorName, index) => (
                        <li key={index}>{authorName}</li>
                    ))}
                </ul>
            </div>
        ))}
    </div>
);

//njo me njo returni ndryshn tjerat njejt
return (
    <div>
        {book && (
            <div>
                <h1>{book.title}</h1>
                <p>Author: {book.author.name}</p>
            </div>
        )}
    </div>
);

