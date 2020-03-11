(function () {
    'use strict';

    //#region Module
    angular
        .module('app.booking')
        .filter('bookingStatus', bookingStatusFilter);
    //#endregion

    //#region Dependencies
    bookingStatusFilter.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function bookingStatusFilter() {
        return function (number) {
            if (number === 1) {
                return "Waiting";
            }
            else if (number === 2) {
                return "Confirmed";
            }
            else {
                return "Rejected";
            }
        }
    }
    //#endregion 
})();



