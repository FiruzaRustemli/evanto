(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('userServiceModel', userServiceModel);
    //#endregion

    //#region Dependencies
    userServiceModel.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function userServiceModel
        (

        ) {

        var userServiceModel;

        var service = {
            set: setModel,
            get: getModel
        };

        return service;

        function setModel(model) {
            userServiceModel = model;
        }

        function getModel() {
            return userServiceModel;
        }

    }
    //#endregion
})();