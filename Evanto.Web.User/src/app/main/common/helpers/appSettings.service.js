(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('appSettings', appSettingsService);
    //#endregion

    //#region Dependencies
    appSettingsService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Functions
    function appSettingsService
        (
        ) {
        var service = {
            apiUrlV1: apiUrlV1,
            apiUrlV2: apiUrlV2,
            authUrl: authUrl,
            appUrl: appUrl,
            translationsPath: translationsPath,
            base64Prefix: 'data:image/png;base64,',
            fileType: {
                image: 1,
                thumbnail: 2
            },
            notificationStatus : {
                read : 1,
                unRead : 2
            },
            bookingStatus: {
                waiting: 1,
                confirmed: 2,
                rejected: 3
            },
            verificationType: {
                email: 1,
                phone: 2
            }
        };

        return service;

        /// <summary>
        /// <para> Gets api url. </para>
        ///</summary>
        /// <returns type="Evanto Service Resource"></returns>
        function apiUrlV1() {
            return 'http://younggeeks.westeurope.cloudapp.azure.com:8763/api/v1/';
            //return 'http://localhost:51676/api/v1/'
        }

        function apiUrlV2() {
            return 'http://younggeeks.westeurope.cloudapp.azure.com:8763/api/v2/';
            //return 'http://localhost:51676/api/v2/'
        }

        function authUrl() {
            return appUrl() + 'authentication';
        }

        function appUrl() {
            /// <summary>
            /// <para> Gets app url. </para>
            ///</summary>
            return 'http://younggeeks.westeurope.cloudapp.azure.com:8190/';
            //return 'http://localhost:50899/';
        }

        function translationsPath() {
            return appUrl() + 'translations/';
        }
    }
    //#endregion
})();