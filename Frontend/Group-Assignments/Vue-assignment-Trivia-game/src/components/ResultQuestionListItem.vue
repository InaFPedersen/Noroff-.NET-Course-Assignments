<script setup>
defineProps({
  trivia: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <div class="card">
    <h3>
      {{ trivia.question }}
    </h3>
    <ul>
      <!-- The correct answer will allways be shown on top -->
      <li class="correct">{{ trivia.correct_answer }}</li>
      <li>{{ trivia.incorrect_answers[0] }}</li>
      <li>{{ trivia.incorrect_answers[1] }}</li>
      <li>{{ trivia.incorrect_answers[2] }}</li>
    </ul>
  </div>
</template>