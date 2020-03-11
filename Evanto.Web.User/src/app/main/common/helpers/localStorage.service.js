(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('localStorage', localStorageService);
    //#endregion

    //#region Dependencies
    localStorageService.$inject =
        [
            // Angular components

            // 3rd Party Components
            'localStorageService'

            //Custom Components
        ];
    //#endregion

    //#region Function
    function localStorageService
        (
        localStorageService
        ) {
        var service = {
            setCulture: setCulture,
            getCulture: getCulture,
            getAccessToken: getAccessToken,
            setAccessToken: setAccessToken,
            getRedirectionPage: getRedirectionPage,
            setRedirectionPage: setRedirectionPage,
            clearRedirectionPage: clearRedirectionPage
        };

        return service;
        function setCulture(culture) {
            /// <summary>
            /// <para> Set selected culture to local storage. </para>
            ///</summary>
            localStorageService.remove('NG_TRANSLATE_LANG_KEY');
            localStorageService.set('NG_TRANSLATE_LANG_KEY', culture);
        }

        function getCulture() {
            return localStorageService.get('NG_TRANSLATE_LANG_KEY');
        }

        function setAccessToken(token) {
            /// <summary>
            /// <para> Set selected culture to local storage. </para>
            ///</summary>
            localStorageService.remove('ac_token');
            localStorageService.set('ac_token', token);
        }

        function getAccessToken() {
            return localStorageService.get('ac_token');
        }

        function setRedirectionPage(url) {
            localStorageService.set('redirection_url', url);
        }

         function getRedirectionPage() {
            return localStorageService.get('redirection_url');
        }

        function clearRedirectionPage() {
            localStorageService.remove('redirection_url');
        }

    }
    //#endregion
})();