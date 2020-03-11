(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('authService', authService);
    //#endregion

    //#region Dependencies
    authService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components
            '$state',
            'jwtHelper',
            '$translate',

            // Custom components
            'appSettings',
            'localStorage'
        ];
    //#endregion

    //#region Function
    function authService
        (
        $http,
        $state,
        jwtHelper,
        $translate,
        appSettings,
        localStorage
        ) {
        var service = {
            getAccessToken: getAccessToken,
            checkAuthentication: checkAuthentication,
            isAuthenticated: isAuthenticated
        };

        return service;
        function getAccessToken(userInfo) {
            /// <summary>
            /// <para> Gets access token from auth server. </para>
            /// <para></para>
            ///</summary>
            /// <returns type="Access token"></returns>
            return $http.post(appSettings.authUrl() + '/login', userInfo);
        };

        function checkAuthentication() {
            /// <summary>
            /// <para> Check authentication of user. </para>
            /// <para></para>
            ///</summary>
            /// <returns type="Access token"></returns>
            var accessToken = localStorage.getAccessToken();

            if (accessToken !== null) {
                $state.transitionTo('app.auth_login', {lang : $translate.use()});
            }
        };

        function isAuthenticated() {
            /// <summary>
            /// <para> Checks authentication of user. </para>
            /// <para></para>
            ///</summary>
            /// <returns type="Access token"></returns>
            var accessToken = localStorage.getAccessToken();

            return accessToken !== null && !jwtHelper.isTokenExpired(accessToken);
        };
    }
    //#endregion
})();

