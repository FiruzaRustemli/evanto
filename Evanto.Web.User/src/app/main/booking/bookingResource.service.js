(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('bookingResourceService', resourceService);
    //#endregion

    //#region Dependencies
    resourceService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            // Custom components
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
            /// <para> Creates booking resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Booking Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'bookings/user', { id: '@_id' },
                {
                    query: { method: 'GET', IsArray: false },
                    update: { method: 'PUT' },
                    lastBookings: { method: 'GET', url: appSettings.apiUrlV1() + 'bookings/user/lastBookings', IsArray : false }
                });
        };
    }
    //#endregion
})();

