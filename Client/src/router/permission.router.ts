
import { RouteConfig } from 'vue-router';
const item = {
    path: '/',
    component: () => import('../base.vue'),
    children: [
        {
            path: '',
            component: () => import('../views/permission/list.vue'),
        },
        {
            path: 'add',
            component: () => import('../views/permission/add.vue'),
        },
        {
            path: 'edit/:id',
            component: () => import('../views/permission/edit.vue'),
        }
    ]
} as RouteConfig

export default item;