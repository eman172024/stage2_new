import Vue from "vue";
import VueRouter from "vue-router";
// import Login from "../views/auth/login.vue";
import Login from "../views/Auth/Login.vue";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "login",
        component: Login,
    },


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
        path: "/dashboard/mailOM/create",
        name: "mailOM-create",
        // route level code-splitting
        // this generates a separate chunk (mailOM.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mailOM" */ "../views/pages/mailOM.vue"),
    },
    {
        path: "/dashboard/mailOM/:mail",
        name: "mailOM-edit",
        // route level code-splitting
        // this generates a separate chunk (mailOM.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mailOM" */ "../views/pages/mailOM.vue"),
    },

    {
        path: "/dashboard/mailCC/:mail",
        name: "mailCC",
        // route level code-splitting
        // this generates a separate chunk (mailCC.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mailCC" */ "../views/pages/mailCC.vue"),
    },

    {
        path: "/dashboard/mails",
        name: "mails",
        // route level code-splitting
        // this generates a separate chunk (mailCC.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mailCC" */ "../views/pages/mails.vue"),
    },

    {
        path: "/reports",
        name: "reports",
        // route level code-splitting
        // this generates a separate chunk (reports.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "reports" */ "../views/pages/reports.vue"),
    },
    {
        path: "/users",
        name: "users",
        // route level code-splitting
        // this generates a separate chunk (users.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "users" */ "../views/pages/users.vue"),
    },
    {
        path: "/processingResponses",
        name: "processingResponses",
        // route level code-splitting
        // this generates a separate chunk (processingResponses.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "processingResponses" */
                "../views/pages/processingResponses.vue"
            ),
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;