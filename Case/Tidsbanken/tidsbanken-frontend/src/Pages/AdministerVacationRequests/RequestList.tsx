import { useEffect, useState } from "react";
import { toDate } from "../../helperFunctions/toDate";
import { API } from "../../hooks/API";
import {
	adminReadVacationRequestDTO,
	readVacationStatusDTO,
	selfReadUserDTO,
} from "../../models/DTOs";
import { Form } from "react-bootstrap";
import { VacationRequestCard } from "../../components/VacationRequestCard";

const RequestList = () => {
	const [requests, setRequests] = useState<adminReadVacationRequestDTO[]>([]);
	const [userData, setUserData] = useState<selfReadUserDTO>();
	const { AdminReadAllRequests, AdminGetRequestStatus, GetLoggedInUser } =
		API();
	const [idStatusMapping, setIdStatusMapping] = useState<IdAndStatus[]>([]);
	const [hideMyRequests, setHideMyRequests] = useState(true);

	useEffect(() => {
		fetchAllData();
	}, []);

	async function fetchAllData() {
		GetLoggedInUser().then((user) => setUserData(user));
		let data = await AdminReadAllRequests();
		setRequests(data as adminReadVacationRequestDTO[]);

		let IDs: number[] = [];
		for (let i = 0; i < data.length; i++) {
			if (!IDs.includes(data[i].id)) {
				IDs.push(data[i].id);
			}
		}
		// fetch all statuses
		let promises: Promise<readVacationStatusDTO>[] = [];
		for (let i = 0; i < IDs.length; i++) {
			let _promise = AdminGetRequestStatus(IDs[i]);
			promises.push(_promise);
		}
		// Await all statuses and map them
		let mapping: IdAndStatus[] = [];
		for (let i = 0; i < promises.length; i++) {
			let _data = await promises[i];
			mapping.push({ id: IDs[i], status: _data.status });
		}
		// save the mapping in state
		setIdStatusMapping(mapping);
	}
	function formatList(data: adminReadVacationRequestDTO[]) {
		try {
			if (data === null || data === undefined) {
				return "Loading...";
			}
			if (data as adminReadVacationRequestDTO[]) {
				if (data.length === 0) {
					return "No data has been sent";
				}
				if (!hideMyRequests) {
					return data!.map(DtoToHtml);
				}

				return data!
					.filter((x) => x.userId !== userData?.id)
					.map(DtoToHtml);
			}
			return data;
		} catch {
			return "Network Error (caught)";
		}
	}

	function stringify() {
		let now = Date.now();
		return (
			<>
				<h1>Current and Future</h1>
				{formatList(
					requests.filter(
						(x) => toDate(x.endDate).setHours(0, 0, 0, 0) >= now
					).reverse()
				)}
				<br />
				<h1>Past Requests</h1>
				{formatList(
					requests.filter(
						(x) => new Date(x.endDate).setHours(0, 0, 0, 0) < now
					).reverse()
				)}
			</>
		);
	}
	function GetStatusOfId(id: number) {
		for (let o of idStatusMapping) {
			if (o.id === id) {
				return o.status;
			}
		}
		return "loading...";
	}

	function onCheckboxChange(event: any) {
		setHideMyRequests(event.target.checked);
	}
	function DtoToHtml(data: adminReadVacationRequestDTO) {
		let status = GetStatusOfId(data.id);

		return (
			<VacationRequestCard
				id={data.id}
				title={data.title}
				status={status}
				startDate={data.startDate}
				endDate={data.endDate}
			/>
		);
	}
	return (
		<>
			{/* Hide my requests */}
			{/* <input type="checkbox"
                onChange={onCheckboxChange}
                defaultChecked={true}
                style={{ width: 35, height: 35 }}
            /> */}
			{/* Test that this works before productions. If it doesn't, remove Form + Form.Check, and uncomment code above */}
			<Form>
				<Form.Check
					type="switch"
					id="custom-switch"
					label="Hide my requests"
					onChange={onCheckboxChange}
					defaultChecked={true}
				/>
			</Form>

			<hr />
			<div> {stringify()}</div>
		</>
	);
};

export default RequestList;

interface IdAndStatus {
	id: number;
	status: string;
}
