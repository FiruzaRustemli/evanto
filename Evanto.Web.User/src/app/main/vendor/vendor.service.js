(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('vendorService', vendorService);
    //#endregion

    //#region Dependencies
    vendorService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function vendorService
          (
              $http,
              appSettings
          ) {
        var service = {
            getData: getData,
            getUsedVendors: getUsedVendors
        };

        return service;

        function getData(vendorId) {
            return $http.get(appSettings.apiUrlV1() + 'vendors/user?vendorId=' + vendorId);
        }

        function getUsedVendors() {
            return $http.get(appSettings.apiUrlV1() + 'vendors/user/used');
        }
    }
    //#endregion
})();