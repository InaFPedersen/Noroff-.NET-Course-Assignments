import { CATEGORY_URL } from ".";

export async function apiFetchAllCategories() {
    try {
        const response = await fetch(CATEGORY_URL);

        const { trivia_categories } = await response.json();

        return [null, trivia_categories];
    } catch (error) {
        console.error(error.message, []);
    }
}
