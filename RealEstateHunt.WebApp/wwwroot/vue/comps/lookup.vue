<template>
    <label>
        {{label}}
        <select class="form-control" v-model="selected">
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