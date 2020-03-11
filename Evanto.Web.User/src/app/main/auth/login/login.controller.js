(function () {
    'use strict';

    //#region Module
    angular
        .module('app.auth.login')
        .controller('LoginController', loginController);
    //#endregion

    //#region Dependencies
    loginController.$inject =
        [
            // Angular components
            '$window',
            '$location',
            '$filter',

            // 3rd Party Components

            '$mdToast',
            '$translate',

            // Custom components
            'authService',
            'localStorage',
            'messageService',
            'userResourceService',
            'phoneHelperService',
            'appSettings'
        ];
    //#endregion

    //#region Function
    function loginController
        (
        $window,
        $location,
        $filter,
        $mdToast,
        $translate,
        authService,
        localStorage,
        messageService,
        userResourceService,
        phoneHelperService,
        appSettings
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.form = {};

        vm.isEnterCodePanelActive = false;
        vm.verificationCode = null;
        vm.selectedTab = 0;
        vm.loginButtonEnabled = true;
        vm.locale = $translate;

        vm.login = login;
        vm.verifyAccount = verifyAccount;
        vm.sendCodeToPhone = sendCodeToPhone;
        vm.sendCodeToEmail = sendCodeToEmail;
        

        activate();

        function activate() {
            checkAccessToken();
        };

        function login() {
            vm.loginButtonEnabled = false;
            authService.getAccessToken(vm.form).then(function (response) {
                vm.loginButtonEnabled = true;

                if (response.data !== undefined && response.data !== null) {
                    if (response.data.errorList !== undefined) {
                        var data = JSON.parse(response.data.errorList.error);

                        if (data.length > 0) {
                            var keepGoing = true;

                            angular.forEach(data, function (value, index) {
                                if (keepGoing) {
                                    if (value.Code.indexOf('UserAccountNotVerified') !== -1) {
                                        vm.isEnterCodePanelActive = true;
                                        messageService.warn($filter('translate')('Toast.Warning.PleaseVerifyYourAccount'));
                                        keepGoing = false;
                                    }
                                    else {
                                        messageService.systemError(value.Text);
                                    }
                                }
                            });
                        }
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

                }

            });
        }

        function checkAccessToken() {
            var accessToken = localStorage.getAccessToken();
            if (authService.isAuthenticated(accessToken)) {
                if (localStorage.getRedirectionPage() !== null) {
                    $window.location = localStorage.getRedirectionPage();
                    return;
                }
                $location.path('/dashboard/events');
            }
        }

        function verifyAccount() {
            var userVerificationInfo = {
                userName: vm.form.username,
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

       function sendCodeToPhone() {
            var parameters = {
                phone: phoneHelperService.internationalize(vm.form.phone),
                verificationType: appSettings.verificationType.phone
            }

            vm.verificationType = appSettings.verificationType.phone;

            sendCode(parameters);
        }

        function sendCodeToEmail() {
            var parameters = {
                email: vm.form.username,
                verificationType: appSettings.verificationType.email
            }

            vm.verificationType = appSettings.verificationType.email;

            sendCode(parameters);
        }

        function sendCode(parameters) {
            userResourceService
                .resource()
                .sendVerificationCode(parameters, function () {
                    if (vm.verificationType === appSettings.verificationType.email) {
                        messageService.success($filter('translate')('Toast.Success.VerificationCodeSentEmail'));
                    }
                    if (vm.verificationType === appSettings.verificationType.phone) {
                        messageService.success($filter('translate')('Toast.Success.VerificationCodeSentPhone'));
                    }

                    vm.selectedTab = 0;
                });
        }

    }
    //#endregion 
})();