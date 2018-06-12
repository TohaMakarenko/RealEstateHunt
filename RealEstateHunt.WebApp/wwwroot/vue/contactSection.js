define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    gridDataConfig: {
                        controller: "Contact",
                        pageMethod: "GetPage",
                        columns: [
                            {
                                name: "firstName",
                                caption: "Ім'я",
                                getLink: function (item) {
                                    return 'contact/' + item.id
                                },
                                orderMethod: "GetOrderByFirstNamePage"
                            },
                            {
                                name: "lastName",
                                caption: "Прізвище",
                                getLink: function (item) {
                                    return 'contact/' + item.id
                                },
                                orderMethod: "GetOrderByLasttNamePage"
                            },
                            {
                                name: "cityName",
                                caption: "Місто"
                            },
                            {
                                name: "bankAccountNumber",
                                caption: "Номер БР",
                                orderMethod: "GetOrderByBankAccountNumberPage"
                            }
                        ]
                    }
                }
            },
            methods: {
                addNewContact: function () {
                    this.$router.push({
                        path: '/contact/new',
                        params: {id: "new"}
                    })
                }
            }
        };
    };
});