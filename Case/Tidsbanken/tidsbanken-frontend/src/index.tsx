import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import { BrowserRouter } from "react-router-dom";
import { Auth0ProviderWithHistory } from "./Auth0ProviderWithHistory";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import { Container } from "react-bootstrap";

ReactDOM.render(
	<Container>
		<BrowserRouter>
			<Auth0ProviderWithHistory>
				<React.StrictMode>
					<App />
				</React.StrictMode>
			</Auth0ProviderWithHistory>
		</BrowserRouter>
	</Container>,
	document.getElementById("root")
);
