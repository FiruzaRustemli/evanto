(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('userServiceBudgetService', userServiceBudgetService);
    //#endregion

    //#region Dependencies
    userServiceBudgetService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function userServiceBudgetService
        (

        ) {
        var assignedBudget;

        var service = {
            get: getAssignedBudget,
            set: setAssignedBudget
        };

        return service;
        function getAssignedBudget() {
            return assignedBudget;
        }

        function setAssignedBudget(budget) {
            assignedBudget = budget;
        }
    }
    //#endregion
})();