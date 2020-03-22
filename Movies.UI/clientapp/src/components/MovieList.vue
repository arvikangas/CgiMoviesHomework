<template>
    <div>
        <div v-for="m in movies" v-bind:key="m.id" class="callout">
            <h5>{{m.title}}</h5>
            <p>Year: {{m.year}}</p>
            <p>Rating: {{m.rating}}</p>
            <p>Category: {{m.category}}</p>
        </div>
    </div>
</template>

<script>

    import { mapGetters } from "vuex"

    export default {
        computed: {
            ...mapGetters({ movies: "moviesFiltered" })
        }
    }

</script>
