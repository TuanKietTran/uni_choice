<template>
  <div v-if="currentScore && predictScore" class="p-4 dark:text-gray-300">
    <p>Điểm hiện tại: {{ currentScore }}</p>
    <p>Điểm dự đoán: {{ predictScore }}</p>
  </div>
</template>

<script lang="ts">
import EventBus, { EventBusEvent } from '@/EventBus';
import type PredictedResult from '@/models/predictedResult';

export default {
  data() {
    return {
      currentScore: 0.0,
      predictScore: 0.0,
    };
  },
  created(): void {
    EventBus.addEventListener('result', (e): void => {
      if (e instanceof EventBusEvent) {
        const result: PredictedResult = e.data
        this.currentScore = result.currentScore
        this.predictScore = result.predictScore
      }
    })
  }
}
</script>
