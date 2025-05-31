<template>
  <nav class="flex justify-between items-center p-4 bg-brand-dark text-brand-gold">
    <h1 class="text-xl font-bold text-brand-gold">Haven Ridge Enterprises</h1>
    <ul class="flex items-center space-x-4">
      <li><NuxtLink to="/" class="text-brand-cream hover:text-brand-gold">Home</NuxtLink></li>
      <li><NuxtLink to="/about" class="text-brand-cream hover:text-brand-gold">About</NuxtLink></li>
      <li><NuxtLink to="/projects" class="text-brand-cream hover:text-brand-gold">Projects</NuxtLink></li>
      <li><NuxtLink to="/contact" class="text-brand-cream hover:text-brand-gold">Contact</NuxtLink></li>
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