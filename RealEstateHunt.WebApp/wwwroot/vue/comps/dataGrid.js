define(["Vue", "lodash"], function (Vue, _) {
    return function (template) {
        return Vue.component('data-grid', {
            props: ['config'],
            template: template,
            data: function () {
                return {
                    collection: [],
                    loadPageMethod:"",
                    page: 0,
                    orderDirection: 0,
                    isEnd: false
                }
            },
            created: function () {
                this.loadPageMethod = this.config.pageMethod;
                this.loadPage(0, this.loadPageMethod, 0);
            },
            methods: {
                loadPage: function (page, method, orderDirection) {
                    this.$http.get(this.config.controller + "/" + method, {
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
                getColumnValue: function(item, column){
                    var path = column.split('.');
                    var result = item   ;
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
                    this.page = 0;
                    this.orderDirection = !this.orderDirection + 0;
                    this.collection = [];
                    this.loadPageMethod = cfg.orderMethod;
                    this.isEnd = false;
                    if(cfg.orderMethod){
                        this.loadPage(0, this.loadPageMethod, this.orderDirection);   
                    }
                },
                loadMore: function () {
                    this.page++;
                    this.loadPage(this.page, this.loadPageMethod, this.orderDirection);
                }
            }
        })
    }
});