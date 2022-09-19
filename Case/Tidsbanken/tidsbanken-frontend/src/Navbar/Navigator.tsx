import { useAuth0 } from "@auth0/auth0-react";
import { Navbar, Container, Nav, NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";

import { LogoutButton } from "../components/buttons/LogoutButton";
import { API } from "../hooks/API";
import { useEffect, useState } from "react";
import { selfReadUserDTO } from "../models/DTOs";
import { ProfilePicture } from "../Pages/ProfilePage/ProfilePicture";

//Todo: Make it so that you do not have to click twize when screen is phone size
const Navigator = () => {
	const { isAuthenticated } = useAuth0();
	const { GetLoggedInUser } = API();
	const [userData, setUserData] = useState<selfReadUserDTO>();

	useEffect(() => {
		start();
	}, []);

	async function start() {
		let user = await GetLoggedInUser();
		setUserData(user);
		setDisplayData(user);
	}
	function isAdmin(): boolean {
		return userData?.isAdmin === true;
	}

	function setDisplayData(data: selfReadUserDTO): void {
		setProfilePicture(data.profilePicture);
	}
	const [profilePicture, setProfilePicture] = useState("loading");

	function adminMenu() {
		if (isAdmin())
			return (
				<>
					<NavDropdown.Divider />
					<NavDropdown.Item as={Link} to="/admin">
						Create Users
					</NavDropdown.Item>
					<NavDropdown.Item as={Link} to="/AdministerRequestsView">
						Administrate Vacation Requests
					</NavDropdown.Item>
				</>
			);
	}
	return (
		<Navbar bg="light" variant="light">
			<Container className="justify-content-between">
				<Navbar.Brand as={Link} to="/">
					<i className="bi bi-calendar-check-fill"></i>
					Vacation Guardian
				</Navbar.Brand>
				<Navbar.Toggle aria-controls="basic-navbar-nav" />
				{isAuthenticated && (
					<>
						<Navbar.Collapse
							id="basic-navbar-nav"
							className="right-aligned"
						>
							<Nav className="ml-auto">
								<NavDropdown
									title="Menu"
									id="basic-nav-dropdown"
								>
									<NavDropdown.Item as={Link} to="/dashboard">
										Dashboard
									</NavDropdown.Item>
									<NavDropdown.Item as={Link} to="/user">
										Profile
									</NavDropdown.Item>

									<NavDropdown.Item
										as={Link}
										to="/vacationRequestHistory"
									>
										My Vacation Request History
									</NavDropdown.Item>
									{adminMenu()}
									<NavDropdown.Divider />
									<NavDropdown.Item as={Link} to="/">
										<LogoutButton />
									</NavDropdown.Item>
								</NavDropdown>
							</Nav>
						</Navbar.Collapse>
						<Navbar.Brand as={Link} to="/user">
							<ProfilePicture
								profilePicture={profilePicture}
								alt={"Profile"}
								height={"60"}
								fontSize={"2"}
							/>
						</Navbar.Brand>
					</>
				)}
			</Container>
		</Navbar>
	);
};

export default Navigator;
