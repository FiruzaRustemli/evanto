(function () {
    'use strict';

    angular
        .module('app.public.marketplace', [])
        .config(config);

    /** @ngInject */
    function config($mdThemingProvider, $stateProvider, $translatePartialLoaderProvider, msNavigationServiceProvider, allEventTypesServiceProvider, allServicesServiceProvider) {
        // State
        $stateProvider.state('app.marketplace', {
            url: '/{lang:(?:en|az|ru)}/marketplace',
            views: {
                'main@': {
                    templateUrl: 'app/main/public/marketplace/marketplace.html',
                    controller: 'AllVendorServicesController as vm'
                }
            },
            bodyClass: 'marketplace',
            resolve: {
                allServices: function () {
                    return allServicesServiceProvider.$get().getData();
                },
                allEventTypes: function () {
                    return allEventTypesServiceProvider.$get().getData();
                }
            }
        }).state('app.public_vendorService', {
            url: '/{lang:(?:en|az|ru)}/marketplace/:vendorServiceId',
            views: {
                'main@': {
                    templateUrl: 'app/main/public/marketplace/marketplaceVendorService.html',
                    controller: 'MarketplaceVendorService as vm'
                }
            },
            bodyClass: 'marketplace-vendorservice',
            resolve: {
                /* vendorServiceInfo: ['$http', '$stateParams', function ($http, $stateParams) {
                     return $http.get('/recipes/' + $stateParams.cat)
                         .then(function (data) { return data.data; });
                 }],
                 allEventTypes: function () {
                     return allEventTypesServiceProvider.$get().getData();
                 }*/
            }
        });

         // Translation
        $translatePartialLoaderProvider.addPart('app/main/public');
    }

})();