(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('httpRequestInterceptor', httpRequestInterceptorService);
    //#endregion

    //#region Dependencies
    httpRequestInterceptorService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
            'localStorage'
        ];
    //#endregion

    //#region Function
    function httpRequestInterceptorService
        (
        localStorage
        ) {

        var accessToken = localStorage.getAccessToken();

        return {
            request: function (config) {
                config.headers['Authorization'] = 'Bearer ' + accessToken;

                return config;
            }
        };

    }
    //#endregion
})();