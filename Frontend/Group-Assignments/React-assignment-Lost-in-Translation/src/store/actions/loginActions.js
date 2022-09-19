export const ACTION_LOGIN_ATTEMPT = "[login] ATTEMPT"
export const ACTION_LOGIN_SUCCESS = "[login] SUCCESS"
export const ACTION_LOGIN_ERROR = "[login] ERROR"


export const loginAttemptAction = (username, navigator, setTranslationCache) => ({
    type: ACTION_LOGIN_ATTEMPT,
    payload: {username: username, navigator: navigator, setTranslationCache: setTranslationCache}
})

export const loginSuccessAction = (profile, navigator) => ({
    type: ACTION_LOGIN_SUCCESS,
    payload: {profile: profile, navigator: navigator}
})

export const loginErrorAction = error => ({
    type: ACTION_LOGIN_ERROR,
    payload:error
})