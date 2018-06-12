<template>
    <div>
        <div class="form-group">
            <button class="btn" v-on:click="onClose">Закрити</button>
            <button class="btn" v-on:click="onSave">Зберегти</button>
            <button class="btn float-right" v-show="canDelete" v-on:click="onDelete">Видалити</button>
        </div>
        <div class="row">
            <div class="col-md-5">
                <div class="form-group">
                    <label>
                        Ім'я
                        <input class="form-control" type="text" v-model="record.firstName"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Прізвище
                        <input class="form-control" type="text" v-model="record.lastName"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Номер банкцівського рахунку
                        <input class="form-control" type="text" v-model="record.bankAccountNumber"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Бажана ціна
                        <input class="form-control" type="number" v-model="record.preferredPrice"/>
                    </label>
                </div>
                <div class="form-group">
                    <lookup label="Бажаний тип" controller="RealEstate" method="GetRealEstateTypes" display="name" id="id"
                            v-model="record.preferredType.id"></lookup>
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <lookup label="Місто" controller="City" method="GetCities" display="name" id="id"
                            v-model="record.city.id"></lookup>
                </div>
                <div class="form-group">
                    <lookup label="Район" controller="City" method="GetDistricts" display="name" id="id"
                            v-model="record.district.id"
                            v-bind:filter-value="record.city.id" filter-param-name="cityId"></lookup>
                </div>
                <div class="form-group">
                    <label>
                        Вулиця
                        <input class="form-control" type="text" v-model="record.street"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Номер
                        <input class="form-control" type="text" v-model="record.number"/>
                    </label>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    define(["vue/contactPage.js", "rvue!vue/comps/lookup"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>