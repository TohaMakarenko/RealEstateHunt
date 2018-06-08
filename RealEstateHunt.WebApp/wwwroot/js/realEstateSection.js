define([], function () {
    var controllerAddress = '/RealEstate';
    var getPageMethod = 'GetRealEstatesPage';
    var getSortByPricePageMethod = 'GetRealEstatesOrderByPricePage';
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    isEnd: false,
                    collection: [],
                    page: 0,
                    orderDirection: 0,
                    isFilterByType: false,
                    realEstateTypeId: -1,
                    reTypes: [],
                    loadMoreMethod: getPageMethod
                }
            },
            created: function () {
                this.page = 0;
                this.fetchPage(this.page, getPageMethod);
                this.loadRETypes();
            },
            watch: {
                'isFilterByType': 'toggleFilterByType',
                'realEstateTypeId': 'filterByType'
            },
            methods: {
                fetchPage: function (page, method, orderDirection) {
                    this.$http.get(controllerAddress + "/" + method, {
                        params: {
                            pageNumber: page,
                            orderDirection: orderDirection
                        }
                    }).then(function (response) {
                        if (response.data && response.data.length) {
                            this.collection = this.collection.concat(response.data);
                            this.isEnd = response.data.length < this.$config.constants.defaultPageSize;
                        }
                        else {
                            this.isEnd = true;
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
                loadMoreButtonClick: function () {
                    this.page++;
                    this.fetchPage(this.page, this.loadMoreMethod, this.orderDirection)
                },
                onPriceSort: function () {
                    this.page = 0;
                    this.collection = [];
                    this.loadMoreMethod = getSortByPricePageMethod;
                    this.orderDirection = !this.orderDirection + 0;
                    this.fetchPage(this.page, getSortByPricePageMethod, this.orderDirection);
                },
                toggleFilterByType: function () {
                    if (!this.isFilterByType) {
                        this.page = 0;
                        this.fetchPage(this.page, getPageMethod);
                    }
                    else {
                        this.filterByType();
                    }
                },
                filterByType: function () {
                    if(this.isFilterByType && this.realEstateTypeId !== -1) {
                        this.$http.get(controllerAddress + "/" + 'GetRealEstatesByTypePage', {
                            params: {
                                realEstateTypeId: this.realEstateTypeId,
                                pageNumber: this.page
                            }
                        }).then(function (response) {
                            if (response.data && response.data.length) {
                                this.collection = response.data;
                                this.isEnd = response.data.length < this.$config.constants.defaultPageSize;
                            }
                            else {
                                this.isEnd = true;
                            }
                        }.bind(this));
                    }
                },
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