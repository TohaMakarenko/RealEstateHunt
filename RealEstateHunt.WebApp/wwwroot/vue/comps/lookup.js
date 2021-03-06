define(["Vue", "lodash"], function (Vue, _) {
    return function (template) {
        return Vue.component('lookup', {
            model: {
                prop: "value",
                event: "change"
            },
            props: ['config', 'controller', 'method', 'filterParamName', 'label', 'value', 'valueChanged',
                'display', 'id', 'filterValue'],
            template: template,
            data: function () {
                return {
                    collection: [],
                    selected: -1
                }
            },
            created: function () {
                if (this.config) {
                    if (!this.controller)
                        this.controller = this.config.controller ?
                            this.config.controller
                            : this.controller;
                    if (!this.method)
                        this.method = this.config.method ?
                            this.config.method
                            : this.method;
                    if (!this.filterParamName)
                        this.filterParamName = this.config.filterParamName ?
                            this.config.filterParamName
                            : this.filterParamName;
                    if (!this.label)
                        this.label = this.config.label ?
                            this.config.label
                            : this.label;
                }
                if (this.value) {
                    this.selected = this.value[this.id];
                }
                this.loadLookup();
            },
            watch: {
                filterValue: function () {
                    this.loadLookup();
                },
                value: function (val) {
                    this.selected = val;
                },
                selected: function () {
                    this.$emit("change", this.selected);
                }
            },
            methods: {
                loadLookup: function () {
                    var params = {};
                    if (this.filterValue !== undefined && this.filterValue >= 0) {
                        params[this.filterParamName] = this.filterValue;
                    }
                    this.$http.get(this.controller + '/' + this.method, {
                        params: params
                    }).then(function (response) {
                        if (response.data) {
                            this.collection = response.data;
                            if (_.findIndex(this.collection, function (i) {
                                return i[this.id] === this.selected;
                            }.bind(this)) < 0) {
                                this.selected = -1;
                            }
                        }
                    }.bind(this));
                },
                resetSelected: function () {
                    this.selected = -1;
                }
            }
        })
    }
});