<template>
  <div id="app">
    <div class="panel-left">
      <ShopMenu
      :MenuBarCus="MenuBarCus"
      />
    </div>
    <div class="panel-right">
      <ShopHeader/>
      <div class="content">
        <ShopContent
          :Shops="Shops"
          @showShop="showShop"
          @addShop="addShop"
          @cloneShop="cloneShop"
          @deleteShop="deleteShop"
          @refreshData="refreshData"
          @nextPage="nextPage"
          @changePage="changePage"
          :page="pageNum"
          @changeSort="changeSort"
        />
      </div>
    </div>
    <ShopDialogAdd
      :isDialogAddHide="isDialogAddHide"          
      @btnCloseDialog="btnCloseDialog"
      @saveInformation="saveInformation"
      :shop="shop"  
      :citys="formatCitys"   
      :districts="formatDistricts"
      :wards="formatWards"    
      :isDeleteHide="isDeleteHide"        
      @deleteShop="deleteShop"
      @changeDistrict="changeDistrict"
      @changeWard="changeWard"
         
    />
    <ShopDialogPopUp
      :isDialogPopupHide="isDialogPopupHide"
      :msgPopUp="msgPopUp"
      @btnCancelPopup="btnCancelPopup"
      :isDeleteCf="isDeleteCf"
      @saveInformation="saveInformation"
    />
    
  </div>
</template>

<script>
import 'regenerator-runtime/runtime';
import * as axios from "axios";
import ShopMenu from './Shop/ShopMenu.vue';
import ShopHeader from './Shop/ShopHeader';
import ShopContent from './Shop/ShopContent.vue';
import ShopDialogAdd from './Shop/ShopDialogAdd';
import ShopDialogPopUp from './Shop/ShopDialogPopUp.vue';

//import css ngoài
import '../public/css/button.css';
import '../public/css/input.css';

