import Vue from "vue";
import VueRouter from "vue-router";

import MovieList from "../components/MovieList";
import Movie from "../components/Movie";


Vue.use(VueRouter);
export default new VueRouter({
    mode: "history",
    routes: [
        { path: "/", component: MovieList },
        { path: "/movie/:id", component: Movie },
        { path: "*", redirect: "/" }
    ]
})