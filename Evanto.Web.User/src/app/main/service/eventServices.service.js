(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('eventServicesResourceService', eventServicesService);
    //#endregion

    //#region Dependencies
    eventServicesService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function eventServicesService
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
            /// <para> Creates event service resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Service Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'user/eventService', { id: '@_id' },
                {
                    query: { method: 'GET', IsArray: false },
                    update: { method: 'PUT' }
                });
        }
    }
    //#endregion
})();