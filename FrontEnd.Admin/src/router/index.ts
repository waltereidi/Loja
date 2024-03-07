import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'


const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'login',
    component: () => import('../views/Login/LoginView.vue')
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('../views/Register/RegisterView.vue')
  },
  {
    path: '/home',
    name: 'home',
    component: () => import('../views/Home/HomeView.vue')
  },
  {
    path: '/store/categories',
    name: 'store/categories',
    component: () => import('../views/Store/Categories/CategoriesView.vue')
  },
  {
    path: '/store/users',
    name: 'store/users',
    component: () => import('../views/Store/Users/UsersView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
