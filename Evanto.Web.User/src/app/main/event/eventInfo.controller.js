(function () {
    'use strict';

    //#region Module
    angular
        .module('app.event')
        .controller('EventInfoController', eventInfoController);
    //#endregion

    //#region Dependencies
    eventInfoController.$inject =
        [
            // Angular components
            '$scope',

            // 3rd Party Components
            '$mdDialog',
            '$state',

            // Custom components
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function eventInfoController
        (
            $scope,
            $mdDialog,
            $state,
            encodingHelper
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.eventInfo = $scope.eventInfo;

        vm.goToEventPage = goToEventPage;

        vm.cancel = function () {
            $mdDialog.cancel();
        };

        activate();


        function activate() {

        }

        function goToEventPage(id) {
            vm.cancel();

            $state.transitionTo('app.event', {
                'id': encodingHelper.encode(id)
            });
        }

    }
    //#endregion 
})();


