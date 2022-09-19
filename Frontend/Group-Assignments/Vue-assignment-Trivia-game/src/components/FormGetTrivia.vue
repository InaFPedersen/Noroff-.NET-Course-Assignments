<script setup>
import { ref } from "vue";
import { useStore } from "vuex";
import { onMounted } from "vue";
import { apiFetchAllTrivia } from "../api/trivia.js";

import CategoryList from "../components/CategoryList.vue";

const store = useStore();

const emit = defineEmits(["onApiCallSuccess"]);

onMounted(async () => {
  await store.dispatch("fetchAllCategories");
});

// On Success, set the Trivia state to the array fetched from Trivia-API
const onSuccess = (trivia) => {
  store.commit("setTrivia", trivia);
  // Had to push a empty string at the top of the array to stop the index from returning undefined at the last trivia question.
  store.commit("pushTrivia");
  emit("onApiCallSuccess");
};

const username = ref("");
const difficulty = ref("easy");
const questionNr = ref("10");
const category = ref("");

// Get the correct values from the dropdown lists to create the API URL
const onSubmit = async () => {
  const [error, questionList] = await apiFetchAllTrivia(
    difficulty.value,
    questionNr.value,
    category.value
  );
  onSuccess(questionList);
};
</script>

<template>
  <form @submit.prevent="onSubmit">
    <input
      type="text"
      class="username"
      name="username"
      placeholder="Username"
      v-model="username"
    />

    <div class="center-container">
      <select name="difficulty" class="difficulty" v-model="difficulty">
        <option value="easy">Easy</option>
        <option value="medium">Medium</option>
        <option value="hard">Hard</option>
      </select>

      <select name="questions-Nr" class="questions-Nr" v-model="questionNr">
        <option value="5" selected="selected">5</option>
        <option value="10" selected="selected">10</option>
        <option value="15" selected="selected">15</option>
        <option value="20" selected="selected">20</option>
      </select>

      <CategoryList v-model="category" />
    </div>
    <button class="start" type="submit">Start</button>
  </form>
</template>