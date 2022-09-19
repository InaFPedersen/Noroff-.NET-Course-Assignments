<script setup>
import { useRouter } from "vue-router";
import FormGetTrivia from "../components/FormGetTrivia.vue";

const router = useRouter();

const handleApiCall = () => {
  router.push("/trivia");
};
</script>

<template>
  <div style="height: 15vh"></div>
  <h1>Trivia - Game</h1>
  <div class="container">
    <FormGetTrivia @onApiCallSuccess="handleApiCall" />
  </div>
</template>

<style>
@import "../assets/StartScreen.css";
</style>