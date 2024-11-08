import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import { useDi } from '@/pinia/dependencyInjection'
import { RouterInfo } from '@/pinia/Dto/routerInfo'
const router = createRouter({
    history: createWebHistory(),
    routes: [
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
       
    ],
    scrollBehavior(to, from, savedPosition) {
        return { top: 0 }
    },
    
})
router.beforeEach(async (to, from) => {
    // ...
    // explicitly return false to cancel the navigation  
   
    const routeInfo:RouterInfo = {
        to : to.name ,
        from : from.name
    }
    const response:RouterInfo = await useDi().routeChanged(routeInfo);

    if(to.name === response.to)
        return true;
    else {
        return { name: 'Login' }
    }
        
  })
  
export default router