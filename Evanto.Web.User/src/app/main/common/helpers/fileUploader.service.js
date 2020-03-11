(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('fileUploaderService', fileUploaderService);
    //#endregion

    //#region Dependencies
    fileUploaderService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function fileUploaderService
        (
            $http,
            appSettings
        ) {
        var service = {
            uploadUserProfileImage: uploadUserProfileImage
        };

        return service;

        /// <summary>
        /// <para> Uploads profile image of user. </para>
        ///</summary>
        function uploadUserProfileImage(files) {
            return $http.post(appSettings.apiUrlV1() + 'files/avatar', files, {
            });
        }
    }
    //#endregion
})();