(function ()
{
    'use strict';

    angular
        .module('app.vendor', [])
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider)
    {
        // State
        $stateProvider
            .state('app.vendorServices', {
                url: '/vendor/vendorservices/:id',
                views  : {
                    'content@app': {
                        templateUrl: 'app/main/vendor/vendorServices.html',
                        controller : 'VendorServicesController as vm'
                    }
                },
                 params: {
                    vendorInfo : {}
                }
            });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/booking');
    }
})();