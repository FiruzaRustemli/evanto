(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('contentLoadingService', contentLoadingService);
    //#endregion

    //#region Dependencies
    contentLoadingService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function contentLoadingService
        (

        )
    {
        var isContentLoading;

        var service = {
            get: getIsContentLoading,
            setTrue: setTrue,
            setFalse: setFalse
        };

        return service;

        function getIsContentLoading() {
            return isContentLoading;
        }

        function setTrue() {
            isContentLoading = true;
        }

        function setFalse() {
            isContentLoading = false;
        }

    }
    //#endregion
})();