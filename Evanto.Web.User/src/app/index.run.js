(function () {
    'use strict';

    angular
        .module('evantoApp')
        .run(runBlock);

    /** @ngInject */
    function runBlock(localStorage, $window, $rootScope, $location, $timeout, $state, authService, $translate, tmhDynamicLocale) {
        // Activate loading indicator
        var stateChangeStartEvent = $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            if (
                $location.path() !== '' &&
                toState.name !== 'app.auth_register' &&
                toState.name !== 'app.auth_forgot_password' &&
                toState.name !== 'app.auth_reset_password' &&
                toState.name !== 'app.auth_login' &&
                toState.name !== 'app.marketplace' &&
                toState.name !== 'app.public_vendorService' &&
                !authService.isAuthenticated()) {
                event.preventDefault();
                $state.transitionTo('app.auth_login', { lang: $translate.use() });
            }

            // Checks authentication
            else if (toState.name === 'app.auth_login') {
                var accessToken = localStorage.getAccessToken();

                if (authService.isAuthenticated(accessToken)) {
                    event.preventDefault();

                    if (localStorage.getRedirectionPage() !== null) {
                        $window.location = localStorage.getRedirectionPage();
                        return;
                    }
                    $state.transitionTo('app.events');
                }
            }
            else {
                $rootScope.loadingProgress = true;
            }
        });

        $rootScope.$on('$translateChangeSuccess', function (event, data) {
            // asking angular-dynamic-locale to load and apply proper AngularJS $locale setting
            tmhDynamicLocale.set(data.language.toLowerCase().replace(/_/g, '-'));
        });


        // De-activate loading indicator
        var stateChangeSuccessEvent = $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            if (toParams.lang !== undefined) {
                $translate.use(toParams.lang);
            }
            $timeout(function () {
                $rootScope.loadingProgress = false;
            });
        });

        // Store state in the root scope for easy access
        $rootScope.state = $state;

        // Cleanup
        $rootScope.$on('$destroy', function () {
            stateChangeStartEvent();
            stateChangeSuccessEvent();
        });
    }
})();