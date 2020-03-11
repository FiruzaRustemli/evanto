(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('messageService', messageService);
    //#endregion

    //#region Dependencies
    messageService.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$mdToast'

            //Custom Components
        ];
    //#endregion

    //#region Function
    function messageService
        (
        $mdToast
        ) {
        var messages = {
            info: info,
            success: success,
            error: error,
            warn: warn,
            systemError: systemError,
            eventCreated : eventCreated,
            bookingCreated : bookingCreated
        };
        return messages;


        function success(text) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('toastDefault')
                    .hideDelay(6000)
            );
        };

        function eventCreated(text, actionText) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('toastDefault')
                    .action(actionText)
                    .hideDelay(6000)
            );
        }

        function bookingCreated(text, actionText) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('toastDefault')
                    .action(actionText)
                    .hideDelay(6000)
            );
        }

        function warn(text) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('toastWarn')
                    .hideDelay(5000)
            );
        };

        function error(text) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('toastDefault')
                    .hideDelay(3000)
            );
        };

        function systemError(text) {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent(text)
                    .position('bottom left')
                    .toastClass('systemError')
                    .hideDelay(5000)
            );
        };

        function info() {
            return $mdToast.show(
                $mdToast.simple()
                    .textContent('Testing messages')
                    .position('bottom left')
                    .hideDelay(1000)
            );
        };
    }
    //#endregion
})();