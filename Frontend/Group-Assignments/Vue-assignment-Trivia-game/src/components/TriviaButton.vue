<script setup>
import { useStore } from "vuex";
import { computed } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const store = useStore();
const triviaList = computed(() => store.state.trivia);
const index = computed(() => store.state.index);

// On every correct answer, increment the Total Score by 10.
const buttonIndexIncrement = () => {
  store.commit("incrementIndex");
  router.push("/trivia");

  if (triviaList.value.length === index.value + 1) {
    store.commit("popTrivia");
    router.push("/result");
  }
};

// Everyday a question answer is pressed, the global index is incremented by 1,
// and the router pushes to same page again.
// This could be done a lot better with lifecycle methods.
const resultScore = () => {
  store.commit("incrementIndex");
  router.push("/trivia");
  store.commit("incrementResultScore");

  // If the global index is the same as the trivia list length,
  // the trivia is done and we push to result.
  if (triviaList.value.length === index.value + 1) {
    store.commit("popTrivia");
    router.push("/result");
  }
};
</script>

<template>
  <div class="answers-container" v-if="triviaList[index].type === 'boolean'">
    <button class="answer-button start" v-on:click="buttonIndexIncrement">
      {{ triviaList[index].incorrect_answers[0] }}
    </button>
    <button class="answer-button start" v-on:click="resultScore">
      {{ triviaList[index].correct_answer }}
    </button>
  </div>

  <div class="answers-container" v-if="triviaList[index].type === 'multiple'">
    <button class="answer-button start" v-on:click="buttonIndexIncrement">
      {{ triviaList[index].incorrect_answers[0] }}
    </button>
    <button class="answer-button start" v-on:click="buttonIndexIncrement">
      {{ triviaList[index].incorrect_answers[1] }}
    </button>
    <button class="answer-button start" v-on:click="buttonIndexIncrement">
      {{ triviaList[index].incorrect_answers[2] }}
    </button>
    <button class="answer-button start" v-on:click="resultScore">
      {{ triviaList[index].correct_answer }}
    </button>
  </div>
</template>