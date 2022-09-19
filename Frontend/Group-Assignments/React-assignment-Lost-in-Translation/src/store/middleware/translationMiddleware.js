import { ACTION_TRANSLATION_GET, ACTION_TRANSLATION_RESET } from "../actions/translationActions"
import { getTranslations, setTranslations } from "../../api/LoginAPI"
export const translationMiddleware = ({ dispatch }) => next =>  async action => {
    next(action)

    console.log("translation Middleware " + action.type)
    if (action.type === ACTION_TRANSLATION_GET) {
        const output = await getTranslations(action.payload.username);
        action.payload.setTranslations(output);
    }
    if (action.type === ACTION_TRANSLATION_RESET){
        const output = await (setTranslations(action.payload.username, new Array(10).fill("")));
    }
    
}
export default translationMiddleware;