(function () {
    'use strict';

    //#region Module
    angular
         .module('app.feedback')
         .factory('settingsResourceService', settingsResourceService);
    //#endregion

    //#region Dependencies
    settingsResourceService.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$resource',

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function settingsResourceService
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
            /// <para> Manages user settings resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Usersetting Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'users/user/settings', { id: '@_id' },
                {
                    update: { method: 'PUT' }
                });
        }
    }
    //#endregion
})();