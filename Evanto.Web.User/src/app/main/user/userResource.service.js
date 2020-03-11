(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('userResourceService', resourceService);
    //#endregion

    //#region Dependencies
    resourceService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function resourceService
        (
            $resource,
            appSettings
        )
    {
        var service = {
            resource: resource
        };

        return service;
        function resource() {
            /// <summary>
            /// <para> Creates service resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto User Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'users/user', null,
                {
                     updateGeneralInfo: { method: 'PUT', url: appSettings.apiUrlV1() + 'users/user/generalInfo'},
                     updateAdditionalInfo: { method: 'PUT', url: appSettings.apiUrlV1() + 'users/user/additionalInfo'},
                     changePassword: { method: 'PUT', url: appSettings.apiUrlV1() + 'users/account/changePassword'},
                     forgotPassword: { method: 'POST', url: appSettings.apiUrlV1() + 'users/account/forgotPassword'},
                     resetPassword: { method: 'POST', url: appSettings.apiUrlV1() + 'users/account/resetPassword'},
                     verifyAccount: { method: 'POST', url: appSettings.apiUrlV1() + 'users/account/verify'},
                     sendVerificationCode: { method: 'POST', url: appSettings.apiUrlV1() + 'users/account/verificationCode'}
                });
        }
    }
    //#endregion
})();