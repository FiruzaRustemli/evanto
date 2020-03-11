(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('userServiceResourceService', resourceService);
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
            /// <para> Creates user service resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Service Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'services/user/userService', { id: '@_id' },
                {
                    query: {method: 'GET', IsArray: false},
                    update: { method: 'PUT' }
                });
        }
    }
    //#endregion
})();