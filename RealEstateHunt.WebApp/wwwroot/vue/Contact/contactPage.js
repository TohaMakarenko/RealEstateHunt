define([], function () {
    var controllerAddress = '/Contact';
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    record: {
                        city: {},
                        district: {},
                        preferredType: {}
                    }
                }
            },
            watch: {
                '$route.params.id': 'loadEntity'
            },
            created: function () {
                if (this.$route.params.id !== 'new') {
                    this.loadEntity(this.$route.params.id)
                }
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
                onSave: function () {
                    var validationResult = this.validate();
                    if (validationResult) {
                        alert("Заповніть коректно поле " + validationResult);
                        return;
                    }
                    this.save();
                },
                onClose: function () {
                    this.$router.push('/contact');
                },
                onDelete: function () {
                    this.$http.delete(controllerAddress + '/DeleteRecord', {
                        params: {id: this.record.id}
                    }).then(function (data) {
                        this.$router.push('/contact');
                    }.bind(this));
                },
                validate: function () {
                    if (!this.record.firstName)
                        return "Ім'я";
                    if (!this.record.lastName)
                        return "Прізвище";
                    if (_.isEmpty(this.record.city) ||
                        this.record.city.id <= 0)
                        return "Місто";
                    if (_.isEmpty(this.record.district) ||
                        this.record.district.id <= 0)
                        return "Район";
                    if (!this.record.number)
                        return "Номер";
                    if (!this.record.street)
                        return "Вулиця";
                    if (!this.record.bankAccountNumber)
                        return "Номер банкцівського рахунку";
                    if (!(this.record.preferredPrice + 0) || (this.record.preferredPrice + 0) <= 0)
                        return "Бажана ціна";
                    if (_.isEmpty(this.record.preferredType) ||
                        this.record.preferredType.id <= 0)
                        return "Бажаний тип";
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
                            if (data.data.id) {
                                this.$router.push('/contact/' + data.data.id)
                            }
                        }.bind(this));
                    }
                    else {
                        this.$http.post(controllerAddress + '/UpdateRecord',
                            JSON.stringify(this.record), {
                                headers: {
                                    'Content-Type': 'application/json'
                                }
                            })
                    }
                }
            }
        };
    };
});