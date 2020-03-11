/// <binding AfterBuild='resx2json' />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-resx2json-2');

    grunt.initConfig({
        resx2json: {
            1: {
                src: ['Resource/Register/RegisterResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'Translations/register/registerResource.az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            2: {
                src: ['Resource/Register/RegisterResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'Translations/register/registerResource.en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            3: {
                src: ['Resource/Register/RegisterResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'Translations/register/registerResource.ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            4: {
                src: ['Resource/Home/HomeResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/home/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            5: {
                src: ['Resource/Home/HomeResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/home/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            6: {
                src: ['Resource/Home/HomeResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/home/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            7: {
                src: ['Resource/Booking/BookingResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/booking/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            8: {
                src: ['Resource/Booking/BookingResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/booking/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            9: {
                src: ['Resource/Booking/BookingResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/booking/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            10: {
                src: ['Resource/Layout/LayoutResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/layout/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            11: {
                src: ['Resource/Layout/LayoutResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/layout/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            12: {
                src: ['Resource/Layout/LayoutResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/layout/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            13: {
                src: ['Resource/Toast/ToastResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/toast/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            14: {
                src: ['Resource/Toast/ToastResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/toast/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            15: {
                src: ['Resource/Toast/ToastResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/toast/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            16: {
                src: ['Resource/Profile/ProfileResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/user/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            17: {
                src: ['Resource/Profile/ProfileResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/user/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            18: {
                src: ['Resource/Profile/ProfileResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/user/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            19: {
                src: ['Resource/Event/EventResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/event/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            20: {
                src: ['Resource/Event/EventResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/event/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            21: {
                src: ['Resource/Event/EventResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/event/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            22: {
                src: ['Resource/Service/ServiceResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/service/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            23: {
                src: ['Resource/Service/ServiceResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/service/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            24: {
                src: ['Resource/Service/ServiceResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/service/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            25: {
                src: ['Resource/Feedback/FeedbackResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/feedback/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            26: {
                src: ['Resource/Feedback/FeedbackResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/feedback/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            27: {
                src: ['Resource/Feedback/FeedbackResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/feedback/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            28: {
                src: ['Resource/Authentication/AuthenticationResource.az.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/auth/i18n/az',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            29: {
                src: ['Resource/Authentication/AuthenticationResource.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/auth/i18n/en',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            30: {
                src: ['Resource/Authentication/AuthenticationResource.ru.resx'],
                options: {
                    ext: '.json',
                    dest: 'src/app/main/auth/i18n/ru',
                    prefix: '',
                    defaultLocale: ''
                }
            },
            31: {
              src: ['Resource/Marketplace/MarketplaceResource.az.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/public/i18n/az',
                prefix: '',
                defaultLocale: ''
              }
            },
            32: {
              src: ['Resource/Marketplace/MarketplaceResource.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/public/i18n/en',
                prefix: '',
                defaultLocale: ''
              }
            },
            33: {
              src: ['Resource/Marketplace/MarketplaceResource.ru.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/public/i18n/ru',
                prefix: '',
                defaultLocale: ''
              }
            },
            34: {
              src: ['Resource/Vendor/VendorResource.az.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/vendor/i18n/az',
                prefix: '',
                defaultLocale: ''
              }
            },
            35: {
              src: ['Resource/Vendor/VendorResource.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/vendor/i18n/en',
                prefix: '',
                defaultLocale: ''
              }
            },
            36: {
              src: ['Resource/Vendor/VendorResource.ru.resx'],
              options: {
                ext: '.json',
                dest: 'src/app/main/vendor/i18n/ru',
                prefix: '',
                defaultLocale: ''
              }
            }
        }

    });
};