import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import Login  from '@/views/Login.vue';

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: [
     {
       path: '/Login', 
       name: 'Login', 
       component: Login
     },
  ],
  scrollBehavior(to, from, savedPosition) {
      return {top:0}
  }
})

export default router
