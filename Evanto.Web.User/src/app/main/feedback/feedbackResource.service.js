(function () {
    'use strict';

    //#region Module
    angular
         .module('app.feedback')
         .factory('feedbackResourceService', resourceService);
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
            /// <para> Creates feedback resource object built with data from server. </para>
            /// <para></para>
            /// <para> Available methods: </para>
            /// <para></para>
            /// <para> query, get, $delete, $update, $save</para>
            ///</summary>
            /// <returns type="Evanto Feedback Resource"></returns>
            return $resource(appSettings.apiUrlV1() + 'feedbacks', { id: '@_id' },
                {
                    update: { method: 'PUT' },
                    query: { method: 'GET', isArray: false }
                });
        }
    }
    //#endregion
})();