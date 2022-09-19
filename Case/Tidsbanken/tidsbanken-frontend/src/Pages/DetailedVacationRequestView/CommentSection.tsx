import { useEffect, useState } from "react";
import { toDateString } from "../../helperFunctions/toDate";
import { API } from "../../hooks/API";
import {
	selfReadUserDTO,
	readCommentDTO,
	createCommentDTO,
} from "../../models/DTOs";
import { Button } from "react-bootstrap";
export const CommentSection = () => {
	const {
		ReadOtherUserById,
		GetLoggedInUser,
		ReadAllComments,
		CreateComment,
		DeleteComment,
	} = API();
	const [requestId, setRequestId] = useState("");
	const [comments, setComments] = useState<readCommentDTO[]>([]);
	const [userNames, setUserNames] = useState<userIdAndName[]>([]);
	const [newComment, setNewComment] = useState("");
	const [userData, setUserData] = useState<selfReadUserDTO>();

	useEffect(() => {
		loadComments();
	}, []);

	async function loadComments() {

		let user = await GetLoggedInUser();
		setUserData(user);
		const id: string = window.location.pathname.split("/")[2];
		setRequestId(id);

		let _comments: readCommentDTO[] = await ReadAllComments(id);
		setComments(_comments);

		const users = [...userNames];

		for (let c of _comments) {
			if (users.filter((x) => x.id === c.authorId).length !== 0) {
				continue; // Avoid adding duplicates
			}
			const author = await ReadOtherUserById(c.authorId);
			users.push({
				id: c.authorId,
				name: author.firstName + " " + author.lastName,
			});
		}
		setUserNames(users);
	}

	function refresh() {
		loadComments();
	}
	function isAdmin(): boolean {
		return userData?.isAdmin === true;
	}

	function getDisplayedName(userId: string) {
		for (let i = 0; i < userNames.length; i++) {
			if (userNames[i].id === userId) {
				return userNames[i].name;
			}
		}
		return "unknown user";
	}
	async function deleteComment(commentId: number) {
		await DeleteComment(commentId);
		refresh();
	}

	function deleteButton(x: readCommentDTO) {
		// Only the comment owner or admin can delete a comment.
		if (isAdmin() || x.authorId === userData?.id) {
			return (
				<>
					<Button
						variant="secondary"
						onClick={() => deleteComment(x.id)}
					>
						Delete
					</Button>
				</>
			);
		}
		return <></>;
	}
	async function submitNewComment() {
		if (userData === undefined) {
			alert("User is not authenticated");
			return;
		}
		if (newComment === undefined || newComment === "") {
			alert("Comment text shouldn't be empty");
			return;
		}
		let comment: createCommentDTO = {
			message: newComment,
			authorId: userData!.id,
			vacationRequestId: Number(requestId),
		};
		await CreateComment(comment);
		refresh();
	}
	function formatComments() {
		if (comments.map == undefined) {
			return <></>;
		}
		return comments.map((x) => {
			let name: string = getDisplayedName(x.authorId);
			return (
				<div key={x.id}>
					<hr />
					<p>
						On {toDateString(x.creationDate)}, <b>{name}</b> wrote:
					</p>
					<p>"{x.message}"</p>
					{deleteButton(x)}
				</div>
			);
		});
	}
	if (comments.map == undefined) {
		return <>You don't have premission to view this comment section.</>;
	}
	return (
		<>
			<h2>Comments</h2>
			{formatComments()}
			<hr />
			<input
				type="text"
				placeholder="Add a comment..."
				value={newComment}
				onChange={(e) => setNewComment(e.target.value)}
				style={{ width: 500, height: 50 }}
			/>
			<Button
				style={{ marginTop: "10px" }}
				variant="secondary"
				onClick={submitNewComment}
			>
				Post Comment
			</Button>
		</>
	);
};

interface userIdAndName {
	id: string;
	name: string;
}
