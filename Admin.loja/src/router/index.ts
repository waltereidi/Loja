import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import { useDi } from '@/pinia/dependencyInjection'
import { RouterInfo } from '@/pinia/Entity/routerInfo'
const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/Login',
            name: 'login',
            component: () => import('../views/Login/LoginView.vue')
        },
        {
            path: '/store/categories',
            name: 'store/categories',
            component: () => import('../views/Store/Categories/CategoriesView.vue')
        },
       
    ],
    scrollBehavior(to, from, savedPosition) {
        return { top: 0 }
    },
    
})
router.beforeEach(async (to, from) => {
    // ...
    // explicitly return false to cancel the navigation
    const routeInfo:RouterInfo = {
        to : to ,
        from : from
    }
    const response:RouterInfo = await useDi().routeChanged(routeInfo);
    to = response.to;
    from = response.from;
    return true
  })
export default router