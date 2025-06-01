<template>
  <div class="min-h-screen bg-white text-black" style="border-top-left-radius: 2.5rem; border-top-right-radius: 2.5rem; overflow: hidden;">
    <!-- Empowering Florida Section -->
    <section>
      <h2>Empowering Florida with Smart IT &amp; Property Solutions</h2>
      <p>
        We proudly serve Florida with a commitment to excellence, integrity, and community. Our veteran-owned business brings trusted IT, property management, and digital solutions to homes and businesses across the Sunshine State.
      </p>
    </section>

    <!-- Main Content Section -->
    <section>
      <h2>Our Mission</h2>
      <p>
        Delivering innovative, reliable, and affordable IT and property solutions for Florida’s communities. We combine technology expertise with a passion for service.
      </p>
      <NuxtLink to="/contact">
        <button class="bg-brand-gold text-black font-semibold px-8 py-3 rounded-full mt-4 dark:bg-brand-cream dark:text-black">
          Get in Touch
        </button>
      </NuxtLink>
    </section>

    <!-- Why Choose Us Footer Section -->
    <footer>
      <h2>WHY CHOOSE US</h2>
      <div>
        <div>
          <span>⭐</span> Veteran-Owned
        </div>
        <div>
          <span>🛡️</span> Licensed &amp; Insured
        </div>
        <div>
          <span>💲</span> Affordable Rates
        </div>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: "HomePage",
};
</script>

<style scoped>
</style>

