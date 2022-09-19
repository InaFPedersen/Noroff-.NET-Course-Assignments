<script setup>
import { useStore } from "vuex";
import { computed } from "vue";
import { useRouter } from "vue-router";

import ResultQuestionListItem from "./ResultQuestionListItem.vue";

const router = useRouter();
const store = useStore();
const triviaList = computed(() => store.state.trivia);
const score = computed(() => store.state.resultScore);

// Return to start, revert the global index to 0, and revert the Total Score to 0.
const handleBackToStart = () => {
  router.push("/");
  store.commit("revertIndex");
  store.commit("revertResultScore");
};
</script>

<template>
  <div class="result-container">
    <h2>Total Score: {{ score }}</h2>
    <div class="questions-container">
      <ResultQuestionListItem
        v-for="trivia in triviaList"
        :key="trivia.question"
        :trivia="trivia"
      />
    </div>
    <div class="button-container">
      <button class="start" v-on:click="handleBackToStart">Go to Start</button>
      <button class="start">Replay</button>
    </div>
  </div>
</template>