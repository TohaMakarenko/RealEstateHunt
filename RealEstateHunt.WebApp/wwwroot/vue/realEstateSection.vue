<template>
    <div class="row content">
        <div class="row col-md-5">
            <label for="isFilterByType">Фільтрувати по типу
                <input class="" type="checkbox" id="isFilterByType" v-model="isFilterByType"/>
            </label>
            <select v-model="realEstateTypeId">
                <option v-for="i in reTypes" v-bind:value="i.id">
                    {{ i.name }}
                </option>
            </select>
            <button class="button" v-on:click="addNewRealEstate">Додати новий</button>
        </div>
        <table class="table">
            <tr>
                <th>Назва</th>
                <th>Місто</th>
                <th>Район</th>
                <th>Тип</th>
                <th><span v-on:click="onPriceSort" class="btn">Вартість</span></th>
            </tr>
            <tr v-for="i in collection">
                <td>
                    <router-link v-bind:to="'/realEstate/'+i.id">{{i.name}}</router-link>
                </td>
                <td>{{i.city.name}}</td>
                <td>{{i.district.name}}</td>
                <td>{{i.type.name}}</td>
                <td>{{i.price}}</td>
            </tr>
        </table>
        <button class="button" v-show="!isEnd" v-on:click="loadMoreButtonClick">Завантажити більше</button>
    </div>
</template>

<script>
    define(["js/realEstateSection"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>