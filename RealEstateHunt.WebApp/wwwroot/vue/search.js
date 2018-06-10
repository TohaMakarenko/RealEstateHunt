define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    searchResult: {}
                }
            },
            computed: {
                searchKey: function () {
                    return this.$route.query.searchKey;
                }
            },
            watch: {
                // при изменениях маршрута запрашиваем данные снова
                '$route': 'fetchData'
            },
            created: function () {
                this.fetchData();
            },
            methods: {
                fetchData: function () {
                    var key = this.$route.query.searchKey;
                    this.$http.get("/Search/Search", {
                        params: {
                            searchKey: key
                        }
                    }).then(function (response) {
                        this.searchResult = response.data;
                    }.bind(this));
                }
            }
        };
    };
});