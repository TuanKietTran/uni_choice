<script setup lang="ts">
import FormScore from '@/components/FormScore.vue'
import ResultScore from '@/components/ResultScore.vue'
</script>

<template>
  <main class="px-16">
    <h1 class="p-4 text-3xl font-bold text-gray-900 dark:text-white">
      Công cụ quy đổi điểm THPTQG 2023
    </h1>
    <div class="p-4">
      <FormScore />
      <ResultScore />
    </div>
  </main>
</template>
