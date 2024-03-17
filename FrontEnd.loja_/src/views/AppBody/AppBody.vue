<script lang="ts">
import { categoryStore } from "@/store/categoryStore";
import ProductCategory from "@/components/ProductCategory/ProductCategory.vue";

export default {    
    components:{
        ProductCategory, 
    },
    data(){
        return {
            categoryStore : categoryStore() ,
        }
    }
}
</script>

<template>
    <div class="app-body">
            <div class="productCategory" v-for="(productCategory , index ) in categoryStore.getProductCategoryDataSource" :key="index">
                <ProductCategory :datasource="productCategory"></ProductCategory>
            </div>
    </div>

</template>
<style scoped lang="scss">
    @import './style.scss';

</style>