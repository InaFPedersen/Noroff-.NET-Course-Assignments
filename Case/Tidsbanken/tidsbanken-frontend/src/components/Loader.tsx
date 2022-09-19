export const Loader = () => {
	const loadingImg = "https://cdn.auth0.com/blog/hello-auth0/loader.svg";

	return (
		<div>
			<img src={loadingImg} alt="Loading..." height="100px" />
		</div>
	);
};
