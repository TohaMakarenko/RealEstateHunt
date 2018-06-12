<template>
    <div>
        <button class="btn float-right" v-on:click="addNewRealEstate">Додати</button>
        <data-grid v-bind:config="gridDataConfig"></data-grid>
    </div>
</template>

<script>
    define(["vue/realEstateSection.js", "rvue!vue/comps/dataGrid"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>