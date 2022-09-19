import { useAuth0 } from "@auth0/auth0-react";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";

export const useAxiosConfig = () => {
	const { getAccessTokenSilently } = useAuth0();

	async function makeRequest<T> (config : AxiosRequestConfig, authenticated : boolean){
		try {
			if (authenticated) {
				const token = await getAccessTokenSilently();
				config.headers = {
					...config.headers,
					Authorization: `Bearer ${token}`,
				};
			}
			const response : AxiosResponse = await axios(config);
			return response.data;
		}
        catch (error: any) {
			if (axios.isAxiosError(error) && error.response) {
				return error.response.data;
			}

			return (error as Error).message;
		}
	};

    
	return { makeRequest };
};
