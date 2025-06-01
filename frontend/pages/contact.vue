<template>
  <div class="max-w-xl mx-auto p-4 bg-brand-cream rounded-lg shadow">
    <h1 class="text-2xl font-bold mb-4 text-brand-dark">Contact Us</h1>
    <form @submit.prevent="submitForm" class="space-y-4">
      <input v-model="form.name" type="text" placeholder="Your Name" required class="w-full p-2 border rounded border-brand-gold text-brand-dark bg-white" />
      <input v-model="form.email" type="email" placeholder="Your Email" required class="w-full p-2 border rounded border-brand-gold text-brand-dark bg-white" />
      <textarea v-model="form.message" placeholder="Your Message" required class="w-full p-2 border rounded border-brand-gold text-brand-dark bg-white"></textarea>
      <button type="submit" class="bg-brand-gold text-brand-dark px-4 py-2 rounded hover:brightness-90">
        Send
      </button>
      <p v-if="response" class="text-green-600 mt-2">{{ response }}</p>
    </form>
  </div>
</template>

<script setup>
import { ref, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useRuntimeConfig } from '#app'

const config = useRuntimeConfig()
const router = useRouter()
const form = reactive({ name: '', email: '', message: '' })
const response = ref(null)

async function submitForm() {
  try {
    // Ensure the backend URL is correct and absolute
    const apiBase = config.public.apiBase?.replace(/\/$/, '') || 'http://localhost:5000/api'
    const apiUrl = `${apiBase}/contact`
    const data = await $fetch(apiUrl, {
      method: 'POST',
      body: { ...form },
      baseURL: undefined, // Ensure $fetch does not prepend Nuxt's own base URL
      server: false // Always use client-side fetch
    })
    response.value = data.message || 'Message sent!'
    form.name = form.email = form.message = ''
    // Show confirmation, then redirect to home after a short delay
    setTimeout(() => {
      router.push('/')
    }, 1500)
  } catch {
    response.value = 'Error sending message'
  }
}
</script>
