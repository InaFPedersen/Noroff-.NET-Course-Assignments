import { ACTION_LOGIN_ATTEMPT, ACTION_LOGIN_SUCCESS, ACTION_LOGIN_ERROR, loginAttemptAction, loginSuccessAction, loginErrorAction } from "../actions/loginActions"
import { login } from "../../api/LoginAPI"

export const loginMiddleware = ({ dispatch }) => next => action => {
    next(action)

    console.log("loginMiddleware " + action.type)
    if (action.type === ACTION_LOGIN_ATTEMPT) {
        login(action.payload.username, action.payload.setTranslationCache)
            .then(profile => {

                dispatch(loginSuccessAction(profile, action.payload.navigator))
            })
            .catch(error => {
                dispatch(loginErrorAction(error))
            })
    }
    if (action.type === ACTION_LOGIN_SUCCESS) {
        console.log(action.payload.navigator)
        action.payload.navigator("/Translation/");
    }
    if (action.type === ACTION_LOGIN_ERROR) {
        console.error(action.payload)
    }
}