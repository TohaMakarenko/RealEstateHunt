define(["Vue", "lodash", "rvue!vue/comps/lookup"], function (Vue, _) {
    return function (template) {
        return Vue.component('data-grid', {
            props: ['config', 'filterMethod', 'filterValue'],
            template: template,
            data: function () {
                return {
                    collection: [],
                    loadPageMethod: "",
                    page: 0,
                    orderDirection: 0,
                    isEnd: false
                }
            },
            created: function () {
                this.loadPageMethod = this.config.pageMethod;
                this.loadPage();
            },
            watch: {
                filterMethod: function () {
                    this.loadPageMethod = this.filterMethod;
                    this.reloadData(this.filterValue, this.filterMethod)
                },
                filterValue: function () {
                    this.loadPageMethod = this.filterMethod;
                    this.reloadData(this.filterValue, this.filterMethod)
                }
            },
            methods: {
                reloadData: function (method, params) {
                    this.page = 0;
                    this.loadPageMethod = method;
                    this.orderDirection = params.orderDirection;
                    this.collection = [];
                    this.isEnd = false;
                    this.loadPage(method, params);
                },
                loadPage: function (method, params) {
                    if (!params) {
                        params = {
                            pageNumber: this.page,
                            orderDirection: this.orderDirection
                        };
                    }
                    else {
                        if (!params.pageNumber) {
                            params.pageNumber = this.page
                        }
                        if (_.isNumber(params.orderDirection) && !_.isNaN(params.orderDirection)) {
                            params.orderDirection = orderDirection;
                        }
                    }
                    this.$http.get(this.config.controller + "/" +
                        (method ? method : this.loadPageMethod),
                        {
                            params: params
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
                getColumnValue: function (item, column) {
                    var path = column.split('.');
                    var result = item;
                    path.forEach(function (value) {
                        result = result[value];
                    });
                    return result;
                },
                onColumnClick: function (ev) {
                    var el = ev.target.id;
                    var cfg = _.findIndex(this.config.columns, function (i) {
                        return i.name === el;
                    });
                    cfg = this.config.columns[cfg];
                    if (!cfg.orderMethod)
                        return;

                    if (cfg.orderMethod) {
                        this.reloadData(cfg.orderMethod, !this.orderDirection + 0);
                    }
                },
                loadMore: function () {
                    this.page++;
                    this.loadPage();
                },
                getLink: function (item, config) {
                    if (_.isFunction(config.getLink)) {
                        return config.getLink(item);
                    }
                }
            }
        })
    }
});