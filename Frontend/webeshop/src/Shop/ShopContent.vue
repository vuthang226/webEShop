<template>
  <div class="shop-content">
       <div class="table-all">
            <div class="table-tool">
                <div class="tool-add" @click="addShop()">
                    <div class="icon-add"></div>
                    <p>Thêm mới</p>
                </div>
                <div class="tool-clone" @click="cloneShop()">
                    <div class="icon-clone" ></div>
                    <p>Nhân bản</p>
                </div>
                <div class="tool-repair" @click="updateShop()">
                    <div class="icon-repair" ></div>
                    <p>Sửa</p>
                </div>
                <div class="tool-delete" @click="deleteShop()">
                    <div class="icon-delete" ></div>
                    <p>Xóa</p>
                </div>
                <div class="tool-refresh" @click="refreshData()">
                    <div class="icon-refresh" ></div>
                    <p>Nạp</p>
                </div>   
            </div>
            <div class="table-content">
                <table id="table-shop" cellspacing="0" cellpadding="0" border="0" >
                        <thead>
                            <tr class="title-tb1">

                                <th @click="changeSort(1)" style="width:9%;"><div class="cell">Mã cửa hàng</div></th>
                                <th @click="changeSort(2)" style="width:20%"><div class="cell">Tên cửa hàng</div></th>
                                <th style="width:48%"><div class="cell">Địa chị</div></th>
                                <th style="width:11%"><div class="cell">Số điện thoại</div></th>
                                <th @click="changeSort(3)" style="width:11%"><div class="cell">Trạng thái</div></th>
                                
                            </tr>
                        </thead>
                        <tbody class="tb1">
                            <tr 
                                v-for="shop in Shops"
                                v-bind:key="shop.shopId"
                                :class="{focusline:shop.shopId == focusLine}"
                                @click="
                                focusShop(shop);
                                focusLine = shop.shopId;
                                "
                                
                                @dblclick="showShop(shop)">
                                
                            <td>
                                <div class="cell" >{{ shop.shopCode }}</div>
                                </td>
                                <td>
                                <div class="cell" >{{ formatEmpty(shop.shopName) }}</div>
                                </td>
                                <td>
                                <div class="cell" >{{ formatEmpty(shop.shopAddress) }}</div>
                                </td>
                                <td>
                                <div class="cell" >{{ formatEmpty(shop.shopPhone) }}</div>
                                </td>
                                <td>
                                <div class="cell" >{{ formatEmpty(shop.shopStatus) }}</div>
                                </td>
                            </tr>
                
                        </tbody>
                </table>
            </div>

        </div> 


      <div class="paging-bar">
          <div class="paging-left">
                <button class="btn-square" @click="changePage(0)"><i class="fas fa-angle-double-left"></i></button>
                <button class="btn-square" @click="nextPage(-1)"><i class="fas fa-angle-left"></i></button>
                
                <p class="paging-item">Trang</p>
                <input class="input-page" tabindex="10"/>
                <p class="paging-item">trên 1</p>
                
                <button class="btn-square" @click="nextPage(1)"><i class="fas fa-angle-right"></i></button>
                <button class="btn-square" @click="changePage(1)"><i class="fas fa-angle-double-right"></i></button>
                <button class="btn-square"><i class="fas fa-sync-alt"></i></button>
                

                

          </div>
          <div class="paging-right">
              Hiển thị 1-20 trên 1000 kết quả 
              <div></div>
          </div>
      </div>

  </div>
</template>

<script>

import ShopSelectCustom from './ShopSelectCustom.vue'
export default {
    name:'ShopContent',
    props:{
        page:{
            type:Number,
            default:1,
        }
        
    },
    data(){
        return{
            data:{},
            focusLine:"",
        }
    },
    props:{
        Shops:Array
            
    },
    methods:{
        addShop(){
            this.$emit('addShop');
        },
        cloneShop(){
            this.$emit('cloneShop',this.data);
        },
        updateShop(){
            this.showShop(this.data);
        },
        deleteShop(){
            this.$emit('deleteShop',this.data);
        },
        refreshData(){
            this.$emit('refreshData');
        },
        focusShop(data){
            this.data = data;
        },
        nextPage(num){
            this.$emit('nextPage',num)
        },
        changePage(num){
            this.$emit('changePage',num)
        },
        showShop(data){           
            this.$emit('showShop',data);
        },
        changeSort(sort){
            if(sort == 1)sort = "ShopCode";
            else if(sort == 2) sort = "ShopName";
            else if(sort == 3) sort = "ShopStatus";
            else sort = "ShopName";
            this.$emit('changeSort',sort);
        },
        formatEmpty(data){
        
            if(data == null){
                return "(Trống)";
            }else if(data.trim() == "") return "(Trống)";
            else return data.trim();
        },
        // formatAddress(data){},
    },

    components:{       
        ShopSelectCustom,
    }
}
</script>

