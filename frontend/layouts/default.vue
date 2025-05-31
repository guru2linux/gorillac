<template>
  <div class="min-h-screen bg-white text-black dark:bg-gray-900 dark:text-white">
    <NavBar />
    <div class="p-4">
      <NuxtPage />
    </div>
    <Footer />
  </div>
</template>

<script setup>
import NavBar from '~/components/NavBar.vue'
import Footer from '~/components/Footer.vue'
</script>