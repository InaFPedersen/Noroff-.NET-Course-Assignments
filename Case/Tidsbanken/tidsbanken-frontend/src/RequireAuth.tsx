import { useAuth0 } from "@auth0/auth0-react";
import { PropsWithChildren } from "react";
import { Navigate } from "react-router-dom";

export const RequireAuth = ({
	children,
}: PropsWithChildren<any>): JSX.Element | null => {
	const { isAuthenticated } = useAuth0();

	if (isAuthenticated) {
		return children;
	}
	return <Navigate to="/" />;
};
