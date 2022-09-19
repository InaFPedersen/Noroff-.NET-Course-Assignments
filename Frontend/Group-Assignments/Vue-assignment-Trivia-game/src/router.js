import { createRouter, createWebHistory } from "vue-router";
import StartScreen from "./views/StartScreen.vue";
import QuestionScreen from "./views/QuestionScreen.vue";
import ResultScreen from "./views/ResultScreen.vue";

const routes = [
    {
        path: "/",
        component: StartScreen,
    },
    {
        path: "/trivia",
        component: QuestionScreen,
    },
    {
        path: "/result",
        component: ResultScreen,
    },
];

export default createRouter({
    history: createWebHistory(),
    routes,
});