(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('eventResourceService', resourceService);
    //#endregion

    //#region Dependencies
    resourceService.$inject =
        [
            // Angular components
            

            // 3rd Party Components
            '$resource',

            //Custom Components
            'appSettings'
        ];
    //#endregion
 
    //#region Function
    function resourceService
        (
            $resource,
            appSettings
        ) {
        var service = {
            resource: resource
        };

        return service;
        function resource() {
            /// <summary>
            /// <para> Creates event resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Event Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'events/user', { id: '@_id' },
                {
                    update: { method: 'PUT' },
                    query: { method: 'GET', isArray: false },
                    lastUserEvents: { method: 'GET', url: appSettings.apiUrlV1() + 'events/user/last', IsArray : false }
                });
        }
    }
    //#endregion
})();