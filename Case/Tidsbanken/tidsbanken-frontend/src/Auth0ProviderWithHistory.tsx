import { AppState, Auth0Provider } from "@auth0/auth0-react";
import { PropsWithChildren } from "react";
import { useNavigate } from "react-router-dom";
import { useEnv } from "./context/env.context";

export const Auth0ProviderWithHistory = ({
	children,
}: PropsWithChildren<any>): JSX.Element | null => {
	const navigate = useNavigate();
	const { domain, clientId, audience } = useEnv();

	const onRedirectCallBack = (appstate: AppState) => {
		navigate(appstate?.returnTo || window.location.pathname);
	};

	if (!(domain && clientId && audience)) {
		return null;
	}

	return (
		<Auth0Provider
			domain={domain}
			clientId={clientId}
			audience={audience}
			redirectUri={window.location.origin}
			onRedirectCallback={onRedirectCallBack}
		>
			{children}
		</Auth0Provider>
	);
};
