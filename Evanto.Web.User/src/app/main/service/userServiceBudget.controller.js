(function () {
    'use strict';

    //#region Module
    angular
        .module('app.vendor')
        .controller('UserServiceBudgetController', userServiceBudgetController);
    //#endregion

    //#region Dependencies
    userServiceBudgetController.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'userServiceBudgetService'
        ];
    //#endregion

    //#region Function
    function userServiceBudgetController
        (
            $mdDialog,
        userServiceBudgetService
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.cancel = cancelDialog;
        vm.setAssignedBudget = setAssignedBudget;
        vm.assignedBudget = null;

        activate();


        function activate() {
        }

        function cancelDialog() {
            $mdDialog.cancel();
        };

        function setAssignedBudget() {
            if (angular.isDefined(vm.assignedBudget)) {
                userServiceBudgetService.set(vm.assignedBudget);

                $mdDialog.cancel();
            }
        }
    }
    //#endregion 
})();


