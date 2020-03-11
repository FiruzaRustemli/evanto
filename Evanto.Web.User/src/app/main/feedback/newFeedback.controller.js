(function () {
    'use strict';

    //#region Module
    angular
        .module('app.feedback')
        .controller('NewFeedbackController', newFeedbackController);
    //#endregion

    //#region Dependencies
    newFeedbackController.$inject =
        [
            // Angular components
            '$timeout',
            '$filter',

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'feedbackTypesService',
            'feedbackResourceService',
            'messageService',
            'translationService',
            'userInfo'
        ];
    //#endregion

    //#region Function
    function newFeedbackController
        (
        $timeout,
        $filter,
        $mdDialog,
        feedbackTypesService,
        feedbackResourceService,
        messageService,
        translationService,
        userInfo
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.sendFeedbackButtonDisabled = false;
        vm.newFeedback = {};
        vm.feedbackTypes = [];
        vm.userInfo = {};

        vm.cancel = function () {
            $mdDialog.cancel();
        };

        vm.getAllFeedbackTypes = getAllFeedbackTypes;

        vm.create = createFeedback;

        activate();


        function activate() {
            getUserInfo();
        }

        function getUserInfo() {
            vm.userInfo = userInfo.get();
        }

        function getAllFeedbackTypes() {
            if (vm.feedbackTypes.length === 0) {
                return $timeout(function () {
                    feedbackTypesService.getData().then(function (response) {
                        vm.feedbackTypes = response.data.output.feedbackTypes;
                    });

                }, 650);
            }
        }

        function createFeedback() {
            vm.sendFeedbackButtonDisabled = true;
            vm.newFeedback.email = vm.userInfo.username;
            feedbackResourceService.resource().save(vm.newFeedback, function () {
                messageService.success($filter('translate')('Toast.Success.FeedbackSent'));
                $mdDialog.hide();
                vm.sendFeedbackButtonDisabled = false;
            });
        };
    }
    //#endregion 
})();


