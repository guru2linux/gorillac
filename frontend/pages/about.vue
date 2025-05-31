<template>
  <div>
    <div class="bg-brand-cream rounded-lg shadow p-6 flex flex-col md:flex-row gap-8">
      <div class="flex-1">
        <h1 class="text-2xl font-bold mb-2 text-brand-dark">About Me</h1>
        <p class="text-brand-text">Hello! I'm Lee Dulcio — cybersecurity pro, developer, and lifelong learner.</p>
      </div>
      <div class="flex-1 flex flex-col gap-4">
        <div class="flex items-center gap-3">
          <span class="inline-block w-8 h-8 bg-brand-gold rounded-full flex items-center justify-center text-brand-dark font-bold">IT</span>
          <span class="text-brand-text">Smart IT Solutions</span>
        </div>
        <div class="flex items-center gap-3">
          <span class="inline-block w-8 h-8 bg-brand-gold rounded-full flex items-center justify-center text-brand-dark font-bold">🏠</span>
          <span class="text-brand-text">Property Care</span>
        </div>
        <div class="flex items-center gap-3">
          <span class="inline-block w-8 h-8 bg-brand-gold rounded-full flex items-center justify-center text-brand-dark font-bold">🔒</span>
          <span class="text-brand-text">Cybersecurity</span>
        </div>
      </div>
    </div>
    <div class="bg-brand-cream py-16 px-6 text-center">
      <h2 class="text-2xl font-bold mb-4 text-brand-dark">ABOUT US</h2>
      <p class="mb-10 max-w-2xl mx-auto text-brand-text">
        We’re a Florida-based veteran-owned business providing IT, property management, and digital solutions tailored to your needs.
      </p>
      <div class="grid grid-cols-1 md:grid-cols-3 gap-6 max-w-5xl mx-auto">
        <div class="bg-white rounded-lg p-6 shadow text-brand-text">
          <h3 class="text-xl font-semibold mb-2 text-brand-gold">IT &amp; Cybersecurity</h3>
          <p>Network hardening, vulnerability scanning, compliance, secure architecture, troubleshooting, cloud setup, and support.</p>
        </div>
        <div class="bg-white rounded-lg p-6 shadow text-brand-text">
          <h3 class="text-xl font-semibold mb-2 text-brand-gold">Property Management</h3>
          <p>Reliable property care, maintenance coordination, inspections, and tenant support for peace of mind.</p>
        </div>
        <div class="bg-white rounded-lg p-6 shadow text-brand-text">
          <h3 class="text-xl font-semibold mb-2 text-brand-gold">Digital Solutions</h3>
          <p>Performance optimization, cloud integration, and technology consulting for modern businesses.</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AboutPage",
};
</script>

<style scoped>
/* No custom styles needed, all handled by Tailwind classes and your palette */
</style>