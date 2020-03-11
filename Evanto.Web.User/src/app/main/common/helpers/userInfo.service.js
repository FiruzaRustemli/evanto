(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('userInfo', userInfoService);
    //#endregion

    //#region Dependencies
    userInfoService.$inject =
        [
            // Angular components
            '$rootScope',

            // 3rd Party Components

            //Custom Components
            'contentLoadingService',
            'userResourceService'
        ];
    //#endregion

    //#region Function
    function userInfoService
        (
        $rootScope,
        contentLoadingService,
        userResourceService
        ) {
        var userInfo;

        var service = {
            get: getUserInfo
        };

        return service;

        function getUserInfo() {
            if (angular.isDefined(userInfo)) {
                return userInfo
            }
            else {
                return userResourceService.resource().get(function (response) {
                    userInfo = response.output.user;
                    return userInfo;
                });
            }
        }
    }
    //#endregion
})();