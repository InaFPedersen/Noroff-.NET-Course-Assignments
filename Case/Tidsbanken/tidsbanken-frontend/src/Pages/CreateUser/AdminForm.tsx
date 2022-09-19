import { max } from "moment";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { API } from "../../hooks/API";
import { adminCreateUserDTO } from "../../models/DTOs";
import { Button, Form } from "react-bootstrap";

const AdminForm = () => {
	const [email, setEmail] = useState("");
	const [firstName, setFirstName] = useState("");
	const [lastName, setLastName] = useState("");
	const [admin, setAdmin] = useState(false);
	const [phoneNumber, setPhoneNumber] = useState(55555555);
	const [profilePicture, setProfilePicture] = useState(
		"https://mcdn.wallpapersafari.com/medium/36/8/RmU0Au.jpg"
	);

	const onFirstNameChange = (e: any) => {
		setFirstName(e.target.value);
	};

	const onlastNameChange = (e: any) => {
		setLastName(e.target.value);
	};

	const onEmailChange = (e: any) => {
		setEmail(e.target.value);
	};
	let { AdminCreateUser } = API();
	const onSubmit = async (e: any) => {
		e.preventDefault();

		let details: adminCreateUserDTO = {
			profilePicture: profilePicture,
			firstName: firstName,
			lastName: lastName,
			email: email,
			isAdmin: admin,
			phoneNumber: phoneNumber,
		};

		AdminCreateUser(details);
		navigateTo("/dashboard");
	};
	const navigateTo = useNavigate();
	const onAdminChange = (event: any) => {
		setAdmin(event.target.checked);
	};
	const onPhoneNumberChange = (e: any) => {
		setPhoneNumber(Number(e.target.value));
	};

	return (
		<>
			<div style={{ float: "right" }}>
				<img src={profilePicture} style={{ maxHeight: "400px" }} />
			</div>
			<div style={{ float: "left" }}>
				<form onSubmit={onSubmit}>
					<label>First name:</label>
					<input
						type="text"
						placeholder="Firstname"
						onChange={onFirstNameChange}
					/>
					<label>Last name:</label>
					<input
						type="text"
						placeholder="Lastname"
						onChange={onlastNameChange}
					/>

					<label>Phone number:</label>
					<input
						type="phoneNumber"
						placeholder="555555555"
						onChange={onPhoneNumberChange}
					/>
					<label>Picture:</label>
					<input
						type="picture"
						placeholder="https://mcdn.wallpapersafari.com/medium/36/8/RmU0Au.jpg"
						onChange={(e) => setProfilePicture(e.target.value)}
					/>

					<label>Email:</label>
					<input
						type="email"
						placeholder="Email"
						onChange={onEmailChange}
					/>

					<br />
					<Form>
						<Form.Check
							type="switch"
							id="custom-switch"
							label="Admin: "
							onChange={onAdminChange}
						/>
					</Form>

					<br />
					<Button variant="outline-secondary" type="submit">
						Create User
					</Button>
				</form>
			</div>
		</>
	);
};

export default AdminForm;
