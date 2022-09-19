import { applyMiddleware } from "redux";
import { loginMiddleware } from "./loginMiddleware";
import {translationMiddleware} from "./translationMiddleware"
export default applyMiddleware(
    loginMiddleware,
    translationMiddleware
)
