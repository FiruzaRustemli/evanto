(function () {
    'use strict';

    angular
        .module('app.navigation')
        .controller('NavigationController', NavigationController);

    /** @ngInject */
    function NavigationController($rootScope, $mdDialog, $scope, navbarHelper, eventAndBookingsCountService) {
        var vm = this;

        // Data
        vm.bodyEl = angular.element('body');
        vm.folded = false;
        vm.msScrollOptions = {
            suppressScrollX: true
        };

        // Methods
        vm.toggleMsNavigationFolded = toggleMsNavigationFolded;
        vm.navbarHelper = navbarHelper;

        vm.searchText = null;

        vm.addEvent = addEvent;

        //////////

        /**
         * Toggle folded status
         */
        function toggleMsNavigationFolded() {
            vm.folded = !vm.folded;
        }

        function getEventAndBookingsCount() {
            eventAndBookingsCountService.getData().then(function (response) {
                var data = response.data.output;
                vm.allBookingsCount = data.rejectedBookingsCount + data.waitingBookingsCount + data.confirmedBookingsCount;
                vm.allEventsCount = data.eventsCount;
            });
        };

        // Close the mobile menu on $stateChangeSuccess
        $scope.$on('$stateChangeSuccess', function () {
            vm.bodyEl.removeClass('ms-navigation-horizontal-mobile-menu-active');
        });

        $scope.$watch(function () { return vm.searchText }, function (newVal, oldVal) {
            if (newVal != oldVal && newVal !== null) {
                if (navbarHelper.getCurrentNavItem() === 'Events') {
                    $rootScope.$broadcast('eventSearchRequested', { searchText: vm.searchText })
                }
                else if (navbarHelper.getCurrentNavItem() === 'Bookings') {
                    $rootScope.$broadcast('bookingSearchRequested', { searchText: vm.searchText })
                }
            }
        });

        getEventAndBookingsCount();

        function addEvent() {
            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/event/new.html',
                    parent: angular.element(document.body),
                    openFrom: '#btnAddNewEvent',
                    focusOnOpen: false
                });
        }
    }

})();