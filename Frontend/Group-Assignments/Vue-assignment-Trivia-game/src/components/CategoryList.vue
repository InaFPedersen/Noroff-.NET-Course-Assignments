<script setup>
import { useStore } from "vuex";
import { computed } from "vue";
import CategoryListItem from "./CategoryListItem.vue";

const store = useStore();
const categories = computed(() => store.state.categories);
</script>

<template>
  <select name="questions-Nr" class="questions-Nr">
    <CategoryListItem
      v-for="category in categories"
      :key="category.id"
      :category="category"
    />
  </select>
</template>