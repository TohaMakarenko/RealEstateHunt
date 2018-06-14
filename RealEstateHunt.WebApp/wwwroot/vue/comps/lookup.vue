<template>
    <div>
        <label>
            {{label}}
            <img class="float-right" src="../../img/close-icon.svg" alt="" style="height: 17px; cursor: pointer;"
                 v-on:click="resetSelected">
            <select class="form-control" v-model="selected">
                <option v-for="i in collection" v-bind:value="i[id]">
                    {{ i[display] }}
                </option>
            </select>
        </label>
    </div>
</template>

<script>
    define(["vue/comps/lookup.js"], function (lookup) {
        return lookup(template);
    })
</script>

<style scoped>
    select {
        min-width: 200px;
    }
</style>