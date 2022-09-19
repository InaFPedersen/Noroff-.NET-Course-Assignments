import { useEffect, useState } from "react";

interface PictureProps {
	profilePicture: string;
	alt: string;
	height: string;
	fontSize: string;
}

export function ProfilePicture({
	profilePicture,
	alt,
	height,
	fontSize,
}: PictureProps) {
	const [error, setError] = useState<boolean>();

	useEffect(() => {
		setError(false);
	}, []);

	const handleError = () => {
		console.log(profilePicture);
		setError(true);
	};

	if (error) {
		return (
			<i
				className="bi bi-person-circle"
				style={{ fontSize: fontSize + "rem" }}
			></i>
		);
	}

	if (profilePicture !== "loading") {
		return (
			<img
				src={profilePicture}
				alt={alt}
				style={{ height: height + "px" }}
				onError={handleError}
			/>
		);
	}
	return <></>;
}
