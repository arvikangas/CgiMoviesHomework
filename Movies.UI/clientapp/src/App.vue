<template>
    <movie-list />
</template>

<script>

    import { mapActions } from "vuex";
    import MovieList from "./components/MovieList"

    export default {
        name: 'App',
        components: { MovieList },
        methods: {
            ...mapActions(["getData"])
        },
        created() {
            this.getData();
        }
    }
</script>

<style>

    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
