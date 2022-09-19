import { useAuth0 } from "@auth0/auth0-react";
import { AxiosRequestConfig, Method } from "axios";
import { useEnv } from "../../context/env.context";
import { useAxiosConfig } from "./AxiosConfig";

export const Generics = () => {
	// Public
	async function Get<T>(endpoint: String) : Promise<T> {
		return await GenericAction(endpoint, "GET");
	}
	async function Post<TInput, TOutput>(endpoint: String, argument: TInput) : Promise<TOutput> {
		return await GenericSend<TInput, TOutput>(endpoint, "POST", argument);
	}
	async function Put<TInput, TOutput>(endpoint: String, argument: TInput) : Promise<TOutput> {
		return await GenericSend<TInput, TOutput>(endpoint, "PUT", argument);
	}
	async function Delete<TOutput>(endpoint: String) : Promise<TOutput> {
		
		const config: AxiosRequestConfig = {
			url: apiServerUrl + "/" + endpoint,
			method: "DELETE",
			headers: {
				"content-type": "application/json",
			}
		};
		const data: any = await makeRequest(config, isAuthenticated);
		

		return data;
	}

	// Private
	const { isAuthenticated } = useAuth0();
	const { apiServerUrl } = useEnv();
	const { makeRequest } = useAxiosConfig();

	async function GenericAction<T>(endpoint: String, requestType: Method) {

		const config: AxiosRequestConfig = {
			url: apiServerUrl + "/" + endpoint,
			method: requestType,
			headers: {
				"content-type": "application/json",
			}
		};
		const data: T = await makeRequest<T>(config, isAuthenticated);
		

		return data;
	}
	async function GenericSend<TInput, TOutput>(endpoint: String, requestType: Method, input: TInput) : Promise<TOutput> {

		const config: AxiosRequestConfig = {
			url: apiServerUrl + "/" + endpoint,
			method: requestType,
			headers: {
				"content-type": "application/json",
			},
			data: JSON.stringify(input),
		};

		const data = await makeRequest(config, isAuthenticated);
		return data;
	}

	return {Get, Put, Post, Delete};
}