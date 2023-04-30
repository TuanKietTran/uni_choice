<script lang="ts">
export default {
  data() {
    return {
      collgeCheck: false,
      scoreCheck: false
    }
  },
}
</script>

<template>
  <form>
    <div class="flex items-start mb-6">
      <div class="flex items-center h-5">
        <input id="college" type="checkbox" v-model="collgeCheck"
          class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800">
      </div>
      <label for="college" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Tra cứu dựa trên ngành đại
        học / cao đẳng</label>
    </div>
    <div v-if="collgeCheck" class="grid md:grid-cols-3 md:gap-6">
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Trường</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Khối ngành</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Khối thi</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
    </div>

    <div class="flex items-start mb-6">
      <div class="flex items-center h-5">
        <input id="score" type="checkbox" v-model="scoreCheck"
          class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800"
          >
      </div>
      <label for="score" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Tra cứu dựa trên điểm thi
        các môn</label>
    </div>

    <div v-if="scoreCheck" class="grid md:grid-cols-9 md:gap-6">
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Toán</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Văn</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngoại ngữ</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Lý</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Hoá</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Sinh</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Sử</label>
        <input type="select" id="email"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
      <div class="mb-6 group col-span-1">
        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">GDCD</label>
        <input type="password" id="password"
          class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
      </div>
    </div>
    <!-- <div class="flex items-start mb-6">
      <div class="flex items-center h-5">
        <input id="remember" type="checkbox" value=""
          class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800"
          required>
      </div>
      <label for="remember" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Remember me</label>
    </div> -->
    <button type="submit"
      class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Quy
      đổi</button>
  </form>
</template>
