<template>
  <div class="dialog-popup" :class="{isDialogPopupHide:isDialogPopupHide}">
      <div class="dialog-modal"></div>
        <div class="dialog-popup-content">
            <div class="dialog-header">
          <div class="dialog-header-titlepopup">Thông báo</div>
          <div class="dialog-header-close" @click="btnCancelPopup">
            <button>x</button>
          </div>
        </div>
            <div class="dialog-body">
                <div id="notify-text">{{ msgPopUp }}</div>

            </div>
            <div class="dialog-footer">
                <button id="btnDeleteCf" class="m-btn m-btn-delete" :class="{isDeleteCf:isDeleteCf}" @click="saveInformation(3)"><i class="fas fa-trash-alt" style="margin-right:5px"></i><span class="btn-text">Xóa</span></button>
                <button id="btnCancelCf" class="m-btn m-btn-default" @click="btnCancelPopup"><i class="fas fa-times" style="margin-right:5px"></i><span class="btn-text">Hủy bỏ</span></button>
                
            </div>
        </div>
    
  </div>
</template>

<script>
export default {
    name:'ShopDialogPopUp',
    props:{
        isDialogPopupHide:{
            type:Boolean,
            default:true,
        },
        isDeleteCf:{
            type:Boolean,
            default:true,
        },
        msgPopUp:{
            type:String,
            default:"",
        }

    },
    methods:{
        btnCancelPopup(){
            this.$emit('btnCancelPopup');
        },
        saveInformation(num){
            this.btnCancelPopup();
            this.$emit('saveInformation',num)
        }
    }
}
</script>

<style>
.isDeleteCf{
    display: none;
}
.isDialogPopupHide{
    display: none;
}
.dialog-popup-content{
    position: absolute;
        background-color: #ffffff;

        z-index: 110;
        border-radius: 5px;
        width: 380px;
        height:auto;
        top:280px;
        left:600px;
        border: unset;
}
.dialog-header .dialog-header-titlepopup {
            font-size: 15px;
            
            font-weight: bold;
}
.dialog-popup-content .dialog-body{
    padding: 24px 24px 24px;
}
</style>