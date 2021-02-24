<template>
        <div class="dialog-modal" :class="{isDialogAddHide:isDialogAddHide}">    
            <div class="dialog-content" >
                <div class="dialog-header">
                    <div class="dialog-header-title">Thêm mới cửa hàng</div>
                    <div class="dialog-header-close">
                        <button @click="btnCloseDialog">x</button>
                    </div>
                </div>
                <div class="dialog-body">
                    <div class="grid-dialog-container">
                        <div class="grid-item">
                            Mã cửa hàng <span class="label-required">*</span>
                        </div>
                        <div class="grid-item1">
                            <input v-model="shop.shopCode" id="shopCode" required class="input1" type="text" tabindex="0"/>
                        </div>
                        <div class="grid-item">
                            Tên cửa hàng <span class="label-required">*</span>
                        </div>
                        <div class="grid-item1">
                            <input v-model="shop.shopName" id="shopName" required class="input1" type="text" tabindex="0"/>
                        </div>
                        <div class="grid-item">
                            Địa chỉ <span class="label-required">*</span>
                        </div>
                        <div class="grid-item1">
                            <textarea v-model="shop.shopAddress" style="resize:none" rows="9" cols="70"  id="shopAddress" required class="input1 text-resize" type="text" tabindex="0"></textarea>
                        </div>
                        <div class="grid-item">
                            Số điện thoại
                        </div>
                        <div class="grid-item">
                            <input v-model="shop.shopPhone" id="shopPhone" class="input1" type="text" tabindex="0"/>
                        </div>
                        <div class="grid-item">
                            Mã số thuế
                        </div>
                        <div class="grid-item">
                            <input v-model="shop.shopTaxCode" id="shopTaxCode"  class="input1" type="text" tabindex="0"/>
                        </div>
                        <div class="grid-item">
                            Quốc gia
                        </div>
                        <div class="grid-item">
                            <ShopSelectCustom
                                :options="[]"
                                :default="shop.shopNation"
                                v-model="shop.shopNation"
                                :tabindex="0"
                        />
                        </div>
                        <div class="grid-item" >
                            <p style="display:none">Id</p>
                        </div>
                        <div class="grid-item" >
                            <input v-model="shop.shopId" style="display:none" id="shopId"  class="input1" type="text" tabindex="0"/>
                        </div>
                        <div class="grid-item">
                            Tỉnh/Thành phố
                        </div>
                        <div class="grid-item">
                            <ShopSelectCustom
                                :options="citys"
                                :default="shop.shopCity" 
                                 v-model="shop.shopCity" 
                                
                                @change="changeDistrict"
                                :tabindex="0"
                        />
                        </div>
                        <div class="grid-item">
                            Quận/Huyện
                        </div>
                        <div class="grid-item">
                            <ShopSelectCustom
                                :options="districts"
                                :default="shop.shopDistrict"
                                v-model="shop.shopDistrict" 
                                
                                @change="changeWard"
                                :tabindex="0"
                            />
                        </div>
                        <div class="grid-item">
                            Phường/Xã
                        </div>
                        <div class="grid-item">
                            <ShopSelectCustom
                                :options="wards"
                                :default="shop.shopWard"
                                v-model="shop.shopWard" 
                                :tabindex="0" 
                            />
                        </div>
                        <div class="grid-item">
                            Đường phố
                        </div>
                        <div class="grid-item">
                            <input v-model="shop.shopStreet" id="shopStreet"  class="input1" type="text" tabindex="0"/>
                        </div>
                        

                    </div>
                </div>
                <div class="dialog-footer" id="dialog-footer-add">
                    <div>
                        <button  class="m-btn m-btn-default" tabindex="2"><i class="fas fa-question-circle" style="margin-right:5px"></i><span class="btn-text">Trợ giúp</span></button>
                    </div>
                    <div class="button-area">
                <button id="btnDelete" class="m-btn m-btn-delete" :class="{isDeleteHide:isDeleteHide}" @click="deleteShop" tabindex="0"><i class="fas fa-trash-alt" style="margin-right:5px"></i><span class="btn-text">Xóa</span></button>               
                <button id="btnSave" class="m-btn " :class="{isDeleteHide:isDeleteHide}" @click="saveInformation(1)" tabindex="0"><i class="far fa-save" style="margin-right:5px"></i><span class="btn-text">Lưu</span></button>
                <button id="btnSaveAdd" class="m-btn m-btn-second" @click="saveInformation(2)" tabindex="0"><i class="fas fa-plus" style="margin-right:5px"></i><span class="btn-text">Lưu và thêm mới</span></button>
                <button id="btnCancel" class="m-btn m-btn-default" @click="btnCloseDialog" tabindex="0"><i class="fas fa-times" style="margin-right:5px"></i><span class="btn-text">Hủy bỏ</span></button>
                    </div>
            </div>
            </div>
        </div>
</template>

<script>
import ShopSelectCustom from './ShopSelectCustom.vue';
export default {
    name:'ShopDialogAdd',
    props:{
        isDialogAddHide:{
            type:Boolean,
            default:true
        },
         shop:{
             type:Object,
             default:[]
         },
         isDeleteHide:{
            type:Boolean,
            default:true
         },
        citys:{
            type:Array
        },
        districts:{
            type:Array
        },
        wards:{
            type:Array
        },

        

    },
    data(){
        return{
            data:1,
        }
    },
    methods:{
        changeDistrict(data){
            this.$emit('changeDistrict',data);
        },
        changeWard(data){
            this.$emit('changeWard',data);
        },
        btnCloseDialog(){
            this.$emit('btnCloseDialog');
        },
        saveInformation(num){
            this.$emit('saveInformation',num);
        },
        deleteShop(){
            this.data = 0;
            this.$emit('deleteShop',this.data);
            
        },
        
        
    },
    
   
    components:{
        ShopSelectCustom,
    },
    
        
    
    
}
</script>

<style>
.isDialogAddHide{
    display:none;
}
.isDeleteHide{
    display: none;
}
/* tạo nền mờ dialog */
.dialog-modal {
        
        position: fixed;
        top: 0;
        left: 0;
        bottom: 0;
        right: 0;
        background-color: rgba(0,0,0,0.4);
        z-index: 100;
        width: 100%;
        height: 100%;
}
/* Khung dialog */
.dialog-content {
        position: absolute;
        background-color: #ffffff;
        z-index: 110;
        border-radius: 5px;
        width: 650px;
        height:auto;
        top:50px;
        left:460px;
        border: unset;
        
}
.dialog-header {
    display: flex;
    padding: 13px 13px 13px 18px;
    background-color: #F0F0F0;
    border-radius: 5px 5px 0px 0px;
    border-bottom:1px solid #c1c1c1 ;
}
/* Tạo nút close */
.dialog-header .dialog-header-close {
   position: absolute;
   right: 0;
   top: 0;
}

.dialog-header .dialog-header-close:hover {
    border-radius: 5px;
}
/* Css title của dialog */
.dialog-header .dialog-header-title {
            font-size: 16px;
            font-weight: bold;
}

.dialog-content .dialog-body {
    padding: 24px 24px 24px;
}
/* Tảo footer của dialog */
.dialog-footer {
    display: flex;
    width: 100%;
    height: 60px;
    border-radius: 0 0 5px 5px;
    align-items: center;
    justify-content: flex-end;
    padding: 10px 24px 10px 6px;
    box-sizing: border-box;
    border-top:1px solid #c1c1c1 ;
}
#dialog-footer-add{
    justify-content: space-between;
}
.dialog-footer button {
        margin-left: 13px;
}
.dialog-header .dialog-header-close button {
   width: 40px;
   height: 40px;
   border-radius: 0 5px 0 0;
   border: none;
   outline: none;
   cursor: pointer;
   background-color: #F0F0F0;
   background-image: url('/public/icon/x.svg');
   background-repeat: no-repeat;
   background-position: center;  
   background-size: 20px;
   opacity: .7;
}
.dialog-header .dialog-header-close button:hover {
   background-color: #ccc;
}

.button-area{
    display: flex;
    justify-items: center;
    align-items: center;
}
/* Tạo kiến trúc dialog */
.grid-dialog-container{
    display: grid;
    grid-template-columns: 100px auto 100px auto;
    grid-row-gap:6px ;
    grid-column-gap:13px ;
}
.grid-item1{
    grid-column: 2 / span 3;
}
.text-resize{
    resize: none;
    height: 82px;
}
</style>