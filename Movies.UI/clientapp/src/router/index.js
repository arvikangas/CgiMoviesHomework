import Vue from "vue";
import VueRouter from "vue-router";

import App from "../App";
import Movie from "../components/Movie";


Vue.use(VueRouter);
export default new VueRouter({
    mode: "history",
    routes: [
        { path: "/", component: App },
        { path: "/movie/:id", component: Movie },
        { path: "*", redirect: "/" }
    ]
})