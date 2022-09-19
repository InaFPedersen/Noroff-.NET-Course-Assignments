import {BASE_URL, API_KEY} from "./";

export async function apiUserLoginRegister(action = "login", username, password) {
    try {
        const config = {
            method: "POST",
            headers: {
                "API-Key": API_KEY,
                "content-type": "application/json"
            },
            body: JSON.stringify({
                user: {
                    username: username,
                    password: password
                }
            })
        }
    
        const response = await fetch(`${BASE_URL}/users/${action}`, config)

        const {success, data, error = "An error occured when tried to logging in"} = await response.json()
        
        if(!success){
            throw new Error(error)
        }
        return [null, data]
    }
            catch (error){
                return [error.message, null]
            }
}