(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('routeService', routeService);
    //#endregion

    //#region Dependencies
    routeService.$inject =
        [
            // Angular components
            '$rootScope',

            // 3rd Party Components

            //Custom Components
            'contentLoadingService'
        ];
    //#endregion

    //#region Function
    function routeService
        (
            $rootScope,
            contentLoadingService
        )
    {
        var service = {
            initialize: initialize
        };

        return service;

        /// <summary>
        /// <para> Initializes route configuration. </para>
        ///</summary>
        function initialize() {

        }
    }
    //#endregion
})();