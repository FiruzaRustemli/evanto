(function () {
    'use strict';

    angular
        .module('evantoApp')
        .controller('IndexController', IndexController);

    /** @ngInject */
    function IndexController(fuseTheming, $rootScope, $interval, $http, $location, appSettings) {
        var vm = this;

        // Data
        vm.themes = fuseTheming.themes;

        //////////

        init();

        function init() {
            checkConnectionRepeatedly();
        }

        function checkConnectionRepeatedly() {
            $interval(function () {
                if($location.path() !== 'auth/login' && 
                   $location.path() !== 'auth/register' && 
                   $location.path().indexOf('marketplace') !== -1)
                   
                $http.get(appSettings.appUrl() + 'connection/check').then(function () {
                    $rootScope.$broadcast('userStatusChanged', {
                        userStatus: 0
                    });
                }, function () {
                    $rootScope.$broadcast('userStatusChanged', {
                        userStatus: 1
                    });
                });
            }, 3000);
        }
    }
})();