import './Profile.css'

const data = { fName: "Ronak", lName: "Sanghavi", role:"Solutions Architect", email: "RonakSa@email.com", mobile:"8033221234", username:"RonakSa"};

export default function Profile() {
    return (
        <body>
                <h1>Profile</h1>

                <table class="profile">
                    <tr>{data.fName} {data.lName}</tr>
                    <tr>{data.role}</tr>
                    <tr>Email: {data.email}</tr>
                    <tr>Mobile: {data.mobile}</tr>
                    <tr>Username: {data.username}</tr>
                </table>

                <button class="profilebtn">Upload Photo</button>
                <button class="profilebtn">Change Password</button>
        </body>
    )
}