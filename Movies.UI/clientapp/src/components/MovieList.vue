<template>
    <div>
        <div v-for="m in movies" v-bind:key="m.id" class="callout" v-on:click="selectMovie(m)">
            <h5>{{m.title}}</h5>
            <p>Year: {{m.year}}</p>
            <p>Rating: {{m.rating}}</p>
            <p>Category: {{m.category}}</p>
        </div>
    </div>
</template>

<script>

    import { mapGetters, mapActions } from "vuex";

    export default {
        computed: {
            ...mapGetters({ movies: "moviesFiltered" })
        },
        methods: {
            ...mapActions(["getData"]),
            selectMovie(movie) {
                this.$router.push(`/movie/${movie.id}`);
            }
        },
        created() {
            this.getData();
        }
    }

</script>
