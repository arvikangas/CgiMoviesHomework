<template>
    <div>
        <div v-for="m in movies" v-bind:key="m.id">
            {{m.id}} - {{m.title}}
        </div>
    </div>
</template>

<script>

    import { mapState } from "vuex"

    export default {
        computed: {
            ...mapState(["movies"])
        }
    }

</script>
