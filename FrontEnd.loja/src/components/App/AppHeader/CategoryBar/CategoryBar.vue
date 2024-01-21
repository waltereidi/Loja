<script>
export default {
    props:{
        datasource : {
            type: Object , 
            required: true , 
        },
    }
}
</script>
<template>
    
    <div class="category">
        <img :src="'/img/icons/Category/'+datasource.icon" />
        <p>{{ datasource.name }}</p>
    </div>

</template>
<style lang="scss">
@import './styles.scss';
</style>