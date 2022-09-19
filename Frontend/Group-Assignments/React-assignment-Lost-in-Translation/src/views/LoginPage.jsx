
import { useState, useEffect } from 'react'
import { useSelector } from 'react-redux';
import { useDispatch } from 'react-redux';
import { loginAttemptAction } from '../store/actions/loginActions';
import { useNavigate } from 'react-router-dom';
import { getTranslations } from '../api/LoginAPI';

export function LoginPage(props) {
    
    const navigateTo = useNavigate();
    if (props.username === ""){
        navigateTo("/")
    }

    const dispatch = useDispatch();
    
    let [usernameField, setFieldValue] = useState("");
    

    const tryLogin = (event) => {
        console.log("Try login")
        event.preventDefault()
        dispatch(loginAttemptAction(usernameField, navigateTo, props.setTranslations))
        props.setUsername(usernameField);
    }

    return (
        <div>
            <h2>
                Login page. {props.username}
            </h2>
            <br />

            <input type="text" onChange={(event) => setFieldValue(event.target.value)} />
            <button onClick={tryLogin}>Login</button>

        </div>
    )
}