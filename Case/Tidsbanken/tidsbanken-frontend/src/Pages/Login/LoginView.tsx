import { LoginButton } from "../../components/buttons/LoginButton";

const LoginView = () => {
    return (
        <>
            <div className="login-container">
                <h1>Vacation Guardian</h1>
                <img
                    src="https://images.unsplash.com/photo-1473496169904-658ba7c44d8a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
					// Alternativ annet bilde (svart-hvitt)
					// https://images.unsplash.com/photo-1627721239209-4c7957dda555?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80
                    alt="vacation"
					className="login-picture"
                />
                <LoginButton />
            </div>
        </>
    );
};

export default LoginView;
