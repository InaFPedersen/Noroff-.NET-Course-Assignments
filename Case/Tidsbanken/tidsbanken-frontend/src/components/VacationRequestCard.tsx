import { useNavigate } from "react-router-dom";
import { statusStyle } from "../helperFunctions/StatusStyles";
import { toDateString } from "../helperFunctions/toDate";

interface RequestProps {
	id: number;
	title: string;
	status: string;
	startDate: string;
	endDate: string;
}

export const VacationRequestCard = ({
	id,
	title,
	status,
	startDate,
	endDate,
}: RequestProps) => {
	const navigateTo = useNavigate();

	function navigateToDetailedView(requestId: string) {
		navigateTo("/requestDetails/" + requestId);
	}
	return (
		<div className="card" style={{ width: "18rem" }}>
			<h2 className="card-header" style={statusStyle(status)}>
				{title}
			</h2>
			<div className="card-body">
				<p className="card-text">
					Start date: <b>{toDateString(startDate)}</b>
				</p>
				<p className="card-text">
					End date: <b>{toDateString(endDate)}</b>
				</p>
				<p className="card-text">
					Status: <b>{status}</b>
				</p>
				<button
					onClick={() => navigateToDetailedView(String(id))}
					className="btn btn-primary"
				>
					Details
				</button>
			</div>
		</div>
	);
};
