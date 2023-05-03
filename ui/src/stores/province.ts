import { defineStore } from 'pinia'
import httpClient from "@/http"
import { onMounted, ref } from 'vue'
import type Province from '@/models/province'
import { convertToProvince } from '@/models/convert'

export const useProvinceStore = defineStore('province', () => {
  const provinces = ref([] as Province[])

  async function getProvince() {
    try {
      const response = await httpClient.get(`provinces`)
      provinces.value = response.data.map(convertToProvince)
    }
    catch (error) {
      alert(error)
      console.log(error)
    }
  }

  // Runs the very first time the store is used. i.e., when the store is initialized.
  onMounted(getProvince);

  return {
    provinces,
    getProvince
  }
})
