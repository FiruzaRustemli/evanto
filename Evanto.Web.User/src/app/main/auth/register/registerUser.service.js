(function () {
    'use strict';

    //#region Module
    angular
        .module('app.auth.register')
        .factory('registerUserService', registerUserService);
    //#endregion

    //#region Dependencies
    registerUserService.$inject =
        [
            // Angular components
            '$window',
            '$rootScope',

            // 3rd Party Components
            '$mdToast',
            '$filter',

            //Custom Components
            'localStorage',
            'userResourceService',
            'messageService',
            'authService',
            'phoneHelperService'
        ];
    //#endregion

    //#region Function
    function registerUserService
        (
        $window,
        $rootScope,
        $mdToast,
        $filter,
        localStorage,
        userResourceService,
        messageService,
        authService,
        phoneHelperService
        ) {
        var form = {};

        var service = {
            register: register
        };

        return service;

        function register(registeringUserData) {
            var userData = angular.copy(registeringUserData);
            userData.phone = phoneHelperService.internationalize(userData.phone);

            form.userName = registeringUserData.username;
            form.password = registeringUserData.passwordString;


            userResourceService
                .resource()
                .save(
                userData,
                function () {
                    $rootScope.$emit("userRegisterSuccess")

                    messageService.success($filter('translate')('Toast.Success.AccountCreated'));
                },
                function (response) {
                    messageService.error($filter('translate')('Toast.Success.AccountNotCreated'));

                    if (response.data.errorList.length > 0) {
                        var keepGoing = true;
                        angular.forEach(response.data.errorList, function (value, index) {
                            if (keepGoing) {
                                if (value.code.indexOf('Duplicate') !== -1) {
                                    $rootScope.$emit("registerCredentialsDuplicateResult")
                                    keepGoing = false;
                                }
                            }
                        });
                    }
                });
        }
    }
    //#endregion
})();