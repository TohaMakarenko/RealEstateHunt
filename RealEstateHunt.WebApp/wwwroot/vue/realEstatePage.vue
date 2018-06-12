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
                    <label for="Name">
                        Назва
                        <input class="form-control" id="Name" type="text" v-model="record.name"/>
                    </label>
                </div>
                <div class="form-group">
                    <lookup label="Тип" controller="RealEstate" method="GetRealEstateTypes" display="name" id="id"
                            v-model="record.type.id"></lookup>
                </div>
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
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <label>
                        Номер
                        <input class="form-control" type="text" v-model="record.number"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Поверх
                        <input class="form-control" type="number" v-model="record.floor"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Площа
                        <input class="form-control" type="number" v-model="record.square"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Опис
                        <input class="form-control" type="text" v-model="record.description"/>
                    </label>
                </div>
                <div class="form-group">
                    <label>
                        Ціна
                        <input class="form-control" type="number" v-model="record.price"/>
                    </label>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    define(["vue/realEstatePage.js", "rvue!vue/comps/lookup"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>