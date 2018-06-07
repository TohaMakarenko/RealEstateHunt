require.config({
    paths: {
        jquery: "lib/jquery/jquery.min",
        Vue: "lib/vue/vue",
        lodash: "lib/lodash/lodash.min",
        bootstrap: "lib/bootstrap/js/bootstrap.bundle.min",
        vue: "requirejs-vue",
        "vue-router": "lib/vue-router/vue-router",
        axios: "lib/axios/axios.min.js"
    },
    config: {
        'vue': {
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

require(["Vue", "vue-router", "router", "bootstrap"], function (Vue, VueRouter, router) {
    Vue.use(VueRouter);
    return new Vue({
        el: "#app",
        router: router,
        data: {
            message: "asdad",
            searchKey: "qqqq"
        },
        methods: {
            search: function () {
                console.log(this.searchKey);
            }
        }
    });
});