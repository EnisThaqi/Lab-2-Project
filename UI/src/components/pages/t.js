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
//detyra planet-satelit 
//A)
import React, { useState } from 'react';
import { addPlanet } from '../services/api';

const AddPlanet = () => {
    const [newPlanet, setNewPlanet] = useState({ name: '', type: '' });

    const handleAddPlanet = async () => {
        await addPlanet(newPlanet);
        setNewPlanet({ name: '', type: '' });
    };

    return (
        <div>
            <input
                type="text"
                value={newPlanet.name}
                onChange={(e) => setNewPlanet({ ...newPlanet, name: e.target.value })}
                placeholder="Name"
            />
            <input
                type="text"
                value={newPlanet.type}
                onChange={(e) => setNewPlanet({ ...newPlanet, type: e.target.value })}
                placeholder="Type"
            />
            <button onClick={handleAddPlanet}>Add Planet</button>
        </div>
    );
};

//export default AddPlanet;
//B)
import React, { useState } from 'react';
import { addSatellite } from '../services/api';

const AddSatellite = ({ planetId }) => {
    const [newSatellite, setNewSatellite] = useState({ name: '', planetId });

    const handleAddSatellite = async () => {
        await addSatellite(newSatellite);
        setNewSatellite({ name: '', planetId });
    };

    return (
        <div>
            <input
                type="text"
                value={newSatellite.name}
                onChange={(e) => setNewSatellite({ ...newSatellite, name: e.target.value })}
                placeholder="Name"
            />
            <button onClick={handleAddSatellite}>Add Satellite</button>
        </div>
    );
};

//export default AddSatellite;
//C)
import React, { useState } from 'react';
import { updatePlanetByName } from '../services/api';

const UpdatePlanetType = () => {
    const [planetName, setPlanetName] = useState('');
    const [newType, setNewType] = useState('');

    const handleUpdatePlanet = async () => {
        await updatePlanetByName(planetName, newType);
        setPlanetName('');
        setNewType('');
    };

    return (
        <div>
            <input
                type="text"
                value={planetName}
                onChange={(e) => setPlanetName(e.target.value)}
                placeholder="Planet Name"
            />
            <input
                type="text"
                value={newType}
                onChange={(e) => setNewType(e.target.value)}
                placeholder="New Type"
            />
            <button onClick={handleUpdatePlanet}>Update Type</button>
        </div>
    );
};

//export default UpdatePlanetType;
//D)
import React, { useEffect, useState } from 'react';
import { getSatellitesByPlanetName } from '../services/api';

const SatelliteList = ({ planetName }) => {
    const [satellites, setSatellites] = useState([]);

    useEffect(() => {
        fetchSatellites();
    }, [planetName]);

    const fetchSatellites = async () => {
        const response = await getSatellitesByPlanetName(planetName);
        setSatellites(response.data);
    };

    return (
        <div>
            <h1>Satellites</h1>
            <ul>
                {satellites.map(satellite => (
                    <li key={satellite.satelliteID}>
                        {satellite.name}
                    </li>
                ))}
            </ul>
        </div>
    );
};

//export default SatelliteList;
//E)
import React from 'react';
import { deleteSatellite } from '../services/api';

const SatelliteItem = ({ satellite }) => {
    const handleDeleteSatellite = async () => {
        await deleteSatellite(satellite.satelliteID);
    };

    return (
        <li>
            {satellite.name}
            <button onClick={handleDeleteSatellite}>Delete</button>
        </li>
    );
};

//export default SatelliteItem;



//detyra planet satelit me dto 
//A)
// src/components/AddPlanet.js

import React, { useState } from 'react';
import axios from 'axios';

//const AddPlanet = () => {
    const [name, setName] = useState('');
    const [type, setType] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('https://localhost:5001/api/planets', { name, type, isDeleted: false })
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error("There was an error adding the planet!", error);
            });
    };

    return (
        <div>
            <h2>Add Planet</h2>
            <form onSubmit={handleSubmit}>
                <label>Name:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                <label>Type:</label>
                <input type="text" value={type} onChange={(e) => setType(e.target.value)} required />
                <button type="submit">Add Planet</button>
            </form>
        </div>
    );
//};

//export default AddPlanet;
//B)// src/components/AddSatellite.js

import React, { useState } from 'react';
import axios from 'axios';

//const AddSatellite = () => {
  //  const [name, setName] = useState('');
    const [planetId, setPlanetId] = useState('');

    //const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('https://localhost:5001/api/satellites', { name, isDeleted: false, planetId })
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error("There was an error adding the satellite!", error);
            });
    //};

    return (
        <div>
            <h2>Add Satellite</h2>
            <form onSubmit={handleSubmit}>
                <label>Name:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                <label>Planet ID:</label>
                <input type="number" value={planetId} onChange={(e) => setPlanetId(e.target.value)} required />
                <button type="submit">Add Satellite</button>
            </form>
        </div>
    );
//};

//export default AddSatellite;
//C)
// src/components/UpdatePlanetType.js

import React, { useState } from 'react';
import axios from 'axios';

//const UpdatePlanetType = () => {
  //  const [name, setName] = useState('');
    const [newType, setNewType] = useState('');

    //const handleSubmit = (e) => {
        e.preventDefault();
        axios.put(`https://localhost:5001/api/planets/${name}`, newType, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error("There was an error updating the planet type!", error);
            });
    //};

    return (
        <div>
            <h2>Update Planet Type</h2>
            <form onSubmit={handleSubmit}>
                <label>Planet Name:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                <label>New Type:</label>
                <input type="text" value={newType} onChange={(e) => setNewType(e.target.value)} required />
                <button type="submit">Update Type</button>
            </form>
        </div>
    );
//};

//export default UpdatePlanetType;
//D)
// src/components/GetSatellites.js

import React, { useState } from 'react';
import axios from 'axios';

const GetSatellites = () => {
    const [name, setName] = useState('');
    const [satellites, setSatellites] = useState([]);

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.get(`https://localhost:5001/api/planets/${name}/satellites`)
            .then(response => {
                setSatellites(response.data);
            })
            .catch(error => {
                console.error("There was an error fetching the satellites!", error);
            });
    };

    return (
        <div>
            <h2>Get Satellites</h2>
            <form onSubmit={handleSubmit}>
                <label>Planet Name:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                <button type="submit">Get Satellites</button>
            </form>
            {satellites.length > 0 && (
                <ul>
                    {satellites.map(satellite => (
                        <li key={satellite.satelliteId}>{satellite.name}</li>
                    ))}
                </ul>
            )}
        </div>
    );
};

//export default GetSatellites;
//E)// 
src/components/DeleteSatellite.js

import React, { useState } from 'react';
import axios from 'axios';

const DeleteSatellite = () => {
    const [id, setId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.delete(`https://localhost:5001/api/satellites/${id}`)
            .then(response => {
                console.log("Satellite deleted successfully.");
            })
            .catch(error => {
                console.error("There was an error deleting the satellite!", error);
            });
    };

    return (
        <div>
            <h2>Delete Satellite</h2>
            <form onSubmit={handleSubmit}>
                <label>Satellite ID:</label>
                <input type="number" value={id} onChange={(e) => setId(e.target.value)} required />
                <button type="submit">Delete Satellite</button>
            </form>
        </div>
    );
};

//export default DeleteSatellite;
