(function ()
{
    'use strict';

    angular
        .module('app.auth.register', [])
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, msNavigationServiceProvider)
    {
        // State
        $stateProvider.state('app.auth_register', {
            url      : '/{lang:(?:en|az|ru)}/auth/register',
            views    : {
                'main@'                       : {
                    templateUrl: 'app/main/auth/register/register.html',
                    controller : 'RegisterController as vm'
                }
            },
            bodyClass: 'register'
        });
    }

})();