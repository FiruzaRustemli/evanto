(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('LoadingToastController', loadingToastController);
    //#endregion

    //#region Dependencies
    loadingToastController.$inject =
        [
            // Angular components
            '$rootScope',

            // 3rd Party Components

            // Custom components
            'appResource'
        ];
    //#endregion

    //#region Function
    function loadingToastController
        (
            $rootScope,
            appResource
        )
    {
        /* jshint validthis:true */
        var vm = this;
        vm.loadingText = null;

        activate();

        $rootScope.$on('cultureChanged', function (event, args) {
            getTranslation();
        });

        function activate() {
            getTranslation();
        }


        function getTranslation() {
            vm.loadingText = appResource.getLoadingText();
        }
    }
    //#endregion 
})();


