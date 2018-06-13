<template>
    <div>
        <div class="form-inline" style="margin-bottom: 10px">
            <div class="form-group col-md-5">
                <label>
                    Пошук
                    <input type="text" class="form-control" v-model="searchValue"/>
                </label>
            </div>
            <div class=" col-md-5 float-right">
                <button class="btn float-right" v-on:click="addNewContact">Додати</button>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <data-grid v-bind:config="gridDataConfig" v-bind:filter-value="searchValueObject"
                           v-bind:filter-method="searchMethod">
                </data-grid>
            </div>
        </div>
    </div>
</template>

<script>
    define(["vue/contactSection.js", "rvue!vue/comps/dataGrid"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>