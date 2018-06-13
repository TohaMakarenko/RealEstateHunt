<template>
    <div>
        <div class="form-group">
            <button class="btn" v-on:click="onClose">Закрити</button>
            <button class="btn btn-warning" v-show="canDecline" v-on:click="onDecline">Відхилити</button>
            <span v-show="!canDecline && (record.isDeclined===true)">Відхилена</span>
            <button class="btn" v-show="canSave" v-on:click="onSave">Зберегти</button>
        </div>
        <div class="row" v-if="isNew">
            <div class="col-md-5">
                <div class="form-group">
                    <lookup label="Клієнт" controller="Offer" method="GetContactsWhichDesireRealEstateAsync"
                            display="lastName" id="id" v-model="record.contact.id"
                            v-bind:filter-value="record.realEstate.id" filter-param-name="realEstateid"></lookup>
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <lookup label="Нерухомість" controller="Offer" method="GetDesiredRealEstatesForClientAsync"
                            display="name" id="id" v-model="record.realEstate.id"
                            v-bind:filter-value="record.contact.id" filter-param-name="contactId"></lookup>
                </div>
            </div>
        </div>
        <div class="row" v-else>
            <div class="col-md-5">
                Клієнт: 
                <router-link v-bind:to="'/contact/' + record.contact.id">
                    {{record.contact.firstName + record.contact.lastName}}
                </router-link>
            </div>
            <div class="col-md-5">
                Нерухомість: 
                <router-link v-bind:to="'/realEstate/' + record.realEstate.id">
                    {{record.realEstate.name}}
                </router-link>
            </div>
        </div>
    </div>
</template>

<script>
    define(["vue/offerPage.js", "rvue!vue/comps/lookup"], function (search) {
        return search(template);
    })
</script>

<style scoped>

</style>