(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('navbarHelper', navbarHelperService);
    //#endregion

    //#region Dependencies
    navbarHelperService.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$state',
            '$rootScope'

            //Custom Components
        ];
    //#endregion

    //#region Function
    function navbarHelperService
        (
        $state,
        $rootScope
        ) {
        var currentNavItem = 'Home';

        var service = {
            setCurrentNavItem: setCurrentNavItem,
            getCurrentNavItem: getCurrentNavItem
        };

        return service;
        function setCurrentNavItem(navItem) {
            currentNavItem = navItem;

            if ($rootScope.loadingProgress == false) {
                $state.transitionTo('app.' + navItem.toLowerCase());
            }
        }

        function getCurrentNavItem() {
            return currentNavItem;
        }

    }
    //#endregion
})();