<style>
.focusline{
    background-color: #c3ecff !important;
    cursor: pointer;
}
.shop-content{
    width: 100%;
    height: 100%;
    background-color: #ffffff;
}
.shop-content .paging-bar{
    

    height: 55.4px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0px 20px 0px 12px;
    z-index: 3;
}
.shop-content .paging-bar .paging-left{
    display: flex;
    justify-content: space-between;
    align-items: center;
}
.table-all{

    height: calc(100% - 55.4px);
}
.table-content{
    width:100%;
    height: calc(100% - 55.4px);
    overflow: auto;
}
#table-shop{
    border-collapse:collapse;
    width: 100%;
}
/* cố định phần tiêu đề của bảng */
.table-content table th {
    z-index: 3;
    position: sticky;
    background-color: #F0F0F0;
    /* background-color: #ededed; */
    top: 0px;
    left: 0px;
    font-weight: bold !important;
    /* border: 1px solid #E9E9E9; */
    border: 1px solid #c1c1c1;
    height: 38px;
    cursor: pointer;
}

/* Tạo css cho từng dòng phâng tử: tự động ẩn nếu phần chữ tràn */
.table-content table  td {
    border: 1px solid #c1c1c1;
    padding: 10px 10px !important;
    text-align: left;
    white-space: nowrap;
    box-sizing: border-box;
    text-overflow: ellipsis;
    word-break: break-all;
}

/* Tạo hover cho từng dòng dữ liệu */
.table-content tbody tr:nth-child(2n) {
    background-color: #fafafa;
}

.table-content tbody tr:hover {
    background-color: #d1f1ff;
    cursor: pointer;
}


.table-content td div {
    white-space: nowrap;
    box-sizing: border-box;
    overflow: hidden;
    text-overflow: ellipsis;
    word-break: break-all;
}
.btn-square{
    height: 22px;
    width: 22px;
    border: 1px solid #bbbbbb;
    font-size: 12px;
    color: #bbbbbb;
    border-radius: 4px;
    display: flex;
    justify-content: center;
    align-items: center;
    margin-right: 3px;
}
.btn-square:hover{
    border: 1px solid #026b97;
    color: #026b97;
}
.btn-square:focus{
    border: 1px solid #026b97;
    color: #026b97;
}


.icon-firstpage {
	background: url('/public/icon/common-icon.png') no-repeat -656px -156px;
	width: 8px;
	height: 8px;
}
.icon-firstpage:hover {
	background: url('/public/icon/common-icon.png') no-repeat -656px -131px;
	width: 8px;
	height: 8px;
}
.icon-prevpage{
	background: url('/public/icon/common-icon.png') no-repeat -708px -156px;
	width: 5px;
	height: 8px;
}
.icon-prevpage:hover {
	background: url('/public/icon/common-icon.png') no-repeat -708px -131px;
	width: 5px;
	height: 8px;
}
.icon-nextpage{
    background: url('/public/icon/common-icon.png') no-repeat -758px -156px;
	width: 5px;
	height: 8px;
}
.icon-nextpage:hover {
    background: url('/public/icon/common-icon.png') no-repeat -758px -131px;
	width: 5px;
	height: 8px;
}

.icon-lastpage{
    background: url('/public/icon/common-icon.png') no-repeat -806px -156px;
	width: 8px;
	height: 8px;
}
.icon-lastpage:hover{
    background: url('/public/icon/common-icon.png') no-repeat -806px -131px;
	width: 8px;
	height: 8px;
}
.icon-reload:hover{
    background: url('/public/icon/common-icon.png') no-repeat -855px -128px;
	width: 10px;
	height: 14px;
}
.icon-reload{
    background: url('/public/icon/common-icon.png') no-repeat -855px -153px;
	width: 10px;
	height: 14px;
}
.paging-item{
    width: 55px;
    margin-left: 3px ;
}
.table-tool{
    display: flex;
    height: 40px;
    background-color: #026b97;
    width: 100%;
    color: #ffffff;
}
.tool-add,.tool-clone,.tool-repair,.tool-delete,.tool-refresh{
    display: flex;
    height: 40px;
    align-items: center;
    border-right:1px solid #00577b ;
    cursor: pointer;
}
.tool-add,.tool-clone{
    width: 100px;
}
.tool-repair,.tool-delete,.tool-refresh{
    width: 60px;
}

.tool-add:hover,.tool-clone:hover,.tool-repair:hover,.tool-delete:hover,.tool-refresh:hover{
    background-color: #0088c1;
}
.icon-add{
    background: url('/public/icon/common-icon.png') no-repeat -4px -130px;
	width: 11px;
	height: 10px;
    margin: 7px;
    
}
.icon-clone{
    background: url('/public/icon/common-icon.png') no-repeat -54px -204px;
	width: 11px;
	height: 12px;
    margin: 7px;
}
.icon-repair{
    background: url('/public/icon/common-icon.png') no-repeat -79px -205px;
	width: 12px;
	height: 12px;
    margin: 7px;
}
.icon-delete{
    background: url('/public/icon/common-icon.png') no-repeat -105px -204px;
	width: 10px;
	height: 12px;
    margin: 7px;
}
.icon-refresh{
    background: url('/public/icon/common-icon.png') no-repeat -129px -202px;
	width: 12px;
	height: 16px;
    margin: 7px;
}
</style>