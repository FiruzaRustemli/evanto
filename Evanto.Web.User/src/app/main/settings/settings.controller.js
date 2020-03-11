(function () {
    'use strict';

    //#region Module
    angular
        .module('app.settings')
        .controller('SettingsController', settingsController);
    //#endregion

    //#region Dependencies
    settingsController.$inject =
        [
            // Angular components
            '$timeout',
            '$scope',

            // 3rd Party Components
            '$mdDialog',
            '$state',
            '$cookies',
            'fuseTheming',
            '$translate',

            // Custom components
            'eventTypesService',
            'eventResourceService',
            'translationService',
            'messageService',
            'settingsResourceService',
            'userInfo'
        ];
    //#endregion

    //#region Function
    function settingsController
        (
        $timeout,
        $scope,
        $mdDialog,
        $state,
        $cookies,
        fuseTheming,
        $translate,
        eventTypesService,
        eventResourceService,
        translationService,
        messageService,
        settingsResourceService,
        userInfo
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.themeSelectionEnabled = false;
        vm.settings = {}

        vm.languages = {
            en: {
                'title': 'English',
                'translation': 'Layout.English',
                'code': 'en',
                'flag': 'us'
            },

            az: {
                'title': 'Azerbaijan',
                'translation': 'Layout.Azerbaijan',
                'code': 'az',
                'flag': 'az'
            },
            ru: {
                'title': 'Russian',
                'translation': 'Layout.Russian',
                'code': 'ru',
                'flag': 'ru'
            }
        };

        // Data
        vm.themes = fuseTheming.themes;


        vm.layoutMode = 'wide';
        vm.layoutStyle = $cookies.get('layoutStyle') || 'horizontalNavigation';

        // Methods
        vm.setActiveTheme = setActiveTheme;
        vm.getActiveTheme = getActiveTheme;
        vm.updateLayoutMode = updateLayoutMode;
        vm.updateLayoutStyle = updateLayoutStyle;
        vm.changeLanguage = changeLanguage;

        //////////

        /**
         * Set active theme
         *
         * @param themeName
         */
        function setActiveTheme(themeName) {

            vm.settings.theme = themeName;
            settingsResourceService.resource().update(vm.settings);

            fuseTheming.setActiveTheme(themeName);
        }

        /**
         * Get active theme
         *
         * @returns {service.themes.active|{name, theme}}
         */
        function getActiveTheme() {
            return fuseTheming.themes.active;
        }

        /**
 * Change Language
 */
        function changeLanguage(lang) {
            vm.selectedLanguage = vm.languages[lang.code];;

            // Change the language
            $translate.use(lang.code);

            // Save culture to db

            vm.settings.langCode = vm.selectedLanguage.code;
            settingsResourceService.resource().update(vm.settings);
        }

        /**
         * Update layout mode
         */
        function updateLayoutMode() {
            var bodyEl = angular.element('body');

            // Update class on body element
            bodyEl.toggleClass('boxed', (vm.layoutMode === 'boxed'));
        }

        /**
         * Update layout style
         */
        function updateLayoutStyle() {
            // Update the cookie
            $cookies.put('layoutStyle', vm.layoutStyle);

            // Reload the page to apply the changes
            location.reload();
        }

        vm.cancel = cancel;

        activate();

        function activate() {
            setThemeAndCulture();
        }

        function cancel() {
            $mdDialog.cancel();
        }

        function setThemeAndCulture() {
            vm.selectedLanguage = vm.languages[$translate.use()];

            vm.settings.langCode = vm.selectedLanguage.code;

            vm.settings.theme = userInfo.get().selectedTheme;
        }


    }
    //#endregion 
})();


