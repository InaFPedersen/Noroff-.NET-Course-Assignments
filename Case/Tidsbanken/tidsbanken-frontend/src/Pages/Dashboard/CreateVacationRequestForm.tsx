import { useState } from "react";
import ReactDatePicker from "react-datepicker";

import { API } from "../../hooks/API";
import {
	selfCreateVacationRequestDTO,
	selfReadVacationRequestDTO,
} from "../../models/DTOs";
import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "react-bootstrap";

interface Props {
	sendDataToGrandParent: (request: selfReadVacationRequestDTO) => void;
	onModalShow: () => void;
}

const CreateVacationRequestForm = ({
	sendDataToGrandParent,
	onModalShow,
}: Props) => {
	const { SelfCreateVacationRequest } = API();

	const { user } = useAuth0();
	// New Event
	const [title, setTitle] = useState("");
	const [startDate, setStartDate] = useState(new Date());
	const [endDate, setEndDate] = useState(new Date());

	const createNewVacationRequest = async () => {
		//Send vacation request to requestView & request history?
		//add status pending on to the request
		//comment bind to the request
		//store vrequest in database --> database list the vRequest in request view
		if (title === "") {
			alert("You must enter a title.");
			return;
		}

		if (isPastOrToday(startDate)) {
			alert("Invalid start date. Request must be later than today.");
			return;
		}

		if (isPastOrToday(endDate)) {
			alert("Invalid end date. Request must be later than today.");
			return;
		}

		let newEvent: selfCreateVacationRequestDTO = {
			title: title,
			startDate: startDate.toJSON(),
			endDate: endDate.toJSON(),
			userId: user!.sub!,
		};

		const newRequest = await SelfCreateVacationRequest(newEvent);
		sendDataToGrandParent(newRequest);
		onModalShow();
	};

	const isPastOrToday = (date: Date) => {
		const today = new Date();
		return (
			date.getFullYear() <= today.getFullYear() &&
			date.getMonth() <= today.getMonth() &&
			date.getDate() <= today.getDate()
		);
	};

	return (
		<>
			<label>Title: </label>
			<input
				type="text"
				placeholder="Enter a title"
				value={title}
				onChange={(e) => setTitle(e.target.value)}
			/>

			<label>Start Date: </label>
			<ReactDatePicker
				placeholderText="Start Date"
				selected={startDate}
				onChange={(inputDate: Date) => setStartDate(inputDate)}
			/>
			<label>End Date: </label>
			<ReactDatePicker
				placeholderText="End Date"
				selected={endDate}
				onChange={(date: Date) => setEndDate(date)}
			/>

			<div className="button-container">
				<Button
					variant="outline-primary"
					style={{ marginTop: "10px" }}
					className="create-btn"
					type="submit"
					onClick={createNewVacationRequest}
				>
					Create new request
				</Button>
			</div>
		</>
	);
};

export default CreateVacationRequestForm;
