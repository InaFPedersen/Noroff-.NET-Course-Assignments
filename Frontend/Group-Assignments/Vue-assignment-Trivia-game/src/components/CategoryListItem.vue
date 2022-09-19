<script setup>
defineProps({
  category: {
    type: Object,
    required: true,
  },
});
</script>

<template>
  <option :value="{ id: category.id, text: category.name }">
    {{ category.name }}
  </option>
</template>