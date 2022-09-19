// Types (Completed)

export type Status = "Pending" | "Approved" | "Denied";

// All DTOs should have the same name/fields as the backend DTOs, but with camelCase instead of PascalCase.

// User DTOs (Completed)

export interface selfReadUserDTO {
	id: string;
	profilePicture: string;
	firstName: string;
	lastName: string;
	email: string;
	isAdmin: boolean;
	phoneNumber: number;
}
export interface adminReadUserDTO {
	id: string;
	profilePicture: string;
	firstName: string;
	lastName: string;
	email: string;
	isAdmin: boolean;
	phoneNumber: number;
}
export interface selfUpdateUserDTO {
	id: string;
	profilePicture: string;
	firstName: string;
	lastName: string;
	email: string;
}
export interface adminUpdateUserDTO {
	id: string;
	profilePicture: string;
	firstName: string;
	lastName: string;
	email: string;
	isAdmin: boolean;
	phoneNumber: number;
}
export interface adminCreateUserDTO {
	profilePicture: string;
	firstName: string;
	lastName: string;
	email: string;
	isAdmin: boolean;
	phoneNumber: number;
}
export interface selfReadOtherUserDTO {
	profilePicture: string;
	firstName: string;
	lastName: string;
}

// VacationRequest DTOs (Completed)

export interface selfCreateVacationRequestDTO {
	title: string;
	startDate: string; // Date
	endDate: string; // Date
	userId: string;
}
export interface selfReadVacationRequestDTO {
	id: number;
	userId: string;
	title: string;
	startDate: string; // Date
	endDate: string; // Date
	status: string;
	vacationStatusId: number;
}
export interface selfUpdateVacationRequestDTO {
	id: number;
	title: string;
	startDate: string; // Date
	endDate: string; // Date
}
export interface adminReadVacationRequestDTO {
	id: number;
	title: string;
	startDate: string; // Date
	endDate: string; // Date
	vacationStatusId: number;
	userId: string;
}

// VacationStatus DTOs (Completed)
export interface readVacationStatusDTO {
	id: string;
	status: Status;
	adminId: boolean;
	approvalTime: string; // Date
}

export interface adminUpdateVacationStatusDTO {
	id: number;
	status: Status;
	adminId: string;
	approvalTime: string; // Date
}

// Comment

export interface createCommentDTO {
	message: string;
	authorId: string;
	vacationRequestId: number;
}
export interface updateCommentDTO {
	id: number;
	message: string;
}
export interface readCommentDTO {
	id: number;
	creationDate: string;
	lastTimeEdited: string;
	message: string;
	authorId: string;
	vacationRequestId: number;
}
