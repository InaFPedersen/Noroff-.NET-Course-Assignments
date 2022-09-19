<script setup>
import { useStore } from "vuex";
import { computed } from "vue";

import TriviaQuestion from "../components/TriviaQuestion.vue";
import ResultScreen from "./ResultScreen.vue";

const store = useStore();

const triviaList = computed(() => store.state.trivia);
const index = computed(() => store.state.index);
</script>

<template>
  <div style="height: 15vh"></div>
  <h2>
    {{ triviaList[index].question }}
  </h2>
  <TriviaQuestion />
</template>