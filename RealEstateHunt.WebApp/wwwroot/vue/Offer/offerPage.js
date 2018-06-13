define([], function () {
    var controllerAddress = '/Offer';
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    record: {
                        contact: {},
                        realEstate: {}
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
                canSave: function () {
                    return this.$route.params.id === 'new'
                },
                canDecline: function () {
                    return this.$route.params.id !== 'new' &&
                        !this.record.isDeclined;
                },
                isNew: function () {
                    return this.$route.params.id === 'new'
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
                    this.$router.push('/offer');
                },
                onDelete: function () {
                    this.$http.delete(controllerAddress + '/DeleteRecord', {
                        params: {id: this.record.id}
                    }).then(function (data) {
                        this.$router.push('/offer');
                    }.bind(this));
                },
                validate: function () {
                    if (_.isEmpty(this.record.contact) ||
                        this.record.contact.id <= 0)
                        return "Клієнт";
                    if (_.isEmpty(this.record.realEstate) ||
                        this.record.realEstate.id <= 0)
                        return "Нерухомість";
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
                                this.$router.push('/offer/' + data.data.id)
                            }
                        }.bind(this));
                    }
                },
                onDecline: function () {
                    //DeclineOfferAsync
                    this.$http.get(controllerAddress + '/DeclineOfferAsync', {
                        params: {
                            offerId: this.record.id
                        }
                    }).then(function (data) {
                        if (data.status == 200) {
                            this.loadEntity(this.record.id);
                        }
                    }.bind(this));
                }
            }
        };
    };
});