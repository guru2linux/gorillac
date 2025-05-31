module.exports = {
  darkMode: 'class', // Enable dark mode via class strategy
  content: [
    './components/**/*.{js,vue}',
    './layouts/**/*.vue',
    './pages/**/*.vue',
    './app.vue',
    './nuxt.config.{js,ts}'
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          dark: '#0C2239',
          gold: '#D6A540',
          cream: '#FAF4E8',
          text: '#1F2D3D',
          white: '#FFFFFF',
        }
      }
    },
  },
  plugins: [],
}
