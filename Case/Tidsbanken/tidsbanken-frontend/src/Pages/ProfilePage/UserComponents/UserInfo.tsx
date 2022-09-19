import { selfReadUserDTO } from "../../../models/DTOs";
import { ProfilePicture } from "../ProfilePicture";

interface InfoProps {
	user: selfReadUserDTO | undefined;
}

const UserInfo = ({ user }: InfoProps) => {
	if (user !== null && user !== undefined) {
		return (
			<>
				<ProfilePicture
					profilePicture={user!.profilePicture}
					alt={user!.firstName + " " + user!.lastName}
					height={"150"}
					fontSize={"8"}
				/>
				<p> First name: {user!.firstName} </p>
				<p> Last name: {user!.lastName} </p>
				<p> Phone number: {user!.phoneNumber} </p>
				<p> Email: {user!.email} </p>
			</>
		);
	}
	return <></>;
};

export default UserInfo;
