(function () {
    'use strict';

    /**
     * Main module of the Fuse
     */
    angular
        .module('evantoApp', [

            // Core
            'app.core',

            // Navigation
            'app.navigation',

            // Toolbar
            'app.toolbar',

            // Quick Panel
            'app.quick-panel',

            // Public vendorservices (Can be accessed without login)
            'app.public.marketplace',

            'evantoApp.core',
            'evantoApp.services',
            'evantoApp.decorators',
            'evantoApp.filters',
            'evantoApp.directives',

            // My apps
            'app.user',
            // 'app.home',
            'app.booking',
            'app.event',
            'app.event',
            'app.service',
            'app.vendor',
            'app.settings',
            'app.feedback',
            'app.auth.login',
            'app.auth.register',
            'app.auth.forgotPassword',
            'app.notification'
        ]);
})();