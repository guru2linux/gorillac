<template>
  <nav class="flex justify-between items-center p-4 bg-gray-900 text-white">
    <h1 class="text-xl font-bold">Gorillac</h1>
    <ul class="flex items-center space-x-4">
      <li><NuxtLink to="/">Home</NuxtLink></li>
      <li><NuxtLink to="/about">About</NuxtLink></li>
      <li><NuxtLink to="/projects">Projects</NuxtLink></li>
      <li><NuxtLink to="/contact">Contact</NuxtLink></li>
      <li><DarkModeToggle /></li>
    </ul>
  </nav>
</template>

<script setup>
import DarkModeToggle from './DarkModeToggle.vue'
</script>

<style scoped>
nav {
  position: relative;
  z-index: 10;
}
</style>