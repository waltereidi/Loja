<script>
import { ref } from 'vue';
import CategoryHeader from './Category/CategoryHeader.vue';
import LogoHeader from './Logo/LogoHeader.vue';
import SearchHeader from './Search/SearchHeader.vue';
import BuyHeader from './Buy/BuyHeader.vue';
import CategoryBar from './CategoryBar/CategoryBar.vue';
import {categoryStore}  from '/src/store/categoryStore.ts';

const props = {
    datasource :{
        required : true , 
        type: Object 
    }
}

export default{
    props, 
    data(){
        return {
            categoryStore : categoryStore()  ,
        }
    },
    methods:{
        openMenu(){
        this.$store.commit('openMenu');
        }, 
        
    }, 
    components:{
        CategoryHeader,
        SearchHeader, 
        BuyHeader, 
        LogoHeader,
        CategoryBar,
    },
    mounted() {
        this.categoryStore.setCategoryBar(this.datasource);
    }
 
}
 
</script>

<template>
    <CategoryHeader :datasource="datasource" v-if="this.$store.getters.getNavMenu"></CategoryHeader>
    <div class="header">
        <div class="header--menu" @click="openMenu">
            <img src="img/icons/AppHeader/menu.svg"/>
        </div>
        <div class="header--logo"><LogoHeader/></div>
        <div class="header--search"><SearchHeader/></div>
        <div class="header--buy"><BuyHeader/></div>
        <div class="header--category-bar" v-if="categoryStore.getCategoryBar.length > 0">
            <div class="header--category-bar__category" v-for="(category , index) in  categoryStore.getCategoryBar" :key="index" >
                <CategoryBar :datasource="category"></CategoryBar>
            </div>
        </div>

    </div>

</template>
<style lang="scss">
    @import "./style.scss";
</style>