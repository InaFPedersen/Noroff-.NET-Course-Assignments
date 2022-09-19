import { useEffect, useState } from "react";
import { VacationRequestCard } from "../../components/VacationRequestCard";
import { toDate } from "../../helperFunctions/toDate";
import { API } from "../../hooks/API";
import { selfReadVacationRequestDTO } from "../../models/DTOs";

const VacationRequestHistoryList = () => {
	//Each listed request should redirect to detailed view of that request!!
	//Fetch approved request
	//show approved request as a list of clickable elements

	const [requests, setRequests] = useState<selfReadVacationRequestDTO[]>([]);
	const { SelfRequestReadAll } = API();
	useEffect(() => {
		SelfRequestReadAll().then((data) => {
			setRequests(data as selfReadVacationRequestDTO[]);
		});
	}, []);
	function formatList(data: selfReadVacationRequestDTO[]) {
		try {
			if (data === null || data === undefined) {
				return "Loading...";
			}
			if (data as selfReadVacationRequestDTO[]) {
				if (data.length === 0) {
					return "No data has been sent";
				}
				return data!.map((dto) => {
					return (
						<VacationRequestCard
							key={dto.id}
							id={dto.id}
							title={dto.title}
							status={dto.status}
							startDate={dto.startDate}
							endDate={dto.endDate}
						/>
					);
				});
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
				<h2>Current and Future</h2>
				{formatList(
					requests.filter(
						(x) =>
							toDate(x.endDate).setHours(0, 0, 0, 0) >=
							now - 24 * 60 * 60 * 1000
					).reverse()
				)}
				<br />
				<hr></hr>
				<h2>Past Requests</h2>
				{formatList(
					requests.filter(
						(x) =>
							new Date(x.endDate).setHours(0, 0, 0, 0) <
							now - 24 * 60 * 60 * 1000
					).reverse()
				)}
			</>
		);
	}

	return (
		<>
			<div>{stringify()}</div>
		</>
	);
};

export default VacationRequestHistoryList;
