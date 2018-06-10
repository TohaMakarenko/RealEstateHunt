require.config({
    paths: {
        jquery: "lib/jquery/jquery.min",
        Vue: "lib/vue/vue",
        lodash: "lib/lodash/lodash.min",
        bootstrap: "lib/bootstrap/js/bootstrap.bundle.min",
        rvue: "requirejs-vue",
        "vue-router": "lib/vue-router/vue-router",
        axios: "lib/axios/axios.min"
    },
    config: {
        'rvue': {
            'css': 'inject',
            'templateVar': 'template'
        }
    },
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    }
});

require(["Vue", "vue-router", "axios", "router","configuration", "bootstrap"],
    function (Vue, VueRouter, axios, router, configuration) {
        Vue.use(VueRouter);
        Vue.prototype.$http = axios;
        Vue.prototype.$config = configuration;
        return new Vue({
            el: "#app",
            router: router,
            data: {
                searchKey: ""
            },
            methods: {
                search: function () {
                    this.$router.push({
                        path: 'search',
                        query: {searchKey: this.searchKey}
                    })
                }
            }
        });
    });