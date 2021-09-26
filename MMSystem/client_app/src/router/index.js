import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../views/Auth/Login.vue";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "login",
        component: Login,
    },

    // dashboard
    {
        path: "/dashboard",
        name: "dashboard",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/Dashboard/Dashboard.vue"
            ),
    },

    // mail
    {
        path: "/mail",
        name: "mail",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/mail/mail_form.vue"
            ),
    },

    // mail form
    {
        path: "/mail/:mail/:type",
        name: "mail-show",
        // route level code-splitting
        // this generates a separate chunk (mail.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mail" */ "../views/mail/mail_form.vue"),
    },

    // inbox
    {
        path: "/inbox",
        name: "inbox",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/mail/inbox/inbox.vue"
            ),
    },

    {
        path: "/inbox/:mail/:department/:type/:sends_id",
        name: "inbox-show",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/mail/inbox/inbox_form.vue"
            ),
    },











    // testing
    {
        path: "/1",
        name: "1",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/1.vue"
            ),
    },
    {
        path: "/2",
        name: "2",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/2.vue"
            ),
    },
    {
        path: "/3",
        name: "3",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/3.vue"
            ),
    },
    {
        path: "/4",
        name: "4",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/4.vue"
            ),
    },
    {
        path: "/5",
        name: "5",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/5.vue"
            ),
    },

    {
        path: "/test",
        name: "test",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/test_pages/test.vue"
            ),
    },

];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;