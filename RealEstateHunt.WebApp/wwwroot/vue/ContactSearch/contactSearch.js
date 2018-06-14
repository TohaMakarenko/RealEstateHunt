define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    firstName: "",
                    lastName: "",
                    cityId: -1,
                    districtId: -1,
                    preferedTypeId: -1,
                    searchValue: {},
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
            computed: {
                searchMethod: function () {
                    return this.searchValue ? "ExtendedSearch" : "GetPage"
                }
            },
            methods: {
                search: function () {
                    this.searchValue = {
                        firstName: this.firstName,
                        lastName: this.lastName,
                        cityId: this.cityId,
                        districtId: this.districtId,
                        preferedTypeId: this.preferedTypeId
                    };
                }
            }
        };
    };
});