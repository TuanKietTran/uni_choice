<script lang="ts">
export default {
  data() {
    return {
      yourScore: 0.0,
      equivalent: 0.0
    }
  },
}
</script>

<template>
  <div class="pt-4">
    <p>Điểm của bạn: {{ yourScore }}</p>
    <p>Điểm quy đổi: {{ equivalent }}</p>
  </div>
</template>
