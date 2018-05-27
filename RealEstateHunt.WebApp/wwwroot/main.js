require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/jquery.min",
        Vue: "../lib/vue/vue",
        lodash: "../lib/lodash/lodash.min",
        bootstrap: "../lib/bootstrap/js/bootstrap.bundle.min",
        vue: "../requirejs-vue"
    },
    config:{
        'vue': {
            'css': 'inject',
            'templateVar': '__template__'
        }
    },
    shim : {
        bootstrap : ["jquery"]
    }
}); 

require(["Vue", "bootstrap"], function (Vue) {
    return new Vue({
        el: "#app",
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