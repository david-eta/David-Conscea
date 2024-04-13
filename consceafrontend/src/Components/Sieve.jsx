import React, { useState, useEffect } from 'react'
import axios from 'axios'

// This Component is used to test frontend -- backend communication

const Sieve = ( ) => {
    const [limit, setLimit] = useState([])

    useEffect(() => {
        axios.get('http://localhost:5000/TrafficTesting/Sieve?limit=200')
            .then(response => { console.log(response.data); setLimit(response.data); })
            .catch(error => console.error('Error fetching users:', error))
    }, [])

    return (
        <div>
            {/* Display Sieve Test */}
          {limit}
        </div>
    )
}

export default Sieve
