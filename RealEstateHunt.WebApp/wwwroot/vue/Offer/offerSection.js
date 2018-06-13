define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    gridDataConfig: {
                        controller: "Offer",
                        pageMethod: "GetPageAsync",
                        columns: [
                            {
                                name: "id",
                                caption: "Номер",
                                getLink: function (item) {
                                    return 'offer/' + item.id
                                }
                            },
                            {
                                name: "contactName",
                                caption: "Клієнт",
                                getLink: function (item) {
                                    return 'contact/' + item.contactId
                                }
                            },
                            {
                                name: "realEstateName",
                                caption: "Нерухомість",
                                getLink: function (item) {
                                    return 'realEstate/' + item.realEstateId
                                }
                            },
                            {
                                name: "status",
                                caption: "Стан"
                            }
                        ]
                    }
                }
            },
            methods: {
                addNewOffer: function () {
                    this.$router.push({
                        path: '/offer/new',
                        params: {id: "new"}
                    })
                }
            }
        };
    };
});