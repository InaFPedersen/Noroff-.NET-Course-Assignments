import AdminForm from "./AdminForm";

const AdminView = () => {
	return (<>
		<h2>Create a new user</h2>
		<p>Only administrators are allowed to create new users.</p>
		<hr/>
		<AdminForm />

	</>);
};

export default AdminView;
