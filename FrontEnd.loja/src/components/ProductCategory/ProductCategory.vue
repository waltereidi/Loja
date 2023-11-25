<script lang="ts">
    import ProductComponent from './ProductComponent/ProductComponent.vue';
    
    export default {
        props:{
            datasource : {
                required: true ,
                type: Object , 
            }
        },
        components:{
            ProductComponent,
        }
    }
</script>
<template>
    <div class="category-container">
        <div class="title">{{ datasource.name }} <img :src="datasource.icon"/></div>
        
        <div class="products" >
            <ProductComponent :datasource="product" v-for="(product ,index ) in datasource.products" :key="index"></ProductComponent> 
        </div>
    </div>


</template>
<style scoped lang='scss'>
    @import './style.scss';
</style>