(function () {
    'use strict';

    angular
        .module('app.event', [])
        .config(config);

    /** @ngInject */
    function config(encodingHelperProvider, vendorServiceResourceServiceProvider, bookingResourceServiceProvider, eventResourceServiceProvider, $stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider) {
        // State
        $stateProvider
            .state('app.events', {
                url: '/dashboard/events',
                views: {
                    'content@app': {
                        templateUrl: 'app/main/event/index.html',
                        controller: 'EventController as vm'
                    }
                },
                resolve: {
                    events: function () {
                        return eventResourceServiceProvider.$get().resource().get().$promise;
                    }
                }
            })
            .state('app.event', {
                url: '/dashboard/event/:id',
                views: {
                    'content@app': {
                        templateUrl: 'app/main/event/edit.html',
                        controller: 'EditEventController as vm'
                    }
                },
                resolve: {
                    bookings: ['$stateParams', function ($stateParams) {
                        var eventId = encodingHelperProvider.$get().decode($stateParams.id)[0];

                        if (eventId === undefined || eventId.length === 0) {
                            $state.transitionTo('app.events');
                        }

                        return bookingResourceServiceProvider.$get().resource()
                            .get({
                                'eventId': eventId
                            }).$promise;
                    }],
                    topVendorServices: function () {
                        return vendorServiceResourceServiceProvider.$get().resource().topServices().$promise;
                    }
                }
            })
            .state('app.event.services', {
                url: '/services',
                templateUrl: 'app/main/service/edit.html',
                controller: 'EditServiceController as vm',
                params: {
                    userServices: []
                },
                resolve: {

                }
            });

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/event');
    }
})();