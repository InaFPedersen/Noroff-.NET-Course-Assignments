import { useState, useEffect } from "react";
import { Button } from "react-bootstrap";
import ModalCreateVacationRequest from "./ModalCreateVacationRequest";
import MyCalendar from "./MyCalendar";
import { selfReadVacationRequestDTO } from "../../models/DTOs";
import { API } from "../../hooks/API";

const DashboardView = () => {
	const [modalShow, setModalShow] = useState(false);

	const [allEvents, setAllEvent] = useState<selfReadVacationRequestDTO[]>([]);
	const sendDataToGrandParent = (index: any) => {
		setAllEvent((allEvents) => [...allEvents, index]);
	};

	const { SelfRequestReadAll, SelfReadAllApproved } = API();

	useEffect(() => {
		loadEvents();
	}, []);

	async function loadEvents() {
		var myRequestsPromise = SelfRequestReadAll();
		var approvedPromise = SelfReadAllApproved();
		var myRequests: selfReadVacationRequestDTO[] = await myRequestsPromise;
		var approved: selfReadVacationRequestDTO[] = await approvedPromise;
		var all = [...myRequests, ...approved];
		var uniqueRequests: selfReadVacationRequestDTO[] = [];
		for (var r of all) {
			if (uniqueRequests.map((x) => x.id).includes(r.id)) {
				continue;
			}
			uniqueRequests.push(r);
		}
		setAllEvent(uniqueRequests);
	}

	return (
		<>
			<h1>Vacation Calendar</h1>

			<div className="button-container">
				<Button
					variant="outline-secondary"
					onClick={() => setModalShow(true)}
				>
					Create Vacation Request
				</Button>
			</div>

			<ModalCreateVacationRequest
				show={modalShow}
				onHide={() => setModalShow(false)}
				sendDataToGrandParent={sendDataToGrandParent}
			/>

			<MyCalendar allEvents={allEvents} />
		</>
	);
};

export default DashboardView;
