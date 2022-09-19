import { createStore } from "vuex";
import { apiFetchAllCategories } from "./api/categories";

export default createStore({
    state: {
        categories: [],
        trivia: [],
        index: 0,
        resultScore: 0,
    },
    mutations: {
        setCategories: (state, categories) => {
            state.categories = categories;
        },

        setTrivia: (state, trivia) => {
            state.trivia = trivia;
        },
        pushTrivia(state) {
            state.trivia.push("temp");
        },
        popTrivia(state) {
            state.trivia.pop();
        },

        setIndex: (state, index) => {
            state.index = index;
        },
        incrementIndex(state) {
            state.index++;
        },
        revertIndex(state) {
            state.index = 0;
        },

        setResultScore: (state, resultScore) => {
            state.resultScore = resultScore;
        },
        incrementResultScore(state) {
            state.resultScore += 10;
        },
        revertResultScore(state) {
            state.resultScore = 0;
        },
    },
    actions: {
        async fetchAllCategories({ commit }) {
            // API Request
            const [error, categories] = await apiFetchAllCategories();
            if (error !== null) {
                return error;
            }

            // Set the state
            commit("setCategories", categories);

            // Return error
            return null;
        },
        increaseIndex({ commit }) {
            commit("setIndex", index);

            return null;
        },
    },
});