export default {
  name: 'app',
  data () {
    return {
      //Tổng số trang
      allNumOfPage:250,
      //Sắp xếp theo
      filter:"ShopCode",
      //Cách sắp tăng (0) hoặc giảm (1)
      desc:1,
      //Trang hiện tại
      pageNum:1,
      //Confim xóa
      isDeleteCf:true,
      //Ản thông báo
      isDialogPopupHide:true,
      //Nội dung thông báo
      msgPopUp:"Thông báo",
      //ẩn dialog
      isDialogAddHide:true,
      //nút xóa ẩn
      isDeleteHide:false,
      //Mã code trả về
      coderes:400,
      MenuBarCus:[
          {class:"fas fa-chart-bar", title:'Tổng quan'},
          {class:"fas fa-chart-pie", title:'Báo cáo'},
          {class:"fas fa-shipping-fast", title:'Đơn hàng'},
          {class:"fas fa-shopping-cart", title:'Mua hàng'},
          {class:"fas fa-gift", title:'Khuyến mại'},
          {class:"fas fa-list", title:'Quản lý cửa hàng'},
          {class:"fab fa-buffer", title:'Hàng hóa'},

      ],
      Shops:[
        
      ],
      
      shop:{
        shopId: "13009ae2-3273-11e8-fb69-4afe230d73a5",
        shopCode: "",
        shopName: "Hoàng Ngọc Anhhhhhhhhhhhhh",
        shopAddress: "2000-12-21",       
        shopPhone: "151515155115",
        shopTaxCode:"111111",
        shopNation: "Việt Nam" ,   
        shopCity: "Hà nội" , 
        shopDistrict: "Hà nội" , 
        shopWard: "Hà nội" , 
        shopStreet:"D",   
        shopStatus: "Đã nghỉiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii",
      },

      citys:[],
      districts:[],
      wards:[],
      }
    },
       methods:{
      //Thay đổi quận huyện theo tỉnh
      async changeDistrict(data){       
        for(let city of this.citys){
          if(city.name == data){
            data = city.matp;break;

          }
        }
        const response =await axios.get("http://localhost:52327/api/v1/Districts?id="+data)
        this.districts = response.data;
      },

      //Thay đổi làng xã theo quận huyện
      async changeWard(data){
        for(let district of this.districts){
          if(district.name == data){
            data = district.maqh;break;

          }
        }
        const response =await axios.get("http://localhost:52327/api/v1/Wards?id="+data)
        this.wards = response.data;
      },

      changeSort(sort){
      
        if(this.filter != sort){
          this.filter = sort;
          this.desc = 1;
        }else {
          if(this.desc == 0 )this.desc = 1;
          else this.desc = 0;
        }
        this.refreshData();
      },
      
      //Ản thông báo
      btnCancelPopup(){
        this.isDialogPopupHide=true;
        this.isDeleteCf=true;
        if(this.coderes == 201){
          this.coderes=400;
          this.isDialogAddHide=true;
        }
      },

      //nhân bản 1 shop
      cloneShop(data){   
        axios.post("http://localhost:52327/api/v1/Shops/clone", data)
            .then(response => {
              this.msgPopUp=response.data;
              this.isDialogPopupHide=false;
              this.coderes==400;
              this.refreshData();
            })
            .catch(err => {
                if (err.response) {
                this.msgPopUp=err.response.data.userMsg;
                this.isDialogPopupHide=false;
                this.coderes==400;
                } else if (err.request) {
                console.log(err.request)
                } else {
                
                }
            })
      },

      //xóa shop
      deleteShop(data){
        
        if(data != 0){
          this.shop = data;
        }      
        //gọi Thông báo delete
        this.msgPopUp="Bạn có muốn xóa cửa hàng "+ this.shop.shopName+" Khỏi danh sách cửa hàng không ?";
        this.isDialogPopupHide=false;
        this.isDeleteCf=false;
        //Hiêm thông báo khi xóa xong
      },

      //phân trang
      nextPage(num){
            this.pageNum += num;
            if(this.pageNum < 1) this.pageNum = 1;
            else if(this.pageNum > this.allNumOfPage) this.pageNum = this.allNumOfPage;
            this.refreshData();
        },
      changePage(num){
            if(this.pageNum = 0){
              this.pageNum = 1;
            }else this.pageNum = this.allNumOfPage;
            this.refreshData();
        },

      //refresh dữ liệu table
      async refreshData(){
          //Tạo hoạt ảnh loading
          //Lấy dữ liệu
          const response =await axios.get("http://localhost:52327/api/v1/Shops/sort?page="+this.pageNum+"&filter="+this.filter+"&desc="+this.desc);
          this.Shops = response.data;
          
      },

      //Xử lý hiển thị 1 nhân viên  
      showShop(data){
        //hiển thị dialog
        this.isDialogAddHide=false;
        //hiểm thị nút xóa
        this.isDeleteHide=false;
        this.shop = data;
      },

      //Nút đóng Cửa sổ thêm nhân viên  
      btnCloseDialog(){
          this.isDeleteHide=true;
          this.isDialogAddHide=true;
      },

      //mở bảng thêm nhân viên
      addShop(){
          this.shop = {
            shopId: "13009ae2-3273-11e8-fb69-4afe230d73a5",
            shopCode: "",
            shopName: "",
            shopAddress: "",
            shopPhone: "",
            shopNation:"Việt Nam",
            shopCity:"Tỉnh thành",
            shopDistrict:"002",
            shopWard:"00058",
            shopTaxCode:"",
            shopStreet:"",
            shopStatus: "Đang hoạt động",
            }
          // mở dialog
            this.isDeleteHide=true;
            this.isDialogAddHide=false;
            
          //lấy mã code cao nhất
          // đẩy vào code
            this.getHighestCode();

      },

      //Lưu nhân viên bao gồm cả thêm mới, sửa và xóa nhân viên  
      saveInformation(num){
          //kiểm tra là thêm hay sửa
          if(num == 2 && this.validate()){
          //Thêm cửa hàng mới
          axios.post("http://localhost:52327/api/v1/Shops", this.shop)
            .then(response => {
               
                this.msgPopUp=response.data;
                this.coderes = response.status;
                //Mở popup
                this.isDialogPopupHide=false;
                this.refreshData();
            })
            .catch(err => {
                if (err.response) {
                console.log(err.response.data);
                this.msgPopUp=err.response.data.userMsg;
                this.isDialogPopupHide=false;
                } else if (err.request) {
                console.log(err.request)
                } else {
                
                }
            })
          }else if(num == 1 && this.validate()){
            //Sửa cửa hàng
            axios.put("http://localhost:52327/api/v1/Shops", this.shop)
            .then(response => {
                this.msgPopUp=response.data;
                this.coderes = response.status;
                //Mở popup
                this.isDialogPopupHide=false;
                this.refreshData();
            })
            .catch(err => {
                if (err.response) {
                console.log(err.response.data);
                this.msgPopUp=err.response.data.userMsg;
                this.isDialogPopupHide=false;
                } else if (err.request) {
                console.log(err.request)
                } else {
                
                }
            })
          }else if(num == 3){
            //Xóa cửa hàng
            axios.delete("http://localhost:52327/api/v1/Shops", { data: this.shop })
            .then(response => {
                this.msgPopUp=response.data;
                this.coderes = response.status;
                this.isDeleteHide=true;
                this.isDeleteCf=true;
                //Mở popup
                this.isDialogPopupHide=false;
                //refresh dữ liệu
                this.refreshData();
            })
            .catch(err => {
                if (err.response) {
                console.log(err.response.data);
                this.msgPopUp=err.response.data.userMsg;
                this.isDialogPopupHide=false;
                this.isDeleteHide=true;
                this.isDeleteCf=true;
                } else if (err.request) {
                console.log(err.request)
                } else {
                
                }
            })
          }else{}
          
      },

      //validate
      validate(){
        
        if(this.shop.shopCode == null|| this.shop.shopCode.trim() == ""){
          this.msgPopUp="Mã cửa hàng không được phép để trống";
          this.isDialogPopupHide=false;
          this.isDeleteCf=true;
          return false;
        }else if (this.shop.shopName == null|| this.shop.shopName.trim() == ""){
          console.log("b");
          this.msgPopUp="Tên cửa hàng không được phép để trống";
          this.isDialogPopupHide=false;
          this.isDeleteCf=true;
          return false;
        }else if (this.shop.shopAddress == null|| this.shop.shopAddress.trim() == ""){
          this.msgPopUp="Địa chỉ cửa hàng không được phép để trống";
          this.isDialogPopupHide=false;
          this.isDeleteCf=true;
          return false;
        }else return true;
      },

      listenShowShop (event) {
      if (event.keyCode === 13 && event.altKey) {
        this.addShop();
      }
    },

      async getHighestCode() {
          const response =await axios.get("http://localhost:52327/api/v1/Shops/code");
          this.shop.shopCode = response.data;
      },
     },

  computed:{
    formatCitys:function(){
      let citys = new Array;
      for(let i = 0; i < this.citys.length;i++){
        citys[i] = this.citys[i].name;
      }
      return citys;
    },
    formatDistricts:function(){
      let districts = new Array;
      console.log("z");
      for(let i = 0; i < this.districts.length;i++){
        districts[i] = this.districts[i].name;
        
      }
      console.log(districts);
      return districts;
    },
    formatWards:function(){
      let wards = new Array;
      for(let i = 0; i < this.wards.length;i++){
        wards[i] = this.wards[i].name;
      }
      return wards;
    },
    

  },

  
  components:{
    ShopMenu,
    ShopHeader,
    ShopContent,
    ShopDialogAdd,
    ShopDialogPopUp,
  },
   mounted() {
      let fontScript = document.createElement('script');
      fontScript.setAttribute('src', 'https://kit.fontawesome.com/a5d35b3d52.js');
      fontScript.setAttribute('crossorigin', 'anonymous');
      document.head.appendChild(fontScript);
  },
  async created() {
    const response =await axios.get("http://localhost:52327/api/v1/Shops/sort?page="+this.pageNum+"&filter="+this.filter+"&desc="+this.desc);
    const a= await axios.get("http://localhost:52327/api/v1/Citys");  //sửa

    this.citys=a.data;
    this.Shops = response.data;

    window.addEventListener(
    'keyup',
    this.listenShowShop
  )
    
  },
  destroyed () {
  window.removeEventListener(
    'keyup',
    this.listenShowShop
  )
}
 
  
}

</script>

<style>
body {
    margin:0px;
    font-family: GoogleSans-Regular;
    font-size: 13px;
    
}
@font-face {
    font-family: 'GoogleSans-Italic';
    src: url('/public/font/GoogleSans-Italic.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Bold';
    src: url('/public/font/GoogleSans-Bold.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Regular';
    src: url('/public/font/GoogleSans-Regular.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Medium';
    src: url('/public/font/GoogleSans-Medium.otf') format('opentype');
}

#app{
  display: flex;
}
.panel-left {
    width: 220px;
    height: 100vh;
    background-color: #026b97;
    color: #ffffff;
}
.panel-right {
    width: calc(100% - 220px);
    height: 100vh;
    
}
.content{
  width: calc(100% - 236px);
  height: calc(100% - 71px);
  position: absolute;
  background-color: #e5e6eb;
  padding: 8px;
}
::-webkit-scrollbar {
    width: 5px !important;
    height: 5px !important;
    z-index: 2
}

::-webkit-scrollbar-track {
    width: 6px;
    background-color: #bbb;
}

::-webkit-scrollbar-thumb {
    background-color: #808080;
    border-radius: 8px
}
</style>
