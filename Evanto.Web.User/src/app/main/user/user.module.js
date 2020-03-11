(function ()
{
    'use strict';

    angular
        .module('app.user', []) 
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider)
    {
        // State
        $stateProvider
            .state('app.user', {
                url: '/profile',
                views  : {
                    'content@app': {
                        templateUrl: 'app/main/user/profile.html',
                        controller : 'UserProfileController as vm'
                    }
                },
                resolve: {
                  
                }
            });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/user');
    }
})();