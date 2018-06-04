require.config({
    paths: {
        jquery: "lib/jquery/jquery.min",
        Vue: "lib/vue/vue",
        lodash: "lib/lodash/lodash.min",
        bootstrap: "lib/bootstrap/js/bootstrap.bundle.min",
        vue: "requirejs-vue",
        "vue-router": "lib/vue-router/vue-router"
    },
    config:{
        'vue': {
            'css': 'inject',
            'templateVar': 'template'
        }
    },
    shim : {
        bootstrap : ["jquery"],
        vue: [""]
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
        methods:{
            search: function () {
                console.log(this.searchKey);
            }
        }
    });
});