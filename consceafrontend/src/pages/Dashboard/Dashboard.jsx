import './Dashboard.css'

// Example of a data array that
// you might receive from an API
const data = [
    { employeeId: 1323, fName: "Ronak", lName: "Sanghavi", email:"ronsang@email.com", mobile:"8031234567", role:"Solutions Architect", grade:"F", userType:"Admin", username:"RonakSa"},
    { employeeId: 4875, fName: "Venkata", lName: "Achanti", email:"venkach@email.com", mobile:"1233498431", role:"Vice President", grade:"C", userType:"User", username:"VenkataAc"},
]

export default function Dashboard() {
    return (
        <body>
            <h1>Dashboard</h1>
            
            <table>
                <tr>
                    <th>Employee</th>
                    <th>Role</th>
                    <th>Grade</th>
                    <th>Level</th>
                    <th>Email</th>
                </tr>
                {data.map((val, key) => {
                    return (
                        <tr key={key}>
                            <td>{val.fName} {val.lName}</td>
                            <td>{val.role}</td>
                            <td>{val.grade}</td>
                            <td>{val.userType}</td>
                            <td>{val.email}</td>
                        </tr>
                    )
                })}
            </table>
        </body>
    )
}