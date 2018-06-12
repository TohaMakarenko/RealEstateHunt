<template>
    <label>
        {{label}}<br>
        <select v-model="selected">
            <option v-for="i in collection" v-bind:value="i[id]">
                {{ i[display] }}
            </option>
        </select>
    </label>
</template>

<script>
    define(["vue/comps/lookup.js"], function (lookup) {
        return lookup(template);
    })
</script>

<style scoped>
select{
    min-width: 200px;
}
</style>