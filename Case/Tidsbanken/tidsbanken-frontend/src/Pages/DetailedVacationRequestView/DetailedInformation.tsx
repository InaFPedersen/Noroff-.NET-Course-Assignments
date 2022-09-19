import { useEffect, useState } from "react";
import { toDateString } from "../../helperFunctions/toDate";
import { API } from "../../hooks/API";
import {
	selfReadUserDTO,
	selfReadVacationRequestDTO,
	Status,
	adminUpdateVacationStatusDTO,
	adminReadVacationRequestDTO,
} from "../../models/DTOs";
import { CommentSection } from "./CommentSection";
import { Button } from "react-bootstrap";

const DetailedInformation = () => {
	
	let [requestTitle, setRequestTitle] = useState("loading title...");
	let [startDate, setStartDate] = useState("");
	let [endDate, setEndDate] = useState("");
	let [requestStatus, setRequestStatus] = useState("Loading status...");

	let [statusId, setStatusId] = useState(0);
	let [requestOwnerId, setRequestOwnerId] = useState("");

	const [userData, setUserData] = useState<selfReadUserDTO>();
	let {
		ReadOtherUserById,
		SelfReadRequestById,
		GetLoggedInUser,
		AdminSetRequestStatus,
		AdminGetRequestStatus,
		AdminRequestReadById,
	} = API();

	useEffect(() => {
		loadResources();
	}, []);

	async function loadResources() {
		let user = await GetLoggedInUser();
		setUserData(user);
		await FetchRequestData(user.isAdmin === true);
	}
	const [requestOwner, setRequestOwnerName] = useState<string | undefined>(
		"Loading..."
	);
	async function fetchRequestOwner(requestOwnerId: string) {
		let data = await ReadOtherUserById(requestOwnerId);
		setRequestOwnerName(data.firstName + " " + data.lastName);
	}
	function isAdmin(): boolean {
		return userData?.isAdmin === true;
	}
	async function FetchRequestData(isAdmin: boolean) {
		const id: string = window.location.pathname.split("/")[2];

		if (isAdmin) {
			let _request = await AdminRequestReadById(id);
			SetData(_request);

			AdminGetRequestStatus(id).then((dto) => {
				setRequestStatus(dto.status);
				setStatusId(Number(dto.id));
			});
			fetchRequestOwner(_request.userId);
		} else {
			let _request = await SelfReadRequestById(id);
			SetData(_request);
			fetchRequestOwner(_request.userId);
		}
	}
	function SetData(
		data: selfReadVacationRequestDTO | adminReadVacationRequestDTO
	) {
		let title: string = data.title;
		if (title === undefined) {
			title = "You don't have permission to read this status.";
			return;
		}
		setRequestTitle(title);
		setStartDate(toDateString(data.startDate));
		setEndDate(toDateString(data.endDate));
		if (data as selfReadVacationRequestDTO) {
			setRequestStatus((data as selfReadVacationRequestDTO).status);
		}
		if (data as adminReadVacationRequestDTO) {
			setRequestOwnerId((data as adminReadVacationRequestDTO).userId);
		}
	}

	async function setStatus(status: Status) {
		let data: adminUpdateVacationStatusDTO = {
			id: Number(statusId),
			status: status,
			adminId: userData!.id,
			approvalTime: new Date(Date.now()).toJSON(),
		};
		await AdminSetRequestStatus(data);
		refresh();
	}
	// const navigateTo = useNavigate();
	// async function deleteThisRequest() {
	// 	await AdminDeleteRequest(Number(requestId));
	// 	navigateTo("/vacationRequestHistory");
	// }
	function adminFeatures() {
		if (!isAdmin()) {
			return <></>;
		}
		if (userData?.id === requestOwnerId || requestOwnerId === "") {
			return <></>;
		}
		return (
			<>
				{/*<button onClick={()=>deleteThisRequest()}>Delete request</button>*/}
				<Button
					variant="outline-secondary"
					onClick={() => setStatus("Approved")}
				>
					Approve
				</Button>
				<Button
					variant="outline-secondary"
					style={{ marginLeft: "15px" }}
					onClick={() => setStatus("Denied")}
				>
					Decline
				</Button>
			</>
		);
	}

	function refresh() {
		loadResources();
	}
	function owner() {
		if (
			requestOwner === "" ||
			requestOwner === undefined ||
			requestOwner === null
		) {
			return <></>;
		}
		return (
			<p>
				Request owner: <b>{requestOwner}</b>
			</p>
		);
	}
	return (
		<>
			<h2>{requestTitle}</h2>
			{owner()}
			<p>
				<b>Start Date: </b>
				{startDate}
			</p>
			<p>
				<b>End Date: </b>
				{endDate}
			</p>
			<p>
				<b>Status: </b>
				{requestStatus}
			</p>
			{adminFeatures()}
			<br />
			<br />
			<CommentSection />
		</>
	);
};

export default DetailedInformation;
