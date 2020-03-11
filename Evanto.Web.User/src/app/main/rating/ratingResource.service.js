(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('ratingResourceService', ratingResourceService);
    //#endregion

    //#region Dependencies
    ratingResourceService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function ratingResourceService
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
            /// <para> Rating resource object. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Rating Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'ratings/user', { id: '@_id' },
                {
                    query: { method: 'GET', IsArray: false }
                });
        }

    }
    //#endregion
})();