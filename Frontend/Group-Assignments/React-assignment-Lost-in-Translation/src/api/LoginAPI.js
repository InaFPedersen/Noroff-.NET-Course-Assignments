
const API_URL = "https://srh-rest-api-2.herokuapp.com/translations"
const API_KEY = "NIqabBeHBlpINB8pPqrvuaS3Du9SI_oGd_AJ4mtGsspSiU_BXe5o_uW_bNZuPS1wIWvJZfaSfPk2RBDxlED5mQ";

export async function login(username, setTranslationCache) {
    const users = await getUser(username);
    if (users === undefined || users.length === 0) {
        console.log("Creating user");
        return await registerNewUser(username);
    }
    if (setTranslationCache !== undefined){
        await getTranslations(username, setTranslationCache);
    }
    else{
        console.log(setTranslationCache)
    }
    return users[0];
}
function registerNewUser(userName) {
    // Creates a new blank user. NB: Does not check whether the user already exists.
    console.log("Registering user '" + userName + "'")
    const requestOptions = {
        method: "POST",

        headers: {
            "X-API-KEY": API_KEY,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            username: userName,
            translations: new Array(10).fill("")
        })
    }
    const registerEndpoint = API_URL;
    return fetch(registerEndpoint, requestOptions)
        .then(response => response.json())
        .then(data => data.data)

}
export async function addTranslation(username, text, callback){

    let newTranslations = new Array(10);
    newTranslations[0] = text;
    let old = await getTranslations(username);
    for(let i = 1; i < 10; i++){
        newTranslations[i] = old[i-1];
    }
    await setTranslations(username, newTranslations, callback);
    
}
export async function setTranslations(userName, translations, callback) {
    // this has not been tested
    const requestOptions = {
        method: "PATCH",

        headers: {
            "X-API-KEY": API_KEY,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            username: userName,
            translations: translations
        })
    }
    const user = await getUser(userName)
    const id = user[0].id;
    const registerEndpoint = API_URL + "/"+id;
    const output =  await (fetch(registerEndpoint, requestOptions)
        .then(response => response.json())
        .then(data => data.data)
    )
    if (callback !== undefined){
        callback();
    }
    return output;
}

export async function getAllUsers() {
    return await fetch(API_URL).then(response => response.json()).catch(error => console.error(error))
}
export async function getUser(userName) {
    const users = await fetch(API_URL + "?username=" + userName)
        .then(response => response.json())
        .catch(error => console.error(error))
    return users;
}
export async function getTranslations(username, setTranslationCache) {
    // this has not been tested
    const response = await fetch(API_URL + "?username=" + username)
    const json = await response.json();
    console.log(json)
    const output = json[0].translations;
    if (setTranslationCache !==undefined){
        setTranslationCache(output)
    }

    return output;
}
