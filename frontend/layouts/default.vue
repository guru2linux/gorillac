<template>
  <div>
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

<style>
html {
  scroll-behavior: smooth;
}
</style>