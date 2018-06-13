<template>
    <div class="row content">
        <div class="d-inline-block col-md-5">
            <h4>Нерухомість</h4>
            <ul class="list-group">
                <li class="list-group-item" v-for="i in searchResult.realEstates">
                    <router-link v-bind:to="'/realEstate/' + i.id">{{i.name}}</router-link>
                </li>
            </ul>
        </div>
        <div class="d-inline-block col-md-5">
            <h4>Контакти</h4>
            <ul class="list-group">
                <li class="list-group-item" v-for="i in searchResult.contacts">
                    <router-link v-bind:to="'/contact/' + i.id">{{i.firstName + " " + i.lastName}}</router-link>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
    define(["vue/Search/search.js"], function (search) {
        return search(template);
    })
</script>