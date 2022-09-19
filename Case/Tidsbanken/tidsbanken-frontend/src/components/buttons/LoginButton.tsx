import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "react-bootstrap";

export const LoginButton = () => {
	const { loginWithRedirect } = useAuth0();

	return <Button variant="outline-secondary" size="lg" onClick={() => loginWithRedirect()}>Log In</Button>;
};
