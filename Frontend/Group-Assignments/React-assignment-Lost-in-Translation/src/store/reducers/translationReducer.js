import { ACTION_TRANSLATION_GET, ACTION_TRANSLATION_RESET } from "../actions/translationActions"


const initialState = {
    error: ''
}

export const translationReducer = (state = initialState, action) => {
    switch (action.type) {
        case ACTION_TRANSLATION_GET:
            return state;
        case ACTION_TRANSLATION_RESET:
            return state;
        default:
            return state;

    }
}