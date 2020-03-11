(function () {
    'use strict';

    //#region Module
    angular
         .module('app.feedback')
         .factory('feedbackTypesService', feedbackTypesService);
    //#endregion

    //#region Dependencies
    feedbackTypesService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function feedbackTypesService
        (
            $http,
            appSettings
        ) {
        var service = {
            getData: getData
        };

        return service;
        function getData() {
            /// <summary>
            /// <para> Gets event types from the server. </para>
            ///</summary>
            /// <returns type="Evanto Booking Resource"></returns>
          
            return $http.get(appSettings.apiUrlV1() + 'feedbacks/types');
            
        }

    }
    //#endregion
})();