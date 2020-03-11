(function () {
    'use strict';

    angular
        .module('evantoApp')
        .config(config);

    /** @ngInject */
    function config($translateProvider, $urlRouterProvider, localStorageProvider) {
        // Put your common app configurations here

        // angular-translate configuration
        $translateProvider.useLoader('$translatePartialLoader', {
            urlTemplate: '{part}/i18n/{lang}.json'
        });
        $translateProvider.preferredLanguage('en');
        $translateProvider.storagePrefix('evantoApplG99V99$Zq5F.');
        //$translateProvider.useSanitizeValueStrategy('sanitize');
        $translateProvider.useLocalStorage();

        $urlRouterProvider.otherwise('/' + getCurrentLanguage() + '/auth/login');

        function getCurrentLanguage()
        {
            if($translateProvider.use() !== undefined && $translateProvider.use() !== null)
            {
                return $translateProvider.use();
            }
            else if(localStorageProvider.$get().getCulture() !== undefined && localStorageProvider.$get().getCulture() !== null)
            {
                return localStorageProvider.$get().getCulture()
            }
            else
            {
                return 'en'
            }
        }
    }

})();