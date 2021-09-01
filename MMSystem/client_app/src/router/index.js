import Vue from "vue";
import VueRouter from "vue-router";
// import Login from "../views/Auth/Login.vue";

Vue.use(VueRouter);

const routes = [
    // {
    //     path: "/",
    //     name: "login",
    //     component: Login,
    // },


    {
        path: "/",
        name: "dashboard",
        component: () =>
            import (
                "../views/Dashboard/Dashboard.vue"
            ),
    },


    // {
    //     path: "/dashboard",
    //     name: "dashboard",
    //     // route level code-splitting
    //     // this generates a separate chunk (dashboard.[hash].js) for this route
    //     // which is lazy-loaded when the route is visited.
    //     component: () =>
    //         import (
    //             /* webpackChunkName: "dashboard" */
    //             "../views/Dashboard/Dashboard.vue"
    //         ),
    // },


    {
        path: "/mailn",
        name: "mail",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/mail/mail.vue"
            ),
    },

    {
        path: "/mail/:mail",
        name: "mail-show",
        // route level code-splitting
        // this generates a separate chunk (mail.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mail" */ "../views/mail/mail.vue"),
    },








];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;