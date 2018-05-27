require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/jquery.min",
        Vue: "../lib/vue/vue",
        lodash: "../lib/lodash/lodash.min",
        bootstrap: "../lib/bootstrap/js/bootstrap.bundle.min"
    },
    shim : {
        bootstrap : ["jquery"]
    }
}); 

require(["Vue", "bootstrap"], function (Vue) {
    return new Vue({
        el: "#app",
        data: {
            message: "asdad"
        }
    });
});