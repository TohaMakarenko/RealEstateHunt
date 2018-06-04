define("router", ["vue-router"], function (VueRouter) {
    function view(name) {
        return function (resolve) {
            require(['vue!/vue/' + name], resolve)
        }
    }
    
    return new VueRouter({
        routes: [
            {
                path: '/test',
                component: view('test')
            }
        ]
    });
});