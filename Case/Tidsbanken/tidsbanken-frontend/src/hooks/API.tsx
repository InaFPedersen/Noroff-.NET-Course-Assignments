import { Generics } from "./apiDependencies/Generics";
import * as types from "../models/DTOs";

// SPECIFIC IMPLEMENTATIONS (TODO)
export const API = () => {
	const generics = Generics();

	// Self User
	async function GetLoggedInUser(): Promise<types.selfReadUserDTO> {
		return await generics.Get("User/");
	}

	async function ReadOtherUserById(
		id: string | number
	): Promise<types.selfReadOtherUserDTO> {
		return await generics.Get("User/ReadById/" + id);
	}
	async function SelfDeleteUser(selfId: string) {
		/* TODO? */
	}

	async function SelfUpdateUser(
		newData: types.selfUpdateUserDTO
	): Promise<any> {
		return await generics.Put("User/Update", newData);
	}

	async function GetRequestsOfUser(
		userId: string
	): Promise<types.selfReadVacationRequestDTO[]> {
		return await generics.Get("User/GetRequests/" + userId);
	}

	// Admin User
	async function AdminCreateUser(
		details: types.adminCreateUserDTO
	): Promise<any> {
		return await generics.Post("Admin/User/Create", details);
	}

	async function AdminGetAllUsers(): Promise<types.adminReadUserDTO[]> {
		return await generics.Get<types.adminReadUserDTO[]>(
			"Admin/User/ReadAll"
		);
	}
	async function AdminReadUserById(
		userId: string
	): Promise<types.adminReadUserDTO> {
		return await generics.Get<types.adminReadUserDTO>(
			"Admin/User/ReadById/" + userId
		);
	}
	async function AdminDeleteUser(userId: string) {
		return await generics.Delete("Admin/User/Delete/" + userId);
	}
	async function AdminUpdateUser(data: types.adminUpdateUserDTO) {
		return await generics.Put("Admin/User/Update", data);
	}
	async function AdminGetRequestsOfUser(
		userId: string
	): Promise<types.adminReadUserDTO[]> {
		return await generics.Get("Admin/User/GetRequests/" + userId);
	}

	// Admin VacationRequest
	async function AdminRequestReadById(
		id: string | number
	): Promise<types.adminReadVacationRequestDTO> {
		return await generics.Get<types.adminReadVacationRequestDTO>(
			"Admin/Request/ReadById/" + id
		);
	}
	async function AdminReadAllRequests(): Promise<
		types.adminReadVacationRequestDTO[]
	> {
		return await generics.Get("Admin/Request/ReadAll");
	}
	async function AdminDeleteRequest(requestId: number) {
		return await generics.Delete("Admin/Request/Delete/" + requestId);
	}
	async function AdminGetRequestStatus(requestId: number | string) {
		return await generics.Get<types.readVacationStatusDTO>(
			"Admin/Request/GetStatus/" + requestId
		);
	}
	async function AdminSetRequestStatus(
		status: types.adminUpdateVacationStatusDTO
	) {
		return await generics.Put("Admin/Request/SetStatus", status);
	}

	// Self VacationRequest
	async function SelfRequestReadAll(): Promise<
		types.selfReadVacationRequestDTO[]
	> {
		return await generics.Get<types.selfReadVacationRequestDTO[]>(
			"Request/ReadAll"
		);
	}

	async function SelfReadAllApproved(): Promise<
		types.selfReadVacationRequestDTO[]
	> {
		return await generics.Get<types.selfReadVacationRequestDTO[]>(
			"Request/ReadAllApproved"
		);
	}
	async function SelfCreateVacationRequest(
		data: types.selfCreateVacationRequestDTO
	): Promise<types.selfReadVacationRequestDTO> {
		return await generics.Post("Request/Create", data);
	}

	async function SelfReadRequestById(
		id: string | number
	): Promise<types.selfReadVacationRequestDTO> {
		return await generics.Get("Request/ReadById/" + id);
	}

	async function SelfUpdateRequest(
		data: types.selfUpdateVacationRequestDTO
	): Promise<any> {
		return await generics.Put("Request/Update", data);
	}

	async function SelfChangePassword(data: string): Promise<string> {
		return await generics.Post("User/UpdatePassword/" + data, null);
	}

	async function SelfGetRequestStatus(
		requestId: number | string
	): Promise<types.readVacationStatusDTO> {
		return await generics.Get("Request/GetStatus/" + requestId);
	}

	// Comments

	async function ReadAllComments(
		requestId: number | string
	): Promise<types.readCommentDTO[]> {
		return await generics.Get("Comments/ReadAll/" + requestId);
	}
	async function ReadCommentById(
		commentId: number | string
	): Promise<types.readCommentDTO> {
		return await generics.Get("Comments/ReadById/" + commentId);
	}
	async function CreateComment(data: types.createCommentDTO): Promise<any> {
		return await generics.Post("Comments/Create", data);
	}
	async function UpdateComment(data: types.updateCommentDTO): Promise<any> {
		return await generics.Put("Comments/Update", data);
	}
	async function DeleteComment(commentId: number | string): Promise<any> {
		return await generics.Delete("Comments/Delete/" + commentId);
	}
	return {
		// comment
		ReadAllComments,
		ReadCommentById,
		CreateComment,
		UpdateComment,
		DeleteComment,

		// Admin user
		AdminGetAllUsers,
		AdminCreateUser,
		AdminReadUserById,
		AdminDeleteUser,
		AdminUpdateUser,
		AdminGetRequestsOfUser,

		// Admin request
		AdminRequestReadById,
		AdminReadAllRequests,
		AdminDeleteRequest,
		AdminGetRequestStatus,
		AdminSetRequestStatus,

		// Self user
		GetLoggedInUser,
		ReadOtherUserById,
		SelfDeleteUser,
		SelfUpdateUser,
		GetRequestsOfUser,
		SelfChangePassword,

		// Self request
		SelfRequestReadAll,
		SelfReadAllApproved,

		SelfCreateVacationRequest,
		SelfReadRequestById,
		SelfUpdateRequest,
		SelfGetRequestStatus,
	};
};
