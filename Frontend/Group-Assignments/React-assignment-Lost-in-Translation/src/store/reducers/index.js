import { combineReducers } from "redux";
import { loginReducer } from "./loginReducer";
import { translationReducer } from "./translationReducer";
const appReducer = combineReducers({
    loginReducer,
    translationReducer
})

export default appReducer;