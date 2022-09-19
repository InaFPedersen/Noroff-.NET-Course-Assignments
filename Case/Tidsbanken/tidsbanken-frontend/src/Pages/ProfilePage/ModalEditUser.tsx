import UserForm from "./UserComponents/UserForm";
import { Modal, Button } from "react-bootstrap";
import { selfReadUserDTO } from "../../models/DTOs";

interface EditProps {
	show: boolean;
	onHide: () => void;
	user: selfReadUserDTO | undefined;
}

const ModalEditUser = ({ show, onHide, user }: EditProps) => {
	return (
		<Modal
			show={show}
			onHide={onHide}
			// size="lg"
			aria-labelledby="contained-modal-title-vcenter"
			centered
		>
			<Modal.Header closeButton>
				<Modal.Title id="contained-modal-title-vcenter">
					Update User Settings
				</Modal.Title>
			</Modal.Header>

			<Modal.Body>
				<UserForm user={user} />
			</Modal.Body>

			<Modal.Footer>
				<Button onClick={onHide}>Close</Button>
			</Modal.Footer>
		</Modal>
	);
};

export default ModalEditUser;
