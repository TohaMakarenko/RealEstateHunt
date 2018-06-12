<template>
    <div class="row content">
        <div class="col-md-5">
            <div class="form-group">
                <button class="btn" v-on:click="onClose">Закрити</button>
                <button class="btn" v-on:click="onSave">Зберегти</button>
                <button class="btn" v-show="canDelete" v-on:click="onDelete">Видалити</button>
            </div>
            <div class="form-group">
                <label for="Name">
                    Назва
                    <input id="Name" type="text" v-model="record.name"/>
                </label>
            </div>
            <div class="form-group">
                <lookup label="Тип" controller="RealEstate" method="GetRealEstateTypes" display="name" id="id"
                        v-model="type"></lookup>
            </div>
            <div class="form-group">
                <lookup label="Місто" controller="City" method="GetCities" display="name" id="id"
                        v-model="city"></lookup>
            </div>
            <div class="form-group">
                <lookup label="Район" controller="City" method="GetDistricts" display="name" id="id"
                        v-model="district"
                        v-bind:filter-value="city" filter-param-name="cityId"></lookup>
            </div>
            <div class="form-group">
                <label>
                    Вулиця
                    <input type="text" v-model="record.street"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Номер
                    <input type="text" v-model="record.number"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Поверх
                    <input type="number" v-model="record.floor"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Площа
                    <input type="number" v-model="record.square"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Опис
                    <input type="text" v-model="record.description"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Ціна
                    <input type="number" v-model="record.price"/>
                </label>
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