<script setup lang="ts">
import FormScore from '@/components/FormScore.vue'
import ResultScore from '@/components/ResultScore.vue';
</script>

<template>
  <h1 class="p-4 text-3xl font-bold text-gray-900 dark:text-white">
    Công cụ quy đổi điểm THPTQG 2023
  </h1>
  <main>
    <div class="p-4">
      <FormScore />
      <ResultScore/>
    </div>
  </main>
</template>
