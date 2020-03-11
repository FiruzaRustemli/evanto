(function () {
    'use strict';

    angular
        .module('app.auth.login', [])
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, $locationProvider, msNavigationServiceProvider, localStorageProvider, authServiceProvider) {
        // State
        $stateProvider.state('app.auth_login', {
            url: '/{lang:(?:en|az|ru)}/auth/login',
            views: {
                'main@': {
                    templateUrl: 'app/main/auth/login/login.html',
                    controller: 'LoginController as vm'
                }
            },
            bodyClass: 'login',
            resolve:
            {
               /* checkAcessToken: function ($q, $window, $state) {
                    var deferred = $q.defer();

                    var accessToken = localStorageProvider.$get().getAccessToken();
                    if (authServiceProvider.$get().isAuthenticated(accessToken)) {
                        if (localStorageProvider.$get().getRedirectionPage() !== null) {
                            $window.location = localStorageProvider.$get().getRedirectionPage();
                            return;
                        }
                        $state.go('app.events');

                        return deferred.reject({ redirectTo: 'app.events' })
                    }
                    else {
                        return deferred.resolve();
                    }
                }*/
            }
        });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/auth');
        $translatePartialLoaderProvider.addPart('app/main/toast');
    }

})();