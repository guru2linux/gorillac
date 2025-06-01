// https://nuxt.com/docs/api/configuration/nuxt-config
export default {
  devtools: { enabled: true },
  modules: [
    '@nuxt/content',
    '@nuxt/fonts',
    '@nuxt/icon',
    '@nuxt/image',
    '@nuxt/ui',
    '@nuxtjs/tailwindcss',
    '@nuxtjs/color-mode',
    '@nuxtjs/robots'
  ],
  app: {
    head: {
      title: 'Gorillac.net',
      meta: [
        { name: 'description', content: 'Personal website of Lee Dulcio' }
      ]
    }
  },
  css: [
    '@/assets/css/tailwind.css'
  ],
  runtimeConfig: {
    public: {
      apiBase: process.env.NUXT_PUBLIC_API_BASE || 'http://localhost:5011/api'
    }
  }
}