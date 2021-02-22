<template>
  <div class="custom-select" :tabindex="tabindex" @blur="open = false">
    <div class="selected isFocus" :class="{ open: open }" @click="open = !open">
      {{ selected }}
    </div>
    <div class="items" :class="{ selectHide: !open }">
      <div
        v-for="(option, i) of options"
        :key="i"
        :class="{iss:i == index}"
        @click="
          selected = option;
          open = false;
          $emit('input', option);
          index = i;
        "
      
      >
        {{ option }}
      </div>
    </div>
    
  </div>
</template>

<script>
export default {
  props: {
    options: {
      type: Array,
      required: true,
    },
    default: {
      type: String,
      required: false,
      default: null,
    },
    tabindex: {
      type: Number,
      required: false,
      default: 0,
    },
  },
  data() {
    return {
      selected: this.default
        ? this.default
        : this.options.length > 0
        ? this.options[0]
        : null,
      open: false,
      index:-1,
      
    };
  },
  methods:{
    
  },
  mounted() {
    this.$emit("input1", this.selected);
  },
};
</script>

<style scoped>
.iss{

  background-color:#026b97 !important;
  color: white !important;
}
.custom-select {
  position: relative;
  width: 100%;
  outline: none;
  height: 35px;
  
}

.custom-select .selected {
  display: flex;
    align-items: center;
    background-color:white;
    border-radius: 4px;
    height: 33px;
    font-size: 13px;
    color: black;
    font-family: GoogleSans-Regular;

    outline: none;
    border: 1px solid #bbbbbb;
    cursor: pointer;
    padding-left: 16px;

}

.custom-select .selected.open {
  border: 1px solid #026b97;
  border-radius: 4px;
}

.custom-select .selected:after {
  position: absolute;
  content: "";
  top: 18px;
  right: 1em;
  width: 0;
  height: 0;
  border: 5px solid transparent;
  border-color: black transparent transparent transparent;

}

.custom-select .items {
  color: black;
  overflow: hidden;
  position: absolute;
  background-color: #fff;
  max-height: 140px;
  overflow: auto;
  left: 0;
  right: 0;
  top:38px;
  z-index: 20;
  box-shadow: 1px 1px 1px 1px #E9EBEE;
}

.custom-select .items div {
  color: black;
  cursor: pointer;
  padding-left: 36px;
  user-select: none;
  height: 35px;
  display: flex;
    align-items: center;
    background-color:white;
    border: none;
    outline: none;
    cursor: pointer;
    padding-left: 36px;
}

.custom-select .items div:hover {
  background-color: #E9EBEE;
}

.selectHide {
  display: none;
}


</style>