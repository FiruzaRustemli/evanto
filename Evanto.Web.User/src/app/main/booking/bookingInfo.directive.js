(function () {
    'use strict';

    //#region Module
    angular
        .module('app.booking')
        .directive('bookingInfo', bookingInfoDirective);
    //#endregion

    //#region Dependencies
    bookingInfoDirective.$inject =
        [
            // Angular components
            '$location',
            '$state',
            '$window',

            // 3rd Party Components
            '$mdMedia',
            '$translate',

            // Custom components
            'encodingHelper'

        ];
    //#endregion

    //#region Function
    function bookingInfoDirective() {
        return {
            restrict: 'E',
            scope: {
                bookingInfo: '=info'
            },
            templateUrl: 'app/main/booking/bookingInfo.html',
            controller: bookingInfoController,
            controllerAs: 'vm'
        }
    }

    /** @ngInject */
    function bookingInfoController($location, $state, $window, $mdMedia, $translate, encodingHelper) {
        var vm = this;
        vm.$mdMedia = $mdMedia;

        vm.goToEventPage = goToEventPage;
        vm.goToVendorServicesPage = goToVendorServicesPage;
        vm.showInMarketPlace = showInMarketPlace;


        function goToEventPage(id) {
            $state.go('app.event', {
                'id': encodingHelper.encode(id)
            });
        }

        function goToVendorServicesPage(id) {
            $state.go('app.vendorServices', {
                'id': encodingHelper.encode(id)
            });
        }

        function showInMarketPlace(vendorService) {
            $window.open('/' + $translate.use() +  '/marketplace/' + vendorService.name + '-' + encodingHelper.encode(vendorService.id), '_blank');
        };
    }
    //#endregion 
})();



