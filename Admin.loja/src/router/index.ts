import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            name: 'login',
            component: () => import('../views/Login/LoginView.vue')
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

    ],
    scrollBehavior(to, from, savedPosition) {
        return { top: 0 }
    }
})

export default router