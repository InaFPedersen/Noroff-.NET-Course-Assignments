import { useState } from "react";
import { API } from "../../../hooks/API";
import { selfReadUserDTO, selfUpdateUserDTO } from "../../../models/DTOs";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

interface userProp {
	user: selfReadUserDTO | undefined;
}

const UserForm = ({ user }: userProp) => {
	const navigate = useNavigate();
	const [picture, setPicture] = useState("");
	const [email, setEmail] = useState("");

	const { SelfUpdateUser } = API();

	const onEmailChange = (e: any) => {
		setEmail(e.target.value);
	};

	const onPictureChange = (e: any) => {
		setPicture(e.target.value);
	};

	const onSubmit = async () => {
		let _email = email;
		if (email === "") {
			_email = user!.email!;
		}

		if (!_email.includes("@") || !_email.includes(".")) {
			return;
		}
		let newData: selfUpdateUserDTO = {
			id: user!.id,
			profilePicture: picture,
			firstName: user!.firstName,
			lastName: user!.lastName,
			email: _email,
		};

		const data = await SelfUpdateUser(newData);
		setPicture(data.profilePicture);
		setEmail(data._email);
		window.location.reload();
	};

	return (
		<>
			<label>Change Email</label>
			<input type="email" placeholder="email" onChange={onEmailChange} />

			<br />
			<label>Change Profile Picture</label>
			<input
				type="text"
				placeholder="Enter image url"
				onChange={onPictureChange}
			/>
			<div className="button-container">
				<Button
					variant="outline-primary"
					style={{ marginTop: "10px" }}
					className="create-btn"
					type="submit"
					onClick={onSubmit}
				>
					Update user
				</Button>
			</div>
		</>
	);
};

export default UserForm;
