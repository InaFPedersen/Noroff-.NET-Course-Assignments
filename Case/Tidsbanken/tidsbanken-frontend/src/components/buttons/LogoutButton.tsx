import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "react-bootstrap";

export const LogoutButton = () => {
	const { logout } = useAuth0();

	return (
		<div className="d-grid gap-2">
		<Button variant="outline-dark" onClick={() => logout({ returnTo: window.location.origin })}>
			Log Out
		</Button>
		</div>
	);
};
