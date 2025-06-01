<template>
  <nav class="flex justify-between items-center p-4 bg-blue-900 text-white">
    <h1 class="text-xl font-bold text-brand-gold">Haven Ridge Enterprises</h1>
    <ul class="flex items-center space-x-4">
      <li><NuxtLink to="/" class="text-white hover:text-brand-gold">Home</NuxtLink></li>
      <li><NuxtLink to="/about" class="text-white hover:text-brand-gold">About</NuxtLink></li>
      <li><NuxtLink to="/contact" class="text-white hover:text-brand-gold">Contact Us</NuxtLink></li>
    </ul>
  </nav>
</template>

<script setup>
</script>

<style scoped>
nav {
  position: relative;
  z-index: 10;
}
</style>