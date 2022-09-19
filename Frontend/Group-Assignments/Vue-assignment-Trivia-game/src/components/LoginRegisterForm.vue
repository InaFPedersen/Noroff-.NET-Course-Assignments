<script setup>
import { ref } from "vue";
import { useStore } from "vuex";
import {apiUserLoginRegister} from "../api/users"

const store = useStore()

    const emit = defineEmits(["onAuthSuccess"]);
    const username = ref("")
    const password = ref("")
    const displayError = ref("")

    const onSuccess = user => {
        store.commit("setUser", user) //= mutations
        emit("onAuthSuccess")
    }

    const onRegister = async () => {
        const [error, user] = await apiUserLoginRegister("register", username.value, password.value)
        if (error !== null) {
            displayError.value = error
        } else {
            onSuccess(user)
        }
    }

    const onLogin = async () => {
        const [error, user] = await apiUserLoginRegister("login", username.value, password.value)
        if (error !== null) {
            displayError.value = error
        } else {
            onSuccess(user)
        }
    }
</script>

<template>
<main>
        <form>

        <fieldset>
            <label for="username" 
            aria-label="Username: " 
            aria-placeholder="Insert username">Username: </label>
            <br/>
            <input type="text" id="username" v-model="username"/>
        </fieldset>
        <fieldset>
            <label for="password" aria-label="Password: " aria-placeholder="Insert password">Password: </label>
            <br/>
            <input type="password" id="password" v-model="password"/>
        </fieldset>
        <br/>
        <div grid-container>
            <button @click="onRegister" type="button" class="register"> Register user </button>
            <button @click="onLogin" type="button" class="login"> Login </button>
        </div>
        
    </form>  
    <div v-if="displayError" class="error-div">
        <span class="error">Error</span>
        <p>{{displayError}}</p>
    </div>
</main>

</template>