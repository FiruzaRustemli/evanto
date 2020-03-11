(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('widgetService', widgetService);
    //#endregion

    //#region Dependencies
    widgetService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Functions
    function widgetService
        (

        ) {
        var service = {
            getData: getData
        };

        return service;

        function getData(eventHeader, bookingHeader) {

            return {
                dynamicColumns: false,
                resizeableColumns: false,
                columns: [
                    {
                        name: "Widget",
                        background: "transparent",
                        size: 25,
                        widgets: [
                        {
                            name: "yourEvents",
                            title: eventHeader,
                            type: "include",
                            content: "/content/js/angular/app/event/eventCount.html",
                            resize: false,
                            minHeight: "150",
                            closeControl: false,
                            maxHeight: "150",
                            sticky: false,
                            stickyControl: false,
                            controlsLayout: "fab",
                            fullscreenControl: true
                        }]
                    },
                    {
                        name: "Widget",
                        background: "transparent",
                        size: 25,
                        widgets: [

                    {
                        name: "yourBookings",
                        title: bookingHeader,
                        type: "include",
                        content: "/content/js/angular/app/booking/bookingCount.html",
                        resize: false,
                        minHeight: "150",
                        closeControl: false,
                        maxHeight: "150",
                        sticky: false,
                        stickyControl: false,
                        controlsLayout: "fab",
                        fullscreenControl: true
                    }
                        ]
                    }

                ]
            }
        }
    }
    //#endregion
})();