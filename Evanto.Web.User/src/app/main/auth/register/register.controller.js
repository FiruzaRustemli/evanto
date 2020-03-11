(function () {
    'use strict';

    //#region Module
    angular
        .module('app.auth.register')
        .controller('RegisterController', registerController);
    //#endregion

    //#region Dependencies
    registerController.$inject =
        [
            // Angular components
            '$rootScope',

            // 3rd Party Components
            '$mdToast',
            '$window',
            '$translate',
            '$filter',

            // Custom components
            'registerUserService',
            'appSettings',
            'userResourceService',
            'messageService',
            'authService',
            'localStorage',
        ];
    //#endregion 

    //#region Function
    function registerController
        (
        $rootScope,
        $mdToast,
        $window,
        $translate,
        $filter,
        registerUserService,
        appSettings,
        userResourceService,
        messageService,
        authService,
        localStorage
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.selectedTab = 0;
        vm.isEnterCodePanelActive = false;
        vm.locale = $translate;

        vm.setRegisterInfo = setRegisterInfo;
        vm.sendCodeToEmail = sendCodeToEmail;
        vm.sendCodeToPhone = sendCodeToPhone;
        vm.verifyAccount = verifyAccount;

        $rootScope.$on("registerCredentialsDuplicateResult", function () {
            vm.selectedTab = 0;
        });

        $rootScope.$on("userRegisterSuccess", function () {
            vm.isEnterCodePanelActive = true;
        });

        activate();

        function activate() { }

        function setRegisterInfo() {
            vm.selectedTab = 1;

            // registerUserService.register(registeringUserData);
        };

        function sendCodeToEmail() {
            vm.user.verificationTypeId = appSettings.verificationType.email;

            sendCode();
        }

        function sendCodeToPhone() {
            vm.user.verificationTypeId = appSettings.verificationType.phone;

            sendCode();
        }

        function sendCode() {
            registerUserService.register(vm.user);
        }

        function verifyAccount() {
            var userVerificationInfo = {
                userName: vm.user.username,
                verificationCode: vm.verificationCode
            }

            userResourceService.resource().verifyAccount(userVerificationInfo).$promise.then(function (response) {
                messageService.success($filter('translate')('Toast.Success.AccountVerified'));

                var form = {
                    userName: vm.user.username,
                    password: vm.user.passwordString
                }

                authService.getAccessToken(form).then(function (response) {
                    if (response.data === "" || response.data === null) {
                        messageService.systemError($filter('translate')('Toast.Error.SystemError'));
                    }
                    else {
                        $mdToast.show(
                            $mdToast.loadingToast()
                        );

                        localStorage.setAccessToken(response.data.access_token);
                        if (localStorage.getRedirectionPage() !== null) {
                            $window.location = localStorage.getRedirectionPage();
                            return;
                        }
                        $window.location.href = '/dashboard/events';
                    }

                }, function () {
                    messageService.systemError($filter('translate')('Toast.Error.SystemError'));
                })
            });
        }

    }
    //#endregion 
})();