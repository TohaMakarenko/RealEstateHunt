define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
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
            }
        };
    };
});