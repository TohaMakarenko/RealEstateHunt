define([], function () {
    var controllerAddress = '/RealEstate';
    var getPageMethod = 'GetRealEstatesPage';
    var getSortByPricePageMethod = 'GetRealEstatesOrderByPricePage';
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
                                caption: "Назва"
                            },
                            {
                                name: "city.name",
                                caption: "Місто"
                            },
                            {
                                name: "district.name",
                                caption: "Район"
                            },
                            {
                                name: "type.name",
                                caption: "Тип"
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