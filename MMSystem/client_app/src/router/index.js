import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../views/Auth/Login.vue";
import Show from "../views/users/ShowUsers.vue";
import Add from "../views/users/UsersForm.vue";
import Archives from "../views/Archives/Archives.vue";
import report from "../views/Archives/report.vue";
import report2 from "../views/Archives/report2.vue";
import incoming_report from "../views/reports/incoming_report.vue";
import Statistical_report from "../views/reports/Statistical_report.vue";
import show_sections from "../views/section_and_sector/show_sections.vue";
import add_section from "../views/section_and_sector/add_section.vue";

import Sent_report from "../views/reports/Sent_report.vue"


Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "login",
        component: Login,
    },


    {
        path: "/guide/color",
        name: "guidecolor",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/guide/color.vue"
            ),
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

    // sent
    {
        path: "/sent",
        name: "sent",
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import (
                /* webpackChunkName: "dashboard" */
                "../views/mail/sent/sent.vue"
            ),
    },

    {
        path: "/sent-form",
        name: "sent-add",
        // route level code-splitting
        // this generates a separate chunk (mail.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mail" */ "../views/mail/sent/sent_form.vue"),
    },

    {
        path: "/sent-form/:mail/:type/:sends_id",
        name: "sent-show",
        // route level code-splitting
        // this generates a separate chunk (mail.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "mail" */ "../views/mail/sent/sent_form.vue"),
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

    {
        path: "/UsersForm",
        name: "Add",
        component: Add,

    },

    {
        path: "/Show",
        name: "Show",
        component: Show
    },


    {
        path: "/sectionForm",
        name: "sectionForm",
        component: add_section,

    },

    {
        path: "/show_sections",
        name: "show_sections",
        component: show_sections
    },

    {
        path: "/Archives",
        name: "Archives",
        component: Archives
    },

    {
        path: "/report",
        name: "report",
        component: report
    },

    {
        path: "/report2",
        name: "report2",
        component: report2
    },

    {
        path: "/incoming_report",
        name: "incoming_report",
        component: incoming_report
    },

    {
        path: "/Statistical_report",
        name: "Statistical_report",
        component: Statistical_report
    },



    {
        path: "/Sent_report",
        name: "Sent_report",
        component: Sent_report
    },


];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;