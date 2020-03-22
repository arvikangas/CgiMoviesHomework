import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";

Vue.use(Vuex);

const baseUrl = "http://localhost:5000/api";
const moviesUrl = `${baseUrl}/movie/movies`;

export default new Vuex.Store({
    strict: true,
    state: {
        movies: []
    },
    mutations: {
        setData(state, data) {
            state.movies = data.movies;
        }
    },
    actions: {
        async getData(context) {
            let movies = (await Axios.get(moviesUrl)).data;
            console.log(movies);
            context.commit("setData", { movies });
        }
    }
})