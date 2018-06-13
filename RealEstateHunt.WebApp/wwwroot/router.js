define("router", ["vue-router"], function (VueRouter) {
    function view(name) {
        return function (resolve) {
            require(['rvue!/vue/' + name], resolve)
        }
    }
    
    return new VueRouter({
        routes: [
            {
                path: '/test',
                component: view('test')
            },
            {
                path: '/search',
                component: view('search')
            },
            {
                path: '/contact',
                component: view('contactSection')
            },
            {
                path: '/realEstate',
                component: view('realEstateSection')
            },
            {
                path: '/contact/:id',
                component: view('contactPage')
            },
            {
                path: '/realEstate/:id',
                component: view('realEstatePage')
            },
            {
                path: '/offer',
                component: view('offerSection')
            },
            {
                path: '/offer/:id',
                component: view('offerPage')
            }
        ]
    });
});