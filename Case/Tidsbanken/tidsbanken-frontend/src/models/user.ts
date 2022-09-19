import { VacationRequest } from "./vacationRequest";

export interface User {
	id: string;
	firstName: string;
	lastName: string;
	email: string;
	isAdmin: boolean;
	phoneNumber: string;
	vacationRequests: VacationRequest[];
}
