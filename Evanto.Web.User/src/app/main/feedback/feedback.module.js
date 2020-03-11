(function () {
    'use strict';

    angular
        .module('app.feedback', [])
        .config(config);

    /** @ngInject */
    function config($stateProvider, $translatePartialLoaderProvider, msApiProvider, msNavigationServiceProvider) {
        // State
      

        // Translation
        $translatePartialLoaderProvider.addPart('app/main/feedback');
    }
})();