<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <div>
      <nav class="bg-white border-gray-200 dark:bg-gray-900">
        <div class="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
          <a href="https://flowbite.com/" class="flex items-center">
            <img
              src="https://img.freepik.com/free-icon/magnet_318-795289.jpg?t=st=1683120414~exp=1683121014~hmac=33e13bae4399c980637a6464dfc36f7d19beb11bf93870c638540cea64da19c8"
              class="h-8 mr-3" alt="Logo" />
            <span class="self-center text-2xl font-semibold whitespace-nowrap dark:text-white">UniChoice</span>
          </a>

          <div class="items-center justify-between hidden w-full md:flex md:w-auto md:order-1" id="navbar-sticky">
            <ul
              class="flex flex-col p-4 md:p-0 mt-4 font-medium border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 md:mt-0 md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
              <li>
                <RouterLink class="block py-2 pl-3 pr-4 text-white rounded md:bg-transparentmd:p-0" to="/">Quy đổi điểm
                </RouterLink>
              </li>
              <li>
                <RouterLink class="block py-2 pl-3 pr-4 text-white rounded md:bg-transparentmd:p-0" to="/">Điểm thi
                </RouterLink>
              </li>
              <li>
                <RouterLink class="block py-2 pl-3 pr-4 text-white rounded md:bg-transparentmd:p-0" to="/">Điểm chuẩn
                </RouterLink>
              </li>

            </ul>
          </div>
        </div>
      </nav>
      <!-- <nav>
        <RouterLink to="/">Home</RouterLink>
      </nav> -->
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}
</style>
