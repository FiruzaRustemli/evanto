(function () {
    'use strict';

    //#region Module
    angular
        .module('app.user')
        .controller('UserProfileController', userProfileController);
    //#endregion

    //#region Dependencies
    userProfileController.$inject =
        [
            // Angular components
            '$scope',
            '$rootScope',
            '$filter',

            // 3rd Party Components
            '$resource',
            '$mdDialog',

            // Custom components
            'userResourceService',
            'fileUploaderService',
            'navbarHelper',
            'messageService',
            'userInfo',
            'appSettings'
        ];
    //#endregion

    //#region Function
    function userProfileController
        (
        $scope,
        $rootScope,
        $filter,
        $resource,
        $mdDialog,
        userResourceService,
        fileUploaderService,
        navbarHelper,
        messageService,
        userInfo,
        appSettings
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.appSettings = appSettings;
        vm.userGeneralInfo = {};
        vm.userAdditionalInfo = {};
        vm.verificationInfo = {}
        vm.profileImages = [];
        vm.profileImage = {};
        vm.userProfileImage = "";
        vm.userInfo = userInfo.get();
        vm.changePasswordModel = {};

        vm.imageNotUploaded = false;
        vm.imageLoaded = imageLoaded;
        vm.updateProfilePicture = updateProfilePicture;
        vm.updateUserAdditionalInfo = updateUserAdditionalInfo;
        vm.updateUserGeneralInfo = updateUserGeneralInfo;
        vm.changePassword = changePassword;
        vm.verifyAccount = verifyAccount;

        $rootScope.$on("userInfoUpdated", function(){
            getUserInfo();
        });

        activate();

        function activate() {
            setNavbarItem('none');
            getUserInfo();
        }

        function getUserInfo() {

            userResourceService.resource().get(function (response) {
                var user = response.output.user;
                vm.userGeneralInfo.firstName = user.firstName;
                vm.userGeneralInfo.lastName = user.lastName;
                vm.userGeneralInfo.userName = user.username;
                vm.userGeneralInfo.phone = user.phone;

                vm.verificationInfo.phoneVerified = user.phoneVerified;
                vm.verificationInfo.emailVerified = user.emailVerified;

                vm.userAdditionalInfo.birthday = new Date(user.birthday);
                vm.userAdditionalInfo.maritalStatus = user.maritalStatus;
                vm.userAdditionalInfo.gender = user.gender;
                vm.userAdditionalInfo.genderId = user.genderId;

                if (user.image === null || user.image === '') {
                    vm.userProfileImage = '/assets/images/etc/no_profile_image.png';
                }
                else {
                    vm.userProfileImage = appSettings.base64Prefix + user.image;
                }
            });
        }

        // Sets navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function imageLoaded() {
            vm.profileImageLoaded = true;
        }

        function updateProfilePicture() {
            angular.forEach(vm.profileImages, function (obj) {
                if (!obj.isRemote) {
                    var reader = new FileReader();
                    reader.readAsBinaryString(obj.lfFile);
                    reader.onload = function (fileLoaded) {
                        vm.profileImage.mediaType = obj.lfFile.type;
                        vm.profileImage.extension = obj.lfFile.name.split('.').pop().split(/\#|\?/)[0];;

                        var binaryString = fileLoaded.target.result;
                        vm.profileImage.container = btoa(binaryString);

                        fileUploaderService.uploadUserProfileImage(vm.profileImage).then(function (response) {
                            vm.profileImages = [];
                            vm.userProfileImage = "data:image/png;base64, " + response.data.output.container;
                            messageService.success($filter('translate')('Toast.Success.ProfilePictureChanged'))
                        }, function (err) {
                            vm.profileImages = [];
                        });
                    };
                    reader.onerror = function (error) {
                        vm.profileImages = [];
                        messageService.systemError($filter('translate')('Toast.Error.SystemError'));
                    };
                }
            });
        }

        function updateUserGeneralInfo() {
            userResourceService.resource().updateGeneralInfo(vm.userGeneralInfo).$promise.then(function (response) {
                vm.user = response.output.user;
                messageService.success($filter('translate')('Toast.Success.ProfileInfoUpdated'))
            });
        }

        function updateUserAdditionalInfo() {
            userResourceService.resource().updateAdditionalInfo(vm.userAdditionalInfo).$promise.then(function (response) {
                vm.user = response.output.user;
                messageService.success($filter('translate')('Toast.Success.ProfileInfoUpdated'))
            });
        }

        function changePassword() {
            if (vm.changePasswordModel.newPassword === vm.changePasswordModel.confirmPassword) {
                userResourceService.resource().changePassword(vm.changePasswordModel).$promise.then(function (response) {
                    vm.user = response.output.user;
                    messageService.success($filter('translate')('Toast.Success.PasswordChanged'))
                });
            }
        }

        function verifyAccount(verificationType, relationalData, e) {
            $scope.verificationType = verificationType;
            $scope.relationalData = relationalData;
            $scope.userName =  vm.userGeneralInfo.userName;

            $mdDialog
                  .show({
                      scope: $scope,
                      preserveScope: true,
                      templateUrl: 'app/main/user/verificationDialog.html',
                      parent: angular.element(document.body),
                      openFrom: '#' + e.currentTarget.id,
                      focusOnOpen: false
                  });
        }
    }
    //#endregion 
})();


