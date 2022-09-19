import { selfReadUserDTO } from "../../models/DTOs";
import { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { API } from "../../hooks/API";
import ModalEditUser from "./ModalEditUser";
import UserInfo from "./UserComponents/UserInfo";

const UserView = () => {
	const { GetLoggedInUser, SelfChangePassword } = API();
	let [user, setUser] = useState<selfReadUserDTO>();

	useEffect(() => {
		GetLoggedInUser().then((data) => setUser(data));
	}, []);

	const [modalShow, setModalShow] = useState(false);

	const onChangePasswordClick = async () => {
		if (user === null) {
			return;
		}
		const message = await SelfChangePassword(user!.email);
		alert(JSON.stringify(message));
	};
	return (
		<>
			<h1>Profile Page</h1>
			<div className="userInfo">
				<UserInfo user={user} />
				<Button variant="secondary" onClick={() => setModalShow(true)}>
					Edit Profile
				</Button>
				<ModalEditUser
					show={modalShow}
					onHide={() => setModalShow(false)}
					user={user}
				/>
				<Button
					style={{ marginLeft: "25px" }}
					variant="secondary"
					onClick={onChangePasswordClick}
				>
					Change Password
				</Button>
			</div>
		</>
	);
};

export default UserView;
