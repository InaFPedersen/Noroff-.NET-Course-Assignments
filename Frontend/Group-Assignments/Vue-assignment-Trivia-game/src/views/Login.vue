<script setup>
import LoginRegisterFormVue from '../components/LoginRegisterForm.vue';
import LoginRegisterForm from '../components/LoginRegisterForm.vue';

const handleAuthSuccess = () => {
    console.log("User is available")
}

</script>

<template>
<main>
    <h1>The Trivia Game</h1>

    <h3> Login to get started!</h3>
    
    <LoginRegisterForm @onAuthSuccess="handleAuthSuccess"/>
 </main>   
    
</template>

