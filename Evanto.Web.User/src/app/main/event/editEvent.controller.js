(function () {
    'use strict';

    //#region Module
    angular
        .module('app.event')
        .controller('EditEventController', editEventController);
    //#endregion

    //#region Dependencies
    editEventController.$inject =
        [
            // Angular components
            '$scope',
            '$window',
            '$rootScope',

            // 3rd Party Components
            '$stateParams',
            '$state',
            '$mdDialog',
            '$filter',
            '$translate',

            // Custom components
            'eventResourceService',
            'vendorServicesService',
            'userServiceResourceService',
            'translationService',
            'userServiceModel',
            'serviceService',
            'serviceEventService',
            'userServiceBudgetService',
            'encodingHelper',
            'bookingResourceService',
            'vendorServiceResourceService',
            'topVendorServices',
            'bookings',
            'appSettings'
        ];
    //#endregion

    //#region Function
    function editEventController
        (
        $scope,
        $window,
        $rootScope,
        $stateParams,
        $state,
        $mdDialog,
        $filter,
        $translate,
        eventResourceService,
        vendorServicesService,
        userServiceResourceService,
        translationService,
        userServiceModel,
        serviceService,
        serviceEventService,
        userServiceBudgetService,
        encodingHelper,
        bookingResourceService,
        vendorServiceResourceService,
        topVendorServices,
        bookings,
        appSettings
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.event = {};
        vm.eventId = null;

        vm.bookings = [];
        vm.topVendorServices = [];

        vm.gotoVendorServicePage = gotoVendorServicePage;
        vm.showBookingInfoDialog = showBookingInfoDialog;

        /* 
        vm.userServiceModel = userServiceModel;
        vm.searchText = null;
        vm.selectedItem = null;

       vm.services = getAllEventServices();
        vm.unusedUserServices = [];
        vm.usedUserServices = [];
        vm.allUserServices = [];
        vm.allAvailableEventServices = []
        vm.isAvailableServicesShowing = true;

        vm.newUserService = {};
        vm.removingUserService = {};

        vm.removeUserService = removeUserService;
        vm.addUserService = addUserService;
        vm.querySearch = querySearch;
        vm.getAllAvailableEventServices = getAllAvailableEventServices;

        vm.isReturnButtonEnabled = false;*/


        // $scope.$watch(function () { return userServiceBudgetService.get() }, function (newVal, oldVal) {
        //     if (oldVal !== newVal && angular.isDefined(newVal)) {
        //         vm.assignedBudget = newVal;

        //         addUserServiceToEvent();
        //     }
        // });

        /* $rootScope.$on('userServiceUsed', function () {
             if (vm.eventId.length === 0) {
                 $state.transitionTo('app.events');
                 return;
             }
             updateUsedUserServices(vm.eventId);
         });
 */
        activate();

        function activate() {
            getEventId($stateParams.id)

            // getAllAvailableEventServices();
        }

        /*   function updateUsedUserServices(id)
           {
               userServiceResourceService.resource().get({ userEventId: id }, function (response) {
                   var data = response.output;
                   vm.unusedUserServices = data.userServices;
                   vm.usedUserServices = data.usedUserServices;
               });
           }*/

        function getEventId(id) {
            vm.eventId = encodingHelper.decode(id)[0];
            if (vm.eventId === undefined || vm.eventId.length === 0) {
                $state.transitionTo('app.events');
                return;
            }
            getEvent(vm.eventId);
            getBookings(vm.eventId);
            getTopVendorServices();
        }

        /*   function removeUserService(id, serviceId) {
               if (angular.isDefined(id) && angular.isDefined(serviceId)) {
                   updateUserService(id, serviceId);
               }
           };
   
           // Search for services.
           function querySearch(query) {
               var results = query ? vm.services.$$state.value.filter(createFilterFor(query)) : [];
               return results;
           }*/

        /**
    * Create filter function for a query string
    */
        /* function createFilterFor(query) {
             var lowercaseQuery = angular.lowercase(query);
 
             return function filterFn(service) {
                 return (service._lowername.indexOf(lowercaseQuery) === 0);
             }
 
         }
 
         function updateUserService(userService, serviceId) {
             //Checking here if user service created now or was created before
 
             if (userService.serviceId === undefined) {
                 userServiceResourceService.resource().get({ 'serviceId': userService.id }, function (response) {
                     vm.removingUserService.id = response.output.userServices[0]["id"]
 
                     vm.removingUserService.serviceId = serviceId;
                     vm.removingUserService.userEventId = vm.event.id;
                     vm.removingUserService.budget = vm.event.budget;
                     vm.removingUserService.status = false;
 
 
                     userServiceResourceService.resource().update(vm.removingUserService, function () {
                         $scope.$broadcast('userServicesEdited', {
                             isRemovingOperation: true,
                             removingServiceId: serviceId
                         });
                     });
                 });
             }
             else {
                 vm.removingUserService.id = userService.id;
 
                 vm.removingUserService.serviceId = serviceId;
                 vm.removingUserService.userEventId = vm.event.id;
                 vm.removingUserService.budget = vm.event.budget;
                 vm.removingUserService.status = false;
 
 
                 userServiceResourceService.resource().update(vm.removingUserService, function () {
                     $scope.$broadcast('userServicesEdited', {
                         isRemovingOperation: true,
                         removingServiceId: serviceId
                     });
                 });
             }
         }
 */
        /* function addUserService(id, serviceName) {
             // if (vm.event.budget) {
             //     $mdDialog
             //         .show({
             //             scope: $scope,
             //             preserveScope: true,
             //             templateUrl: 'app/main/service/userServiceBudget.html',
             //             parent: angular.element(document.body)
             //         });
             // }
 
             if (angular.isDefined(id)) {
                 vm.newUserService = {};
                 vm.newUserService.serviceId = id;
                 vm.newUserService.userEventId = vm.event.id;
                 vm.newUserService.budget = vm.event.budget;
 
                 userServiceResourceService.resource().save(vm.newUserService, function (response) {
                     vm.unusedUserServices[vm.unusedUserServices.length - 1].service = {
                         id: id
                     };
                     vm.newUserService.id = response.output.userService.id;
                     vm.newUserService.service = {};
                     vm.newUserService.service = {
                         id: id,
                         name: serviceName
                     };
 
                     $scope.$broadcast('userServicesEdited', {
                         isRemovingOperation: false,
                         addingService: vm.newUserService
                     });
                 }, function(){
                     vm.unusedUserServices.pop();
                 });
             }
         };*/

        function getEvent(id) {
            eventResourceService.resource().get({ id: id }, function (response) {
                vm.event = response.output.userEvents[0];

                if (vm.event === undefined) {
                    $state.transitionTo('app.events');
                    return;
                }

                vm.title = vm.event.name;

                /*     serviceEventService.set(vm.event);*/

                /*  getAllUserServices(id);*/


            });
        }

        function getBookings() {
            vm.bookings = bookings.output.bookings;

            angular.forEach(vm.bookings, function (value, index) {
                value.vendorService.photo = value.vendorService.photo != null ? appSettings.base64Prefix + value.vendorService.photo : '/assets/images/etc/no_vendor_service_image.png';
            });
        }

        function getTopVendorServices() {
            vm.topVendorServices = topVendorServices.output.vendorServices;

            angular.forEach(vm.topVendorServices, function (value, index) {
                value.photo = value.photo != null ? appSettings.base64Prefix + value.photo : '/assets/images/etc/no_vendor_service_image.png';
            });
        }

        function gotoVendorServicePage(vendorService) {
            $window.open('/' + $translate.use() + '/marketplace/' + vendorService.name + '-' + encodingHelper.encode(vendorService.id), '_blank');
        }

        function showBookingInfoDialog(booking) {
            $mdDialog
                .show({
                    locals: { bookingInfo: booking },
                    preserveScope: true,
                    templateUrl: 'app/main/booking/infoDialog.html',
                    parent: angular.element(document.body),
                    controller: 'BookingInfoDialogController',
                    controllerAs: 'vm'
                });
        }




        /*   function getAllUserServices(id) {
               userServiceResourceService.resource().get({ userEventId: id }, function (response) {
   
                   var data = response.output;
                   vm.unusedUserServices = data.userServices;
                   vm.usedUserServices = data.usedUserServices;
   
                   vm.allUserServices = (vm.unusedUserServices.slice().reverse()).concat(vm.usedUserServices.slice().reverse());
                   goToServicesState(vm.allUserServices);
               });
           }
   */
        /* function goToServicesState(userServices) {
             $state.transitionTo('app.event.services', {
                 'id': encodingHelper.encode(vm.eventId),
                 'userServices': userServices
             });
         }*/

        /*   function getAllEventServices() {
               return serviceService.getData().then(function (response) {
                   var services = response.data.output.services;
                   return services.map(function (serv) {
                       // var pascalcaseName = $filter('pascalcase')(serv.name);
                       //var translated = $filter('translate')(pascalcaseName);
                       serv._lowername = serv.name.toLowerCase();
                       return serv;
                   });
               });
           }*/

        /* function getAllAvailableEventServices() {
             vm.isAvailableServicesShowing = !vm.isAvailableServicesShowing
             if (vm.allAvailableEventServices === undefined || vm.allAvailableEventServices == 0) {
                 return serviceService.getData().then(function (response) {
                     vm.allAvailableEventServices = response.data.output.services;
                 });
             }
         };*/

    }
    //#endregion 
})();



