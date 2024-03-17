<script lang='ts'>
    export default { 
        props:{
            datasource:{
                required: true , 
                type:Object , 
            }
        }

    }

</script>

<template> 
    <div class="product">
            <div class="product--image">
                {{ datasource.productImage }}
            </div>
            <div class="product--price">
                {{ datasource.price }}
            </div>
            <div class="product--actions">
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Button
                </button>
                <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Button
                </button>
            </div>
    </div>

</template>

<style scoped lang="scss">
    @import './style.scss';
</style>
