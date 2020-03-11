(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('ServiceController', serviceController);
    //#endregion

    //#region Dependencies
    serviceController.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components
            'serviceResourceService',
            'pageHeaderService'
        ];
    //#endregion

    //#region Function
    function serviceController
        (
            serviceResourceService,
            pageHeaderService
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'User services';

        function getAllServices() {
            return serviceResourceService.resource().query();
        }

        activate();


        function activate() {
            pageHeaderService.set(vm.title);
            alert(pageHeaderService.get());
        }

    }
    //#endregion 
})();


