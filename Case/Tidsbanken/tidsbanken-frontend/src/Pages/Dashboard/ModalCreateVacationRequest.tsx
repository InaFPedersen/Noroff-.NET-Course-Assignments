
import { Button, Modal } from 'react-bootstrap';
import CreateVacationRequestForm from './CreateVacationRequestForm';
import { selfReadVacationRequestDTO } from '../../models/DTOs';

interface Props {
  show: boolean;
  onHide: () => void;
  sendDataToGrandParent: (request: selfReadVacationRequestDTO) => void;
}

const ModalCreateVacationRequest = ({onHide, show, sendDataToGrandParent}: Props) => {
  function close() {
    onHide(); 
    // props.onComplete();
  }
  // const sendDataToParent = (index: any) => {
  //   // console.log(index);
  //   sendDataToGrandParent(index);
  // }

  return (
        <Modal
          show={show}
          onHide={onHide}
          size="lg"
          aria-labelledby="contained-modal-title-vcenter"
          centered
        >
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">
            Create a Vacation Request
            </Modal.Title>
          </Modal.Header>
    
          <Modal.Body>
            <CreateVacationRequestForm onModalShow={close} sendDataToGrandParent={sendDataToGrandParent}/>
          </Modal.Body>
    
          <Modal.Footer>
            <Button onClick={close}>Close</Button>
          </Modal.Footer>
        </Modal>
      
  );
}

export default ModalCreateVacationRequest