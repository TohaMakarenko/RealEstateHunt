define([], function () {
    var controllerAddress = '/RealEstate';
    var getPageMethod = 'GetRealEstatesPage';
    var getSortByPricePageMethod = 'GetRealEstatesOrderByPricePage';
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    record: {},
                    reTypes: [],
                    cities: [],
                    districts: [],
                }
            },
            watch: {
                '$route': 'fetchData'
            },
            created: function () {
                if (this.$route.params.id !== 'new') {
                    this.loadEntity(this.$route.params.id)
                }
                else {
                    this.record.type = {id: -1};
                    this.record.city = {id: -1};
                    this.record.district = {id: -1};
                }
                this.loadRETypes();
                this.loadCities();
                this.loadDistricts();
            },
            computed: {
                canDelete: function () {
                    return this.$route.params.id !== 'new'
                }
            },
            methods: {
                loadEntity: function (id) {
                    this.$http.get(controllerAddress + "/" + 'Record', {
                        params: {
                            id: id
                        }
                    }).then(function (response) {
                        if (response.data) {
                            this.record = response.data;
                        }
                    }.bind(this));
                },
                loadRETypes: function () {
                    this.$http.get(controllerAddress + "/" + 'GetRealEstateTypes')
                        .then(function (response) {
                            if (response.data && response.data.length) {
                                this.reTypes = response.data;
                            }
                        }.bind(this));
                },
                loadCities: function () {
                    this.$http.get('/City/GetCities')
                        .then(function (response) {
                            if (response.data && response.data.length) {
                                this.cities = response.data;
                            }
                        }.bind(this));
                },
                loadDistricts: function () {
                    this.$http.get('/City/GetDistricts')
                        .then(function (response) {
                            if (response.data && response.data.length) {
                                this.districts = response.data;
                            }
                        }.bind(this));
                },
                onSave: function () {
                    var validationResult = this.validate();
                    if (validationResult) {
                        alert("Заповніть поле " + validationResult);
                        return;
                    }
                    this.save();
                },
                onDelete: function () {
                    this.$http.delete(controllerAddress + '/DeleteRecord', {
                        params: {id: this.record.id}
                    }).then(function (data) {
                        this.$router.back()
                    }.bind(this));
                },
                validate: function () {
                    if (!this.record.name)
                        return "Назва";
                    if (!this.record.type || this.record.type.id <= 0)
                        return "Тип";
                    if (!this.record.city || this.record.city.id <= 0)
                        return "Місто";
                    if (!this.record.district || this.record.district.id <= 0)
                        return "Район";
                    if (!this.record.number)
                        return "Номер";
                    if (!this.record.street)
                        return "Вулиця";
                    if (this.record.floor <= 0)
                        return "Поверх";
                    if (!(this.record.square + 0) || (this.record.square + 0) <= 0)
                        return "Площа";
                    if (!(this.record.price + 0) || (this.record.price + 0) <= 0)
                        return "Ціна";
                    return false;
                },
                save: function () {
                    if (this.$route.params.id === 'new') {
                        this.$http.post(controllerAddress + '/AddRecord',
                            JSON.stringify(this.record), {
                                headers: {
                                    'Content-Type': 'application/json'
                                }
                            }).then(function (data) {
                            this.$router.back()
                        }.bind(this));
                    }
                    else {
                        this.$http.post(controllerAddress + '/UpdateRecord',
                            JSON.stringify(this.record), {
                                headers: {
                                    'Content-Type': 'application/json'
                                }
                            }).then(function (data) {
                            this.$router.back();
                        }.bind(this));
                    }
                }
            }
        };
    };
});