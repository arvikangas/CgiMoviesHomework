<template>
    <div>
        <div class="top-bar">
            <div class="top-bar-left">
                <ul class="menu">
                    <li>
                        <router-link to="/">Movies</router-link>
                    </li>
                    <li>
                        <multiselect v-model="selectedCategories" :options="categories" :multiple="true"></multiselect>
                    </li>
                </ul>
            </div>
            <div class="top-bar-right">
                <ul class="menu">
                    <li>
                        <autocomplete 
                            :source="titles"
                            placeholder="Search movies"
                            @selected="selectSearch"
                            @nothingSelected="selectSearchNothing"
                                      @clear="clear"/>
                    </li>
                </ul>
            </div>
        </div>

        <router-view />
    </div>
</template>

<script>

    import { mapGetters, mapMutations } from "vuex";
    import MovieList from "./components/MovieList";
    import Multiselect from 'vue-multiselect';
    import Autocomplete from 'vuejs-auto-complete';

    export default {
        name: 'App',
        components: { MovieList, Multiselect, Autocomplete },
        data: function () {
            return {
                selectedCategories: [],
                searchTerm: ''
            }
        },
        watch: {
            selectedCategories: function (val) {
                this.setCategories(val);
            },
            searchTerm: function (val) {
                this.setSearchTerm(val);
            }
        },
        computed: {
            ...mapGetters(["categories", "movies"]),
            titles: function () {
                let titles = this.movies.map(function (m) {
                    return { 'id': m.title, 'name': m.title };
                });
                return titles;
            }
        },
        methods: {
            ...mapMutations(["setCategories", "setSearchTerm"]),
            selectSearch: function (val) {
                this.searchTerm = val.value;
            },
            selectSearchNothing: function (val) {
                this.searchTerm = val || '';
            },
            clear: function () {
                this.searchTerm = '';
            },
            clear: function () {
                this.searchTerm = '';
            }
        }
    }
</script>

<style>
</style>
