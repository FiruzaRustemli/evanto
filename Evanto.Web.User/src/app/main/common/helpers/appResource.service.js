(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('appResource', appResourceService);
    //#endregion

    //#region Dependencies
    appResourceService.$inject =
        [
            // Angular components
            '$filter',

            // 3rd Party Components

            //Custom Components
            'translationService'
        ];
    //#endregion

    //#region Function
    function appResourceService
        (
        $filter,
        translationService
        ) {
        var loadingText;

        var service = {
            getLoadingText: getLoadingText,
            setLoadingText: setLoadingText
        };

        return service;

        function setLoadingText() {
            loadingText = $filter('translate')('Toast.LoggingIn');
        }

        function getLoadingText() {
            setLoadingText();
            return loadingText;
        }
    }
    //#endregion
})();