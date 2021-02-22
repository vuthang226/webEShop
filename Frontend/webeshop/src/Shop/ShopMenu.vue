<template>
      <div class="menu-left">
            <div class="logo">
                <div class="logo-page"></div>
            </div>
            <div class="menu">
                <div class="menu_item" 
                    v-for="(item , index) in MenuBarCus"
                    v-bind:key="index"
                    >
                    <div class="menu_item-icon">

                        <i :class=" item.class "></i>
                    </div>
                    <div class="menu_item-text">
                        {{ item.title }}
                    </div>
                </div>
                
            </div>
        </div>
    
</template>

<script>
export default {
    name:'ShopMenu',
    props:{
        MenuBarCus:{
            type:Array,
            default:[],
        
    },
    }
}
</script>

<style>
.logo {
    align-items: center;
    display: flex;
    height: 55px;
    width: 100%;
    padding-left: 5px;
}

.logo .logo-page {
    width: 100%;
    height: 55px;
    background-image: url('/public/icon/Logo_Full_White.png');
    background-size: contain;
    background-repeat:no-repeat;

}

.menu{
    width:100%;
    
}
.menu .menu_item {
        display: flex;
        height: 45px;
        align-items: center;
        padding-left:20px;       
        cursor:pointer;
}
.menu .menu_item:hover {
    background-color: #0088c1;
}
.menu .menu_item:focus {
    background-color: #00577b;
}
.menu .menu_item .menu_item-icon {
        width: 23px;
        height: 23px;
        font-size:18px ;
    }
.menu .menu_item .menu_item-text {
    margin-left:10px;
    
    }
</style>