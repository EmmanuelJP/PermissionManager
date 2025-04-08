import Vue from 'vue';
//moment
import moment from 'moment';
moment.locale('es-do');

//VeeValidate
import es from 'vee-validate/dist/locale/es'
import VeeValidate, { Validator } from 'vee-validate';

// Install the Plugin.
Vue.use(VeeValidate, {
    // This is the default
    inject: true,
    // Important to name this something other than 'fields'
    fieldsBagName: 'veeFields',
    // This is not required but avoids possible naming conflicts
    errorBagName: 'veeErrors'
});
Validator.localize('es', es);


import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)