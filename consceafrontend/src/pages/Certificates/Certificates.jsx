import './Certificates.css'

// Example of a data array that
// you might receive from an API
const data = [
    { certification: "AZ-900: A Guide to becoming a professional", expertise: "Fundamental", category:"Developer"},
    { certification: "AZ-1400", expertise: "Professional", category:"Architect"},
    { certification: "AZ-2400", expertise: "Professional", category:"Business"},
]

export default function Certificates() {
    return (
        <body>
            <h1>All Certificates</h1>

            <table>
                <tr>
                    <th>Certificate Name</th>
                    <th>Expertise</th>
                    <th>Category</th>
                </tr>
                {data.map((val, key) => {
                    return (
                        <tr key={key}>
                            <td>{val.certification}</td>
                            <td>{val.expertise}</td>
                            <td>{val.category}</td>
                        </tr>
                    )
                })}
            </table>
        </body>
    )
}