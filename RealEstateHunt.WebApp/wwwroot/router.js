define("router", ["vue-router"], function (VueRouter) {
    function view(name) {
        return function (resolve) {
            require(['rvue!/vue/' + name], resolve)
        }
    }
    
    return new VueRouter({
        routes: [
            {
                path: '/search',
                component: view('Search/search')
            },
            {
                path: '/contact',
                component: view('Contact/contactSection')
            },
            {
                path: '/contact/:id',
                component: view('Contact/contactPage')
            },
            {
                path: '/realEstate',
                component: view('RealEstate/realEstateSection')
            },
            {
                path: '/realEstate/:id',
                component: view('RealEstate/realEstatePage')
            },
            {
                path: '/offer',
                component: view('Offer/offerSection')
            },
            {
                path: '/offer/:id',
                component: view('Offer/offerPage')
            }
        ]
    });
});