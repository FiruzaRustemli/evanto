(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('eventTypesService', eventTypesService);
    //#endregion

    //#region Dependencies
    eventTypesService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function eventTypesService
        (
            $http,
            appSettings
        ) {
        var service = {
            getData: getData
        };

        return service;
        function getData(id) {
            /// <summary>
            /// <para> Gets event types from the server. </para>
            ///</summary>
            /// <returns type="Evanto Booking Resource"></returns>
          
          if(angular.isDefined(id))
          {
            return $http.get(appSettings.apiUrlV1() + 'events/types/user?id=' + id);
          }
          return $http.get(appSettings.apiUrlV1() + 'events/types/user');
            
        }

    }
    //#endregion
})();