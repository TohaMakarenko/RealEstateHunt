define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    searchValue: "",
                    gridDataConfig: {
                        controller: "RealEstate",
                        pageMethod: "GetRealEstatesPage",
                        columns: [
                            {
                                name: "name",
                                caption: "Назва",
                                getLink: function (item) {
                                    return 'RealEstate/' + item.id
                                }
                            },
                            {
                                name: "cityName",
                                caption: "Місто"
                            },
                            {
                                name: "districtName",
                                caption: "Район"
                            },
                            {
                                name: "typeName",
                                caption: "Тип",
                                orderMethod: "GetRealEstatesOrderByTypePage",
                                filter: {
                                    controller: "RealEstate",
                                    method: "GetRealEstatesByTypePage",
                                    lookupConfig: {
                                        controller: "RealEstate",
                                        method: "GetRealEstateTypes"
                                    }
                                }
                            },
                            {
                                name: "price",
                                caption: "Ціна",
                                orderMethod: "GetRealEstatesOrderByPricePage"
                            }
                        ]
                    }
                }
            },
            computed: {
                searchMethod: function () {
                    return this.searchValue ? "Search" : "GetRealEstatesPage"
                },
                searchValueObject: function () {
                    return {
                        keyWord: this.searchValue
                    }
                }
            },
            methods: {
                addNewRealEstate: function () {
                    this.$router.push({
                        path: '/realEstate/new',
                        params: {id: "new"}
                    })
                }
            }
        };
    };
});