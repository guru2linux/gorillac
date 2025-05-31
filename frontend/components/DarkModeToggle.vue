<template>
  <button
    class="p-2 rounded bg-gray-200 dark:bg-gray-800 text-gray-800 dark:text-gray-200 shadow transition"
    @click="toggleDarkMode"
    :aria-pressed="isDark"
    aria-label="Toggle dark mode"
  >
    <span v-if="isDark">🌙</span>
    <span v-else>☀️</span>
  </button>
</template>

<script setup>
import { ref, onMounted } from 'vue'
const isDark = ref(false)

function setHtmlClass(dark) {
  document.documentElement.classList.toggle('dark', dark)
}

function toggleDarkMode() {
  isDark.value = !isDark.value
  setHtmlClass(isDark.value)
  localStorage.setItem('color-mode', isDark.value ? 'dark' : 'light')
}

onMounted(() => {
  const saved = localStorage.getItem('color-mode')
  isDark.value = saved === 'dark' || (!saved && window.matchMedia('(prefers-color-scheme: dark)').matches)
  setHtmlClass(isDark.value)
})
</script>

<style scoped>
button {
  font-size: 1.5rem;
}
</style>
