import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Permission from '../router/permission.router';

Vue.use(VueRouter);

const routes: RouteConfig[] = [
  Permission
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

export default router;
