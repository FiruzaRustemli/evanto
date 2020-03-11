(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .config(appConfig);
    //#endregion

    //#region Dependencies
    appConfig.$inject =
        [
            // Angular components
            '$httpProvider',
            '$windowProvider',

            // 3rd Party Components
            '$mdToastProvider',
            '$mdThemingProvider',
            'tmhDynamicLocaleProvider',
            'localStorageServiceProvider',
            '$mdDateLocaleProvider',

            // Custom components
            'appResourceProvider',
            'messageServiceProvider',
            'translationServiceProvider',
            'localStorageProvider'
        ];
    //#endregion

    //#region Functions
    function appConfig
        (
        $httpProvider,
        $windowProvider,
        $mdToastProvider,
        $mdThemingProvider,
        tmhDynamicLocaleProvider,
        localStorageServiceProvider,
        $mdDateLocaleProvider,
        appResourceProvider,
        messageServiceProvider,
        translationServiceProvider,
        localStorageProvider
        ) {

        // Sets default date format
        $mdDateLocaleProvider.formatDate = function (date) {
            return moment(date).format('DD-MM-YYYY');
        };

        // Sets default first day
        $mdDateLocaleProvider.firstDayOfWeek = 1;

        // Sets default locale file for angular app
        tmhDynamicLocaleProvider.localeLocationPattern('app/main/common/helpers/locales/angular-locale_{{locale}}.js');

        // Adds prefix to local storage value.
        localStorageServiceProvider
            .setPrefix('evantoApplG99V99$Zq5F');

        // Adds loading preset to mdtoast.
        $mdToastProvider.addPreset('loadingToast', {
            options: function () {
                return {
                    hideDelay: 2000,
                    controller: 'LoadingToastController',
                    controllerAs: 'vm',
                    templateUrl: 'app/main/common/messages/loadingToast.html',
                    bindToController: true
                };
            }
        });

        $mdThemingProvider.theme('default').primaryPalette('indigo');

        // Adds http interceptors.
        $httpProvider.interceptors.push(['$q', function ($q) {
            return {
                // optional method
                'request': function (config) {
                    var culture = localStorageProvider.$get().getCulture();
                    var accessToken = localStorageProvider.$get().getAccessToken();

                    config.headers['Authorization'] = 'Bearer ' + accessToken;
                    config.headers['Accept-Language'] = culture;
                    return config || $q.when(config);
                },
                // optional method
                'requestError': function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    return response || $q.when(response);
                },
                responseError: function (response) {
                    var apiResponse = response;
                    if (angular.isDefined(apiResponse) && apiResponse !== null) {
                        if (angular.isDefined(apiResponse.data) && apiResponse.data !== null) {
                            if (apiResponse.data.isSuccess === false) {
                                if (apiResponse.data.errorList[0] !== null) {
                                    messageServiceProvider.$get().systemError(apiResponse.data.errorList[0]["text"]);
                                }
                                else {
                                    translationServiceProvider.$get().getTranslations('toast').then(function (response) {
                                        messageServiceProvider.$get().systemError(response.data.SystemError);
                                    });
                                }
                            }
                        }

                        if (response.status === 401) {
                            localStorageProvider.$get().setAccessToken(null);
                            $windowProvider.$get().location.href = '/auth/login';
                        }
                    }
                    return $q.reject(response);
                }
            };
        }]);
    }
    //#endregion 
})();


