<template>
    <div class="row content">
        <div class="col-md-5">
            <div class="form-group">
                <button class="button" v-on:click="onSave">Зберегти</button>
                <button class="button" v-show="canDelete" v-on:click="onDelete">Видалити</button>
            </div>
            <div class="form-group">
                <label for="Name">
                    Назва
                    <input id="Name" type="text" v-model="record.name"/>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Тип
                    <select v-model="record.type.id">
                        <option v-for="i in reTypes" v-bind:value="i.id">
                            {{ i.name }}
                        </option>
                    </select>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Місто
                    <select v-model="record.city.id">
                        <option v-for="i in cities" v-bind:value="i.id">
                            {{ i.name }}
                        </option>
                    </select>
                </label>
            </div>
            <div class="form-group">
                <label>
                    Район
                    <select v-model="record.district.id">
                        <option v-for="i in districts" v-bind:value="i.id">
                            {{ i.name }}
                        </option>
                    </select>
                </label>
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
    define(["vue/realEstatePage.js"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>