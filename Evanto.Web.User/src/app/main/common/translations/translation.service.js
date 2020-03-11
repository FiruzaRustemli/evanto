(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('translationService', translationService);
    //#endregion

    //#region Dependencies
    translationService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components
            'localStorage',

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function translationService
        (
            $http,
            localStorage,
            appSettings
        ) {
        var service = {
            getTranslations: getTranslations
        };

        return service;
        function getTranslations(filename) {
            /// <summary>
            /// <para> Gets translations from a json file by culture name. </para>
            ///</summary>
            /// <returns type="Evanto Service Resource"></returns
            return $http.get('app/data/' + filename + "/" + "az" + '.json');
        }
    }
    //#endregion
})();