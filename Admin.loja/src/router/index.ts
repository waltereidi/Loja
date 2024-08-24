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
            path: '/store/categories',
            name: 'store/categories',
            component: () => import('../views/Store/Categories/CategoriesView.vue')
        },
        {
            path: '/',
            name: 'navbar',
            component: () => import('../components/Layout/NavBar/NavBar.vue')
        },
        {
            path: '/',
            name: 'header',
            component: () => import('../components/Layout/Header/Header.vue')
        },
    ],
    scrollBehavior(to, from, savedPosition) {
        return { top: 0 }
    }
})

export default router