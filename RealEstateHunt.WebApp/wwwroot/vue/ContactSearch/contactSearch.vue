<template>
    <div>
        <div class="row" style="margin-bottom: 10px">
            <div class="col-md-5">
                <div class="form-group">
                    <label>
                        Ім'я
                        <input class="form-control" type="text" v-model="firstName"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Прізвище
                        <input class="form-control" type="text" v-model="lastName"/>
                    </label>
                </div>
                <div class="form-group">
                    <lookup label="Бажаний тип" controller="RealEstate" method="GetRealEstateTypes" display="name"
                            id="id"
                            v-model="preferedTypeId"></lookup>
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <lookup label="Місто" controller="City" method="GetCities" display="name" id="id"
                            v-model="cityId"></lookup>
                </div>
                <div class="form-group">
                    <lookup label="Район" controller="City" method="GetDistricts" display="name" id="id"
                            v-model="districtId"
                            v-bind:filter-value="cityId" filter-param-name="cityId"></lookup>
                </div>
                <div class="form-group">
                    <button class="btn" v-on:click="search">Пошук</button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <data-grid v-bind:config="gridDataConfig" v-bind:filter-value="searchValue"
                           v-bind:filter-method="searchMethod">
                </data-grid>
            </div>
        </div>
    </div>
</template>

<script>
    define(["vue/ContactSearch/contactSearch.js", "rvue!vue/comps/dataGrid"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>