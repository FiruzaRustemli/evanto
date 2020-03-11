/*(function () {
    'use strict';

    angular
        .module('app.home', [])
        .config(config);*/

    /** @ngInject */
   /* function config($stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider) {
        // State
        $stateProvider
            .state('app.home', {
                url: '/dashboard/home',
                views: {
                    'content@app': {
                        templateUrl: 'app/main/home/index.html',
                        controller: 'HomeController as vm'
                    }
                },
                resolve: {
                   
                }
            });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/home');

        // Navigation
        msNavigationServiceProvider.saveItem('home', {
            title: 'Home',
            group: true,
            weight: 1
        });

        msNavigationServiceProvider.saveItem('home', {
            title: 'Home',
            icon: 'icon-home',
            state: 'app.home',
            /*stateParams: {
                'param1': 'page'
             },
            translate: 'Home',
            weight: 1
        });
    }
})();*/