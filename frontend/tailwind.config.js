module.exports = {
  darkMode: 'class', // Enable dark mode via class strategy
  content: [
    './components/**/*.{js,vue}',
    './layouts/**/*.vue',
    './pages/**/*.vue',
    './app.vue',
    './nuxt.config.{js,ts}'
  ],
  safelist: [
    'bg-brand-gold',
    'bg-brand-cream',
    'text-brand-cream',
    'text-brand-gold',
    'text-brand-dark',
    'text-brand-white'
  ],
  theme: {
    extend: {
      colors: {
        'brand-gold': '#D6A540',
        'brand-cream': '#FAF4E8',
        'brand-text': '#1F2D3D',
        'brand-white': '#FFFFFF',
      }
    },
  },
  plugins: [],
}
