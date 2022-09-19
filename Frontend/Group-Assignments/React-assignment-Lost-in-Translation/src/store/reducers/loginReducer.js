import { ACTION_LOGIN_ATTEMPT, ACTION_LOGIN_SUCCESS, ACTION_LOGIN_ERROR } from "../actions/loginActions"


const initialState = {
    loginError: ''
}

export const loginReducer = (state = initialState, action) => {
    switch (action.type) {
        case ACTION_LOGIN_ATTEMPT:
            return {
                ...state,
                loginError: ''
            }

        case ACTION_LOGIN_SUCCESS:
            return {
                ...initialState
            }

        case ACTION_LOGIN_ERROR:
            return {
                ...state,
                loginError: action.payload
            }

        default:
            return state;

    }
}