import "./App.css";
import { Routes, Route } from "react-router-dom";
import LoginView from "./Pages/Login/LoginView";
import UserView from "./Pages/ProfilePage/UserView";
import DashboardView from "./Pages/Dashboard/DashboardView";
import AdminView from "./Pages/CreateUser/AdminView";
import { useAuth0 } from "@auth0/auth0-react";
import { Loader } from "./components/Loader";
import VacationRequestHistoryView from "./Pages/VacationRequestHistory/VacationRequestHistoryView";
import NavbarView from "./Navbar/NavbarView";
import { RequireAuth } from "./RequireAuth";
import DetailedRequestView from "./Pages/DetailedVacationRequestView/DetailedRequestView";
import { AdministerRequestsView } from "./Pages/AdministerVacationRequests/AdministerRequestsView";

function App() {
	const { isLoading, error, isAuthenticated } = useAuth0();

	if (isLoading) {
		return (
			<div>
				<Loader />
			</div>
		);
	}
	if (error) {
		return <div>Oops... {error.message}</div>;
	}

	return (
		<>
			<NavbarView />
			<Routes>
				<Route
					path="/"
					element={
						isAuthenticated ? <DashboardView /> : <LoginView />
					}
				></Route>
				<Route
					path="/user"
					element={
						<RequireAuth>
							<UserView />
						</RequireAuth>
					}
				></Route>
				<Route
					path="/dashboard"
					element={
						<RequireAuth>
							<DashboardView />
						</RequireAuth>
					}
				></Route>
				<Route
					path="/vacationRequestHistory"
					element={
						<RequireAuth>
							<VacationRequestHistoryView />
						</RequireAuth>
					}
				></Route>
				<Route
					path="/AdministerRequestsView"
					element={
						<RequireAuth>
							<AdministerRequestsView />
						</RequireAuth>
					}
				></Route>
				<Route
					path="/requestDetails/*"
					element={
						<RequireAuth>
							<DetailedRequestView />
						</RequireAuth>
					}
				></Route>
				<Route
					path="/admin"
					element={
						<RequireAuth>
							<AdminView />
						</RequireAuth>
					}
				></Route>
			</Routes>
		</>
	);
}

export default App;
