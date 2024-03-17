<script lang="ts">
    export default {
        
    }
</script>

<template>
    <div class="item office-hour">
        <div class="item--icon">
            <img src="img/icons/AppHeader/clock.svg"/>
        </div>
        <div class="item--text">
            <p>Horários <br>
                da loja</p>
        </div>
    </div>
    
    
        <div class="item login">
            <div class="item--icon">
                <img src="img/icons/AppHeader/user.svg"/>
            </div>
            <div class="item--text">
                <a href="/Login"><p>Entre</p></a> 
                <span>ou</span><br>
                <a href="/Register"><p>Cadastre-se</p></a>
            </div>
        </div>
    
    <div class="item buy-list">
        <div class="item--icon">
            <img src="img/icons/AppHeader/list.svg"/>
        </div>
        <div class="item--text">
            <a href="/BuyList"><p>Lista de<br>compras</p></a>
        </div>
    </div>

    <div class="item cart">
        <div class="item--icon">
            <img src="img/icons/AppHeader/cart.svg"/>
        </div>
        <div class="item--text">0</div>
    </div>
    
</template>

<style lang="scss">
    @import './style.scss';
</style>