

<template>
  <form @submit.prevent="submitForm">
    <!-- <div class="flex items-start mb-6">
      <div class="flex items-center h-5">
        <input id="college" type="checkbox" v-model="collgeCheck"
          class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800" />
      </div>
      <label for="college" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Tra cứu dựa trên ngành đại
        học / cao đẳng</label>
    </div> -->

    <div class="grid md:grid-cols-3 md:gap-6">

      <div class="mb-6 group col-span-1">
        <label for="college" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Trường</label>
        <select
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          v-model="selectedUniversity" @change="onUniversityChange">
          <option value="null" class="dark:text-gray-900">Chọn trường</option>
          <option v-for="university in universities" :value="university.uniCode" v-bind:key="university.uniCode">{{
            university.uniName }}</option>
        </select>
      </div>

      <div class="mb-6 group col-span-1">
        <label for="major" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngành</label>
        <select
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          v-model="selectedMajor" :disabled="!selectedUniversity">
          <option value="null" class="dark:text-gray-900">Chọn ngành</option>
          <option v-for="major in majors" :value="major.majorCode" v-bind:key="major.majorCode">{{ major.majorName }}
          </option>
        </select>
      </div>

      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Khối thi</label>
        <select
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          v-model="selectedGroupSubject" :disabled="!selectedMajor">
          <option value="null" class="dark:text-gray-900">Chọn khối</option>
          <option v-for="groupSubject in groupSubjects" :value="groupSubject" v-bind:key="groupSubject">{{ groupSubject }}
          </option>
        </select>
      </div>

    </div>

    <!-- <div class="flex items-start mb-6">
      <div class="flex items-center h-5">
        <input id="score" type="checkbox" v-model="scoreCheck"
          class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800" />
      </div>
      <label for="score" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Tra cứu dựa trên điểm thi các
        môn</label>
    </div> -->

    <!-- <div v-if="scoreCheck" class="grid md:grid-cols-9 md:gap-6">
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Toán</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Văn</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngoại ngữ</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Lý</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Hoá</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Sinh</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Sử</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">GDCD</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
      </div>
    </div> -->

    <button :disabled="isSubmitDisabled"
      class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
      Quy đổi
    </button>
  </form>

</template>

<script lang="ts">
import EventBus from '@/EventBus';
import httpClient from '@/http';
import type Major from '@/models/major';
import type PredictedResult from '@/models/predictedResult';
import type University from '@/models/university';


export default {
  data() {
    return {
      // collgeCheck: false,
      // scoreCheck: false,
      selectedUniversity: null as (string | null),
      selectedMajor: null as (string | null),
      selectedGroupSubject: null as (string | null),
      universities: [] as University[],
      majors: [] as Major[],
      groupSubjects: [] as string[],
      yourScore: 0.0,
      equivalent: 0.0
    }
  },
  computed: {
    isSubmitDisabled(): boolean {
      return this.selectedUniversity == null || this.selectedMajor == null || this.selectedGroupSubject == null;
    },
  },
  watch: {
    selectedUniversity() {
      this.selectedMajor = null;
      this.selectedGroupSubject = null;
      this.fetchMajors();
    },
    selectedMajor() {
      this.selectedGroupSubject = null;
      this.fetchGroupSubjects();
    },
  },
  methods: {
    async fetchUniversities() {
      const response = await httpClient.get('universities')
      return response.data
    },
    async fetchMajors() {
      if (!this.selectedUniversity) {
        return;
      }
      const response = await httpClient.get(`major?uni=${this.selectedUniversity.toUpperCase()}`)
      this.majors = response.data;
    },
    async fetchGroupSubjects() {
      if (!this.selectedMajor) {
        return;
      }
      const response = await httpClient.get(`major/at?major=${this.selectedMajor}`)
      this.groupSubjects = response.data;
    },
    async submitForm() {

      try {
        const response = await httpClient.get(`equal?major=${this.selectedMajor}&group=${this.selectedGroupSubject}`);
        EventBus.emit('result', response.data as PredictedResult);
      } catch (error) {
        console.error(error);
      }
    },
    onUniversityChange() {
      this.fetchMajors();
    },
    onMajorChange() {
      this.fetchGroupSubjects();
    },
  },
  async created() {
    this.universities = await this.fetchUniversities();
  },
};
</script>
