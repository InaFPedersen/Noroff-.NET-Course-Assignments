import { BASE_URL } from ".";

export async function apiFetchAllTrivia(difficulty, questionNr, category) {
    try {
        const response = await fetch(
            `${BASE_URL}amount=${questionNr}&category=${category}&difficulty=${difficulty}`,
            {
                method: "get",
            }
        );
        const { response_code, results, error="An error occured while fetching trivia" } = await response.json();
        if(response_code !== 0 ) {
            throw new Error(error);
        }
        return [null, results];
    } catch (error) {
        console.error(error.message, null);
    }
}
