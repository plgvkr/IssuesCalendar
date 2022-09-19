<template>
  <div class="helper">
    <div class="navigation-wrapper white d-flex justify-center align-center" @click="activeSwitch = !activeSwitch">
      <svg class="pic" style="enable-background:new 0 0 24 24;" version="1.1" viewBox="0 0 24 24" xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><g id="info"/><g id="icons"><path d="M22.2,14.4L21,13.7c-1.3-0.8-1.3-2.7,0-3.5l1.2-0.7c1-0.6,1.3-1.8,0.7-2.7l-1-1.7c-0.6-1-1.8-1.3-2.7-0.7   L18,5.1c-1.3,0.8-3-0.2-3-1.7V2c0-1.1-0.9-2-2-2h-2C9.9,0,9,0.9,9,2v1.3c0,1.5-1.7,2.5-3,1.7L4.8,4.4c-1-0.6-2.2-0.2-2.7,0.7   l-1,1.7C0.6,7.8,0.9,9,1.8,9.6L3,10.3C4.3,11,4.3,13,3,13.7l-1.2,0.7c-1,0.6-1.3,1.8-0.7,2.7l1,1.7c0.6,1,1.8,1.3,2.7,0.7L6,18.9   c1.3-0.8,3,0.2,3,1.7V22c0,1.1,0.9,2,2,2h2c1.1,0,2-0.9,2-2v-1.3c0-1.5,1.7-2.5,3-1.7l1.2,0.7c1,0.6,2.2,0.2,2.7-0.7l1-1.7   C23.4,16.2,23.1,15,22.2,14.4z M12,16c-2.2,0-4-1.8-4-4c0-2.2,1.8-4,4-4s4,1.8,4,4C16,14.2,14.2,16,12,16z" id="settings"/></g></svg>
    </div>
    <span style="--i:0;" class="option-element white d-flex justify-center align-center" v-bind:class="{'option-element__active': activeSwitch}" @click="openIssueModal">
      <svg class="option-element__pic" id="Layer_1" style="enable-background:new 0 0 30 30;" version="1.1" viewBox="0 0 30 30" xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><path d="M24,13.328V24H6V10h10.672l6-6H6C4.895,4,4,4.895,4,6v18c0,1.105,0.895,2,2,2h18c1.105,0,2-0.895,2-2V11.329L24,13.328z"/><g><path d="M28.957,5.543l0.525-0.525c0.69-0.69,0.69-1.81,0-2.5s-1.81-0.69-2.5,0l-0.525,0.525L28.957,5.543z"/></g><g><polygon points="25.043,4.457 14.475,15.025 14,18 16.975,17.525 27.543,6.957  "/></g></svg>
    </span>
    <span @click="pushTo('Calendar')" style="--i:1;" class="option-element white d-flex justify-center align-center" v-bind:class="{'option-element__active': activeSwitch}">
      <svg class="option-element__pic" id="Layer_1" style="enable-background:new 0 0 24 24;" version="1.1" viewBox="0 0 24 24" xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><title/><g id="Christmas_Date"><g><path d="M11,14c0-1.105-0.895-2-2-2s-2,0.895-2,2c0,0.276,0.224,0.5,0.5,0.5S8,14.276,8,14    c0-0.552,0.448-1,1-1s1,0.448,1,1c-0.001,0.525-0.188,1.032-0.53,1.43l-2.35,2.74c-0.182,0.207-0.162,0.523,0.046,0.706    C7.258,18.957,7.377,19.001,7.5,19h3c0.276,0,0.5-0.224,0.5-0.5S10.776,18,10.5,18H8.59l1.64-1.92    C10.726,15.501,10.999,14.763,11,14z"/><path d="M15.5,13c0.276,0,0.5-0.224,0.5-0.5S15.776,12,15.5,12H13c-0.244,0.002-0.451,0.179-0.49,0.42    l-0.5,3c-0.05,0.271,0.129,0.532,0.4,0.583c0.164,0.031,0.333-0.023,0.45-0.143c0.251-0.242,0.592-0.368,0.94-0.35    c0.66,0.005,1.195,0.54,1.2,1.2V17c0,0.552-0.448,1-1,1s-1-0.448-1-1c0-0.276-0.224-0.5-0.5-0.5S12,16.724,12,17    c0,1.105,0.895,2,2,2s2-0.895,2-2v-0.29c-0.046-1.264-1.107-2.252-2.371-2.206c-0.158,0.006-0.315,0.028-0.469,0.066L13.42,13    H15.5z"/><path d="M21,3h-2.5C18.224,3,18,3.224,18,3.5V6c0.002,0.552-0.444,1.002-0.996,1.004    C16.452,7.006,16.002,6.56,16,6.008c-0.002-0.427,0.267-0.807,0.67-0.948C16.868,4.988,17,4.801,17,4.59V1.5    C17,1.224,16.776,1,16.5,1S16,1.224,16,1.5V3H8.5C8.224,3,8,3.224,8,3.5V6c0.002,0.552-0.444,1.002-0.996,1.004    C6.452,7.006,6.002,6.56,6,6.008C5.998,5.581,6.267,5.201,6.67,5.06C6.868,4.988,7,4.801,7,4.59V1.5C7,1.224,6.776,1,6.5,1    S6,1.224,6,1.5V3H3C1.895,3,1,3.895,1,5v16c0,1.105,0.895,2,2,2h14.29c0.266,0.002,0.521-0.103,0.71-0.29L22.71,18    c0.187-0.189,0.292-0.444,0.29-0.71V5C23,3.895,22.105,3,21,3z M3,21V9h18v7.88L20.88,17H19c-1.105,0-2,0.895-2,2v1.88L16.88,21    L3,21z"/></g></g></svg>
    </span>
    <span @click="pushTo('IssuesList')" style="--i:2;" class="option-element white d-flex justify-center align-center" v-bind:class="{'option-element__active': activeSwitch}">
      <svg class="option-element__pic" viewBox="0 0 32 32" xmlns="http://www.w3.org/2000/svg"><title/><g data-name="menu " id="menu_"><path d="M29,6H3A1,1,0,0,0,3,8H29a1,1,0,0,0,0-2Z"/><path d="M3,17H16a1,1,0,0,0,0-2H3a1,1,0,0,0,0,2Z"/><path d="M25,24H3a1,1,0,0,0,0,2H25a1,1,0,0,0,0-2Z"/></g></svg>
    </span>
  </div>
</template>

<script>

export default {
  name: 'Navigation-component',
  data () {
    return {
      activeSwitch: false
    }
  },
  methods: {
    openIssueModal () {
      this.$store.dispatch('modal/toogleAction')
    },
    pushTo (name) {
      this.$router.push({ name: `${name}` })
    }
  }
}
</script>

<style scoped>
.helper{
  position: relative;
}
.navigation-wrapper{
  width: 50px;
  height: 50px;
  border-radius: 50%;
  position: fixed;
  top: 22px;
  right: 22px;
  cursor: pointer;
  transition: 0.5s;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  transition: 0.5s;
}
.navigation-wrapper:hover{
  transition: 0.5s;
  transform: scale(1.05);
}
.navigation-wrapper:hover .pic{
  fill: #2196F3;
}
.pic{
  width: 22px;
  height: 22px;
}
.option-element{
  position: absolute;
  right: 102px;
  top: 11px;
  width: 45px;
  height: 45px;
  border-radius: 50%;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  transition: 0.5s;
  transform-origin: 140px;
  transform: rotate(calc(0deg)) translateX(100px);
  opacity: 0;
}
.option-element:hover{
  cursor: pointer;
}
.option-element:hover .option-element__pic{
  fill: #2196F3;
}
.option-element__active{
  transform: rotate(calc(-105deg / 3 * var(--i)));
  opacity: 1;
  transition: 0.5s;
}
.option-element__pic{
  width: 20px;
  height: 20px;
  transform: rotate(calc(105deg / 3 * var(--i)));
}
</style>
