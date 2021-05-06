<template>
  <div class="container">
      <the-header/>
      <the-navigation/>
    <main>
      <router-view></router-view>
    </main>
    <the-footer/>
  </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.min.css'
import TheHeader from './components/shared/TheHeader'
import TheNavigation from './components/shared/TheNavigation'
import TheFooter from './components/shared/TheFooter'

export default {
  name: 'App',
  
  components: { TheNavigation, TheHeader, TheFooter } 
  
}

</script>


<style scoped>


</style>
