(function () {
    'use strict';

    angular
        .module('app.toolbar')
        .controller('ToolbarController', ToolbarController);

    /** @ngInject */
    function ToolbarController(
        $rootScope,
        $mdDialog,
        $q,
        $scope,
        $state,
        $timeout,
        $mdSidenav,
        $translate,
        $mdToast,
        msNavigationService,
        userInfo,
        localStorage,
        fuseTheming,
        notificationService,
        appSettings) {

        var vm = this;

        // Data
        $rootScope.global = {
            search: ''
        };

        vm.bodyEl = angular.element('body');
        vm.userStatusOptions = [
            {
                'title': 'Online',
                'icon': 'icon-checkbox-marked-circle',
                'color': '#4CAF50',
            },
            {
                'title': 'Offline',
                'icon': 'icon-checkbox-blank-circle-outline',
                'color': '#616161',
                'translation': 'Layout.YouAreOffline'
            }
        ];
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
        vm.locale = $translate;

        // Methods
        vm.toggleSidenav = toggleSidenav;
        vm.logout = logout;
        vm.userInfo = {};
        vm.appSettings = appSettings;
        vm.toggleHorizontalMobileMenu = toggleHorizontalMobileMenu;
        vm.toggleMsNavigationFolded = toggleMsNavigationFolded;
        vm.search = search;
        vm.searchResultClick = searchResultClick;
        vm.showSettingsDialog = showSettingsDialog;
        vm.showFeedbackDialog = showFeedbackDialog;
        vm.addEvent = addEvent;     


        // Listen for user status change
        $rootScope.$on('userStatusChanged', function (event, data) {
            vm.userStatus = vm.userStatusOptions[data.userStatus];
        });

        //////////

        init();

        /**
         * Initialize
         */
        function init() {
            // Select the first status as a default
            vm.userStatus = vm.userStatusOptions[0];

            // Get the selected language directly from angular-translate module setting

            getUserInfo();
        }

        function showFeedbackDialog() {
            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/feedback/new.html',
                    parent: angular.element(document.body),
                    openFrom: '.btnShowFeedbackDialog',
                    focusOnOpen: false
                });
        }

        function getUserInfo() {
            vm.userInfo = userInfo.get();

            if (vm.userInfo.$promise === undefined) {
                vm.selectedLanguage = vm.userInfo.selectedCulture;
                fuseTheming.setActiveTheme(vm.userInfo.selectedTheme);
            }
            else {
                vm.userInfo.$promise.then(function () {
                    vm.selectedLanguage = vm.userInfo.output.user.selectedCulture;
                    fuseTheming.setActiveTheme(vm.userInfo.output.user.selectedTheme);
                });
            }
        }

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

        function showSettingsDialog() {
            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/settings/index.html',
                    parent: angular.element(document.body),
                    openFrom: '.btnSettings',
                    focusOnOpen: false
                });
        }


        /**
         * Toggle sidenav
         *
         * @param sidenavId
         */
        function toggleSidenav(sidenavId) {
            $mdSidenav(sidenavId).toggle();
        }

        /**
         * Logout Function
         */
        function logout() {
            localStorage.setAccessToken(null);
            $state.transitionTo('app.auth_login', {lang: $translate.use()});
            fuseTheming.setActiveTheme('default');
        }


        /**
         * Toggle horizontal mobile menu
         */
        function toggleHorizontalMobileMenu() {
            vm.bodyEl.toggleClass('ms-navigation-horizontal-mobile-menu-active');
        }

        /**
         * Toggle msNavigation folded
         */
        function toggleMsNavigationFolded() {
            msNavigationService.toggleFolded();
        }

        /**
         * Search action
         *
         * @param query
         * @returns {Promise}
         */
        function search(query) {
            var navigation = [],
                flatNavigation = msNavigationService.getFlatNavigation(),
                deferred = $q.defer();

            // Iterate through the navigation array and
            // make sure it doesn't have any groups or
            // none ui-sref items
            for (var x = 0; x < flatNavigation.length; x++) {
                if (flatNavigation[x].uisref) {
                    navigation.push(flatNavigation[x]);
                }
            }

            // If there is a query, filter the navigation;
            // otherwise we will return the entire navigation
            // list. Not exactly a good thing to do but it's
            // for demo purposes.
            if (query) {
                navigation = navigation.filter(function (item) {
                    if (angular.lowercase(item.title).search(angular.lowercase(query)) > -1) {
                        return true;
                    }
                });
            }

            // Fake service delay
            $timeout(function () {
                deferred.resolve(navigation);
            }, 1000);

            return deferred.promise;
        }

        /**
         * Search result click action
         *
         * @param item
         */
        function searchResultClick(item) {
            // If item has a link
            if (item.uisref) {
                // If there are state params,
                // use them...
                if (item.stateParams) {
                    $state.go(item.state, item.stateParams);
                }
                else {
                    $state.go(item.state);
                }
            }
        }
    }

})();