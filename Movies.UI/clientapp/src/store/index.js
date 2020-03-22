import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";

Vue.use(Vuex);

const baseUrl = "http://localhost:5000/api";
const moviesUrl = `${baseUrl}/movie/movies`;

export default new Vuex.Store({
    strict: true,
    state: {
        movies: [],
        selectedCategories: [],
        searchTerm: ''
    },
    getters: {
        moviesFiltered: function (state) {
            let result = state.movies;
            if (state.selectedCategories && state.selectedCategories.length > 0) {
                result = result.filter(m => state.selectedCategories.includes(m.category));
            }

            if (state.searchTerm) {
                result = result.filter(m => m.title.toLowerCase().includes(state.searchTerm.toLowerCase()));
            }

            return result;
        },
        movies: function (state) {
            return state.movies;
        },
        categories: state =>
            [...new Set(state.movies.map(m => m.category).sort())]
    },
    mutations: {
        setData(state, data) {
            state.movies = data.movies;
        },
        setCategories(state, categories) {
            state.selectedCategories = categories;
        },
        setSearchTerm(state, searchTerm) {
            let trimmed = searchTerm.trim();
            state.searchTerm = trimmed;
        }
    },
    actions: {
        async getData(context) {
            let movies = (await Axios.get(moviesUrl)).data;
            context.commit("setData", { movies });
        }
    }
})