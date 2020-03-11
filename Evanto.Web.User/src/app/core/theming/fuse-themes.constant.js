(function () {
    'use strict';

    var fuseThemes = {
        default: {
            primary: {
                name: 'fuse-paleblue',
                hues: {
                    'default': '700',
                    'hue-1': '500',
                    'hue-2': '600',
                    'hue-3': '400'
                }
            },
            accent: {
                name: 'light-blue',
                hues: {
                    'default': '600',
                    'hue-1': '400',
                    'hue-2': '700',
                    'hue-3': 'A100'
                }
            },
            warn: {
                name: 'red'
            },
            background: {
                name: 'grey',
                hues: {
                    'default': 'A100',
                    'hue-1': 'A100',
                    'hue-2': '100',
                    'hue-3': '300'
                }
            }
        },
        'pinkTheme': {
            primary: {
                name: 'blue-grey',
                hues: {
                    'default': '800',
                    'hue-1': '600',
                    'hue-2': '400',
                    'hue-3': 'A100'
                }
            },
            accent: {
                name: 'pink',
                hues: {
                    'default': '400',
                    'hue-1': '300',
                    'hue-2': '600',
                    'hue-3': 'A100'
                }
            },
            warn: {
                name: 'blue'
            },
            background: {
                name: 'grey',
                hues: {
                    'default': 'A100',
                    'hue-1': 'A100',
                    'hue-2': '100',
                    'hue-3': '300'
                }
            }
        },
        'tealTheme': {
            primary: {
                name: 'fuse-blue',
                hues: {
                    'default': '900',
                    'hue-1': '600',
                    'hue-2': '500',
                    'hue-3': 'A100'
                }
            },
            accent: {
                name: 'teal',
                hues: {
                    'default': '500',
                    'hue-1': '400',
                    'hue-2': '600',
                    'hue-3': 'A100'
                }
            },
            warn: {
                name: 'deep-orange'
            },
            background: {
                name: 'grey',
                hues: {
                    'default': 'A100',
                    'hue-1': 'A100',
                    'hue-2': '100',
                    'hue-3': '300'
                }
            }
        },
        "blueTheme":
        {
            "primary":
            { "name": "fuse-paleblue", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "light-blue", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "red", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } }
        },
        "indigoTheme": { "primary": { "name": "brown", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "indigo", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "deep-purple", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } },
        "orangeTheme": { "primary": { "name": "indigo", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "deep-orange", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "deep-purple", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } },
        "brownTheme": { "primary": { "name": "blue", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "brown", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "deep-purple", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } },
        "yellowTheme": { "primary": { "name": "teal", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "yellow", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "deep-purple", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } },
        "pinkAdditionalTheme": { "primary": { "name": "blue-grey", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "pink", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "deep-purple", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } },
        "blueGrayTheme": { "primary": { "name": "fuse-paleblue", "hues": { "default": "700", "hue-1": "500", "hue-2": "600", "hue-3": "500" } }, "accent": { "name": "grey", "hues": { "default": "800", "hue-1": "400", "hue-2": "700", "hue-3": "A100" } }, "warn": { "name": "brown", "hues": { "default": "500", "hue-1": "300", "hue-2": "700", "hue-3": "A100" } }, "background": { "name": "grey", "hues": { "default": "A100", "hue-1": "A100", "hue-2": "100", "hue-3": "300" } } }
    };

    angular
        .module('app.core')
        .constant('fuseThemes', fuseThemes);
})();