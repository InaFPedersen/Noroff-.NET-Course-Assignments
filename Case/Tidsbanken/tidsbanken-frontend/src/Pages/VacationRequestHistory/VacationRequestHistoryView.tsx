import VacationRequestHistoryList from "./VacationRequestHistoryList";

const VacationRequestHistoryView = () => {
	return (
		<>
			<h1>My Vacation Requests</h1>

			<p>These are your submitted vacation requests.</p>
			<hr></hr>
			<VacationRequestHistoryList />
		</>
	);
};

export default VacationRequestHistoryView;
