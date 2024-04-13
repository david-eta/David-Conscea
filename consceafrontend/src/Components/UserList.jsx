import React, { useState, useEffect } from 'react'
import axios from 'axios'

const UserList = ( ) => {
    const [users, setUsers] = useState([])

    useEffect(() => {
        axios.get('http://localhost:5000/Account')
            .then(response => setUsers(response.data))
            .catch(error => console.error('Error fetching users:', error))
    }, [])

    return (
        <div>
            {/* Display the fetched user data */}
            {users.map(user => (
                <div key={user.id}>{user.name}</div>
            ))}
            <div>Hey!</div>
        </div>
    )
}

export default UserList
