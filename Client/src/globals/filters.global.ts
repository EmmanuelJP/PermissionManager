import moment from 'moment';
import Vue from 'vue';

Vue.filter('dateShort', (value: Date) => moment(value).format('L'));