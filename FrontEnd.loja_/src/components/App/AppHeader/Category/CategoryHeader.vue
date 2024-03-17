<script >
import { ref } from "vue";

    export default { 
        props:{
            datasource : {
                type: Object , 
                required: true , 
            }
        },
        data() {
            return {
                categoryDataSource:{
                    type:Object
                } , 
                parentDataSource : {}, 

            }
        },
        methods:{
            setCategory(datasource , children ){
                if(children!==null)
                {
                    this.categoryDataSource = children;
                    this.parentDataSource = datasource;
                }
            },
            setMainMenu(){
                this.parentDataSource = null ; 
                this.categoryDataSource = this.datasource;
            },
            setPreviousMenu(){
                this.categoryDataSource = [this.parentDataSource];
                this.parentDataSource= null ; 
            },
            closeMenu(){
                this.$store.commit('closeMenu');
            }
        },
        beforeMount(){
            this.categoryDataSource = this.datasource;
        }
    }
</script>

<template>
    <div class="lock-screen" @click="closeMenu"></div>
        <div class="menu">
            <div class="menu--close-button"  @click="closeMenu">X</div>
            <div class="flex-column menu--login">
                <i>icon</i> <p>Fazer login</p>
            </div>
            <div class="flex-column menu--information"> 
                <i>icon</i> <p>Conteudo Informacao</p>
            </div>
            
            <div class="flex-column menu--main-menu" v-if="categoryDataSource[0]?.category !== 'main'">
                <i @click="setMainMenu" >voltar</i> <p @click="setMainMenu">voltar para o menu principal</p><span>></span>
            </div>

            <div class="flex-column menu--return" v-if="parentDataSource!=null && parentDataSource.parent !=null">
                <i @click="setPreviousMenu" >voltar</i> <p @click="setPreviousMenu">{{ 'Voltar a '+ parentDataSource.parent  }}</p>
                {{ parentDataSource.parent }}
            </div>
            
            <div class="flex-column menu--category" v-for="(category ,index ) in categoryDataSource" :key="index"> 
                <i @click="setCategory(category , category.children)" >icon</i> 
                <p @click="setCategory(category , category.children)"> {{ category.name }} </p> 
                <span> X </span>
            </div>
            
        </div>
</template>
<style scoped lang="scss"> 
@import "./style.scss";
</style>