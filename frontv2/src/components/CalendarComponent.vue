<template>
  <div>
    <v-card width="1050" elevation="9">
      <v-card-title class="d-flex justify-space-between py-4 px-7">
        <svg  class="pic" @click="otherMonth('prev')" id="Layer_1_1_" style="enable-background:new 0 0 16 16;" version="1.1" viewBox="0 0 16 16" xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><path d="M8,0C3.582,0,0,3.582,0,8s3.582,8,8,8s8-3.582,8-8S12.418,0,8,0z M6.354,13.354l-0.707-0.707L10.293,8L5.646,3.354  l0.707-0.707L11.707,8L6.354,13.354z"/></svg>
        <span class="primary--text">{{monthsArray[currentMonth]}}, {{currentYear}}</span>
        <svg  class="pic" @click="otherMonth('next')" id="Layer_1_1_" style="enable-background:new 0 0 16 16;" version="1.1" viewBox="0 0 16 16" xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><path d="M8,0C3.582,0,0,3.582,0,8s3.582,8,8,8s8-3.582,8-8S12.418,0,8,0z M6.354,13.354l-0.707-0.707L10.293,8L5.646,3.354  l0.707-0.707L11.707,8L6.354,13.354z"/></svg>
      </v-card-title>
      <v-card-text class="pb-10 px-9 pt-4">
        <v-row class="primary--text">
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Monday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Tuesday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Wednsday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Thursday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Friday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Saturday</strong>
          </v-col>
          <v-col class="px-5 py-3 d-flex justify-center">
            <strong>Sunday</strong>
          </v-col>
        </v-row>
        <v-row>
          <v-col>
            <v-row v-for="(item, index) of mondayArr" :key="index">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'current-date': currentDay === item.date,
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (mondayArr.length - 1),
                  'border-right': !tuesdayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of tuesdayArr" :key="(index+1) * 10">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (tuesdayArr.length - 1),
                  'border-right': !wednsdayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of wednsdayArr" :key="(index+1) * 20">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (wednsdayArr.length - 1),
                  'border-right': !thursdayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of thursdayArr" :key="(index+1) * 30">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (thursdayArr.length - 1),
                  'border-right': !fridayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of fridayArr" :key="(index+1) * 40">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (fridayArr.length - 1),
                  'border-right': !saturdayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of saturdayArr" :key="(index+1) * 50">
              <v-col cols="12"
                class="items-border px-3"
                v-bind:class="{
                  'clean-border': !item.date,
                  'no-border': item.date,
                  'border-bottom': index === (saturdayArr.length - 1),
                  'border-right': !sundayArr[index] && item.date
                }">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
          <v-col>
            <v-row v-for="(item, index) of sundayArr" :key="(index+1) * 60">
              <v-col cols="12"
                class="items-border px-3 border-right"
                v-bind:class="{'clean-border': !item.date, 'no-border': item.date, 'border-bottom': index === (sundayArr.length - 1)}">
                <span v-if="item.date">{{item.date}}</span>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'Calendar-component',
  data () {
    return {
      currentDay: null,
      currentMonth: null,
      currentYear: null,
      monthsArray: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'Octember', 'November', 'December'],
      daysArray: [],
      mondayArr: [],
      tuesdayArr: [],
      wednsdayArr: [],
      thursdayArr: [],
      fridayArr: [],
      saturdayArr: [],
      sundayArr: [],
      days: null
    }
  },
  mounted () {
    this.currentDay = new Date().getDate()
    this.currentMonth = new Date().getMonth()
    this.currentYear = new Date().getFullYear()
    const date1 = new Date(this.currentYear, this.currentMonth, 1)
    const date2 = new Date(this.currentYear, this.currentMonth + 1, 1)
    this.days = Math.round((date2 - date1) / 1000 / 3600 / 24)
    this.setDaysArray(this.days)
  },
  methods: {
    setDaysArray (count) {
      this.daysArray.length = count
      // eslint-disable-next-line
      for (let i = 0; i < count; i++) {
        this.daysArray[i] = {}
        this.daysArray[i].date = i + 1
        this.daysArray[i].day = new Date(this.currentYear, this.currentMonth, i + 1).getDay()
      }
      /* eslint-disable */
      this.daysArray.map((item, index) => {
        switch (item.day) {
          case 0:
            this.sundayArr.push(item)
            break;
          case 1:
            this.mondayArr.push(item)
            break;
          case 2:
            this.tuesdayArr.push(item)
            break;
          case 3:
            this.wednsdayArr.push(item)
            break;
          case 4:
            this.thursdayArr.push(item)
            break;
          case 5:
            this.fridayArr.push(item)
            break;
          case 6:
            this.saturdayArr.push(item)
            break;
        }
      })
      if (this.mondayArr[0].date > 1) this.mondayArr.unshift(0)
      if (this.tuesdayArr[0].date > 1 && this.mondayArr[0] === 0) this.tuesdayArr.unshift(0)
      if (this.wednsdayArr[0].date > 1 && this.tuesdayArr[0] === 0) this.wednsdayArr.unshift(0)
      if (this.thursdayArr[0].date > 1 && this.wednsdayArr[0] === 0) this.thursdayArr.unshift(0)
      if (this.fridayArr[0].date > 1 && this.thursdayArr[0] === 0) this.fridayArr.unshift(0)
      if (this.saturdayArr[0].date > 1 && this.fridayArr[0] === 0) this.saturdayArr.unshift(0)
      if (this.sundayArr[0].date > 1 && this.saturdayArr[0] === 0) this.sundayArr.unshift(0)
    },
    otherMonth (type) {
      this.mondayArr = []
      this.tuesdayArr = []
      this.wednsdayArr = []
      this.thursdayArr = []
      this.fridayArr = []
      this.saturdayArr = []
      this.sundayArr = []
      if (type === 'next') {
        this.currentMonth++
        if (this.currentMonth > 11) {
          this.currentMonth = 0
          this.currentYear++
        }
        const date1 = new Date(this.currentYear, this.currentMonth, 1)
        const date2 = new Date(this.currentYear, this.currentMonth + 1, 1)
        this.days = Math.round((date2 - date1) / 1000 / 3600 / 24)
        this.setDaysArray(this.days)
      }
      if (type === 'prev') {
        this.currentMonth--
        if (this.currentMonth < 0) {
          this.currentMonth = 11
          this.currentYear--
        }
        const date1 = new Date(this.currentYear, this.currentMonth, 1)
        const date2 = new Date(this.currentYear, this.currentMonth + 1, 1)
        this.days = Math.round((date2 - date1) / 1000 / 3600 / 24)
        this.setDaysArray(this.days)
      }
    }
  }
}
</script>

<style scoped>
.items-border{
  height: 55px;
  border: 1px solid rgba(0, 0, 0, 0.532);
  transition: 0.3s;
}
.items-border:hover{
  transition: 0.3s;
  border: 3px solid #2196F3;
  border-radius: 2px;
  transform: scale(1.02);
  cursor: pointer;
}
.clean-border{
  border: none;
}
.no-border{
  border-bottom: none;
  border-right: none;
}
.border-bottom{
  border-bottom: 1px solid rgba(0, 0, 0, 0.532);
}
.border-right{
  border-right: 1px solid rgba(0, 0, 0, 0.532);
}
.pic{
  width: 25px;
  height: 25px;
}
.pic:first-child{
  transform: rotate(180deg);
}
.pic:hover{
  fill: #2196F3;
  cursor: pointer;
}
.current-date{
  border: 3px solid #c00def;
  border-image: linear-gradient(45deg, #fead96, #c00def);
  border-image-slice: 1;
  border-radius: 2px;
}
</style>
