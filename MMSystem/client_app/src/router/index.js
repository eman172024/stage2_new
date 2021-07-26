import { createRouter, createWebHistory } from 'vue-router'
import Login from '../views/Auth/Login.vue'

const routes = [{
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    // route level code-splitting
    // this generates a separate chunk (dashboard.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
        import ( /* webpackChunkName: "dashboard" */ '../views/Dashboard/Dashboard.vue')
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
