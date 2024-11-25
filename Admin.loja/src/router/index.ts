import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
const routes = [
    {
        path: '/',
        name: 'Login',
        component: () => import('../views/Login/LoginView.vue')
    },
    {
        path: '/store/categories',
        name: 'store/categories',
        component: () => import('../views/Store/Categories/CategoriesView.vue')
    },
   
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
    scrollBehavior(to, from, savedPosition) {
        return { top: 0 }
    },
    
})

export { routes };
export default router