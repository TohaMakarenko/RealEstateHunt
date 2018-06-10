<template>
    <div>
        <table class="table">
            <tr>
                <th v-for="c in config.columns">
                    <span class="btn" v-on:click="onColumnClick" v-bind:id="c.name">{{c.caption}}</span>
                </th>
            </tr>
            <tr v-for="i in collection">
                <td v-for="c in config.columns">
                    {{getColumnValue(i, c.name)}}
                </td>
            </tr>
        </table>
        <button class="button" v-show="!isEnd" v-on:click="loadMore">Завантажити більше</button>
    </div>
</template>

<script>
    define(["vue/comps/dataGrid.js"], function (dataGrid) {
        return dataGrid(template);
    })
</script>

<style scoped>

</style>