<template>
    <div class="card">
        <div class="card-section">
            <h4>{{movie.title}}</h4>
            <p>{{movie.description}}</p>
        </div>
        <div class="card-section">
            <p>Year: {{movie.year}}</p>
            <p>Rating: {{movie.rating}}</p>
            <p>Category: {{movie.category}}</p>
        </div>
    </div>
</template>

<script>

    import { mapGetters, mapActions } from "vuex";

    export default {
        computed: {
            ...mapGetters(["movie"])
        },
        methods: {
            ...mapActions(["getMovie"]),
        },
        created() {
            this.getMovie(this.$route.params.id);
        }
    }

</script>
