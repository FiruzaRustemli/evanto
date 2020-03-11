(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('dateTimeJoinHelper', dateTimeJoinHelper);
    //#endregion

    //#region Dependencies
    dateTimeJoinHelper.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$filter'

            //Custom Components
        ];
    //#endregion

    //#region Function
    function dateTimeJoinHelper
        (
            $filter
        ) {

        var service = {
            join: join
        }

        return service;

        //Joins dates and times
        function join(date, time) {
            // create Date object from valid string inputs
            var datetime = new Date(date + ' ' + time);

            // format the output
            var month = datetime.getMonth() + 1;
            var day = datetime.getDate();
            var year = datetime.getFullYear();

            var hour = datetime.getHours();
            if (hour < 10)
                hour = "0" + hour;

            var min = datetime.getMinutes();
            if (min < 10)
                min = "0" + min;

            var sec = datetime.getSeconds();
            if (sec < 10)
                sec = "0" + sec;

            // put it all togeter
            return month + '/' + day + '/' + year + ' ' + hour + ':' + min + ':' + sec;
        }
    }
    //#endregion
})();