import RequestList from "./RequestList";

export const AdministerRequestsView = () => {
	return (
		<>
			<h1>Vacation Requests </h1>
			<p>From this page, administrators can view all requests of all users.</p>
			<hr/>
			<RequestList />
		</>
	);
};

export default AdministerRequestsView;
