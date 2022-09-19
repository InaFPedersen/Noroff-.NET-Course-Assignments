export enum AccessControlLevel {
	PUBLIC = "public",
	PROTECTED = "requires-authentication",
	RBAC = "requires-role-permission",
	CORS = "requires-cors-allowed-method",
}
