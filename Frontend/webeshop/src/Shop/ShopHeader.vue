<template>
  <div class="header-page">
      <div class="header-left">
        <div class="header-title">
          Cửa hàng
          <!-- <i class="fas fa-bell"></i>
          <i class="fas fa-chevron-down"></i>
          <i class="fab fa-buffer"></i>
          <i class="fas fa-cart-plus"></i>
          <i class="fas fa-chart-pie"></i>
          
          <i class="fas fa-dolly-flatbed"></i>
          <i class="fas fa-gift"></i>
          <i class="fas fa-info-circle"></i>
          <i class="fas fa-list"></i>
          <i class="fas fa-shopping-cart"></i>
          <i class="fab fa-whatsapp"></i>
          <i class="fas fa-shipping-fast"></i> -->
        </div>
      </div>
      <div class="header-right">
        <div class="header-store">
          <div class="dropdown-store">
            <ShopSelectCustom
              :options="['Cửa hàng thực phẩm', 'Cửa hàng ăn nhanh']"
              :default="'Cửa hàng thực phẩm'"
            />
          </div>
        </div>
        <div class="header-custom">
          <div id="icon-avatar">

          </div>
          <div id="name-user">
            <b>vhthanggg</b>
            
          </div>
          <div class="span-down">
            <i class="fas fa-chevron-down"></i>
          </div>

        </div>
        <div class="header-advisory">
          <div class="icon-advisory">
            <i class="fab fa-whatsapp"></i>
          </div>
        </div>
        <div class="header-notify">
          <div class="icon-notify">
            <i class="fas fa-bell"></i>
          </div>
        </div>
        <div class="header-help">
          <div class="icon-help">
            <i class="fas fa-info-circle"></i>
          </div>
        </div>

      </div>
      
  </div>
</template>

<script>
import ShopSelectCustom from './ShopSelectCustom'
export default {
    name:'ShopHeader',
    components:{
      ShopSelectCustom,
    }
}
</script>

<style>
.header-page{
  display: flex;
  height: 55px;
  width: 100%;
  background-color: #ffffff;
}
.header-left{
  display: flex;
  width: 120px;
  align-items: center;
	justify-content: center;
}
.header-title{
  font-family: 'GoogleSans-Medium';
  font-size: 16px;
}
.header-right{
  display: flex;
  position: absolute;
  right:0px;
}
.header-help,.header-notify,.header-advisory,.header-store{
  height: 55px;
  display: flex;
  align-items: center;
	justify-content: center;
}
.header-help,.header-notify{
  width: 45px;
  border-left:1px solid #e5e6eb;
}
.header-advisory{
  width: 40px;
  background-color: #026b97;
  color: #ffffff;
}
.header-custom{
  width: 140px;
  height: 55px;
  display: flex;
  align-items: center;
  justify-content: space-between;

}
.header-store{

}
.dropdown-store{
    width: 200px;
}
.icon-advisory{
  font-size: 18px;
}
.icon-notify,.icon-help{
  font-size: 16px;
}
#icon-avatar{
  width: 30px;
  height: 30px;       
  background-image: url('/public/icon/avatar-default.png');
  background-size: contain;

  margin-left: 5px;
}
.span-down{
  margin-right: 7px;
  margin-top: 2px;
  font-size: 12px;
}

</style>