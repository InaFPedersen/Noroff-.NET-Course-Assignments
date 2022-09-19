export const ACTION_TRANSLATION_GET = "[trans] GET"
export const ACTION_TRANSLATION_RESET = "[trans] RESET"

export const getTranslations = (username, setTranslations) => ({
    type: ACTION_TRANSLATION_GET,
    payload: {username: username, setTranslations: setTranslations}
})

export const resetTranslations = (username) => ({
    type: ACTION_TRANSLATION_RESET,
    payload: {username: username}
})

