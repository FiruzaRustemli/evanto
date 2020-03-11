(function ()
{
    'use strict';

    angular
        .module('app.booking', [])
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider)
    {
        // State
        $stateProvider
            .state('app.bookings', {
                url: '/dashboard/booking?id',
                views  : {
                    'content@app': {
                        templateUrl: 'app/main/booking/index.html',
                        controller : 'BookingController as vm'
                    }
                },
                reloadOnSearch: false,
                resolve: {
                    //SampleData: function (msApi)
                    //{
                    //    return msApi.resolve('sample@get');
                    //}
                }
            });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/booking');
    }
})();