$(function () {
    altair_crud_table.init()
}), altair_crud_table = {
    init: function () {
        var cachedRoleOptions = null;
        var cachedTypeOptions = null;
        var cachedStatusOptions = null;
        $("#User_crud")
            .jtable({
                title: "The User List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete User : " + t.record.Name + "?";
                },
                formCreated: function (t, e) {
                    e.form.find(".jtable-option-text-clickable")
                        .each(function () {
                            var t = $(this).prev().attr("id");
                            $(this)
                                .attr("data-click-target", t)
                                .off("click")
                                .on("click",
                                    function (t) {
                                        t.preventDefault(), $("#" + $(this).attr("data-click-target")).iCheck("toggle");
                                    });
                        }), e.form.find("select")
                        .each(function () {
                            var t = $(this);
                            t.after('<div class="selectize_fix"></div>')
                                .selectize({
                                    dropdownParent: "body",
                                    placeholder: "Click here to select ...",
                                    onDropdownOpen: function (t) {
                                        t.hide()
                                            .velocity("slideDown",
                                            {
                                                begin: function () {
                                                    t.css({
                                                        "margin-top": "0"
                                                    })
                                                },
                                                duration: 200,
                                                easing: easing_swiftOut
                                            });
                                    },
                                    onDropdownClose: function (t) {
                                        t.show()
                                            .velocity("slideUp",
                                            {
                                                complete: function () {
                                                    t.css({
                                                        "margin-top": ""
                                                    });
                                                },
                                                duration: 200,
                                                easing: easing_swiftOut
                                            });
                                    }
                                });
                        }), e.form.find('input[type="checkbox"],input[type="radio"]')
                        .each(function () {
                            var t = $(this);
                            t.iCheck({
                                checkboxClass: "icheckbox_md",
                                radioClass: "iradio_md",
                                increaseArea: "20%"
                            })
                                .on("ifChecked",
                                    function (e) {
                                        t.parent("div.icheckbox_md").next("span").text("Active");
                                    })
                                .on("ifUnchecked",
                                    function (e) {
                                        t.parent("div.icheckbox_md").next("span").text("Passive");
                                    });
                        }), e.form.find(".jtable-input")
                        .children('input[type="text"],input[type="password"],textarea')
                        .not(".md-input")
                        .each(function () {
                            $(this).addClass("md-input"), altair_forms.textarea_autosize();
                        }), altair_md.inputs();
                },
                actions: {
                    listAction: function (postData, jtParams) {
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: 'User/Userlist?jtStartIndex=' +
                                    jtParams.jtStartIndex +
                                    '&jtPageSize=' +
                                    jtParams.jtPageSize,
                                type: 'get',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                },
                                error: function () {
                                    $dfd.reject();

                                }
                            });
                        });
                    },
                    createAction: function (postData, jtParams) {
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: 'User/CreateUser',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> User added succesfuly";
                                    var status = "success";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);

                                },
                                error: function () {
                                    $dfd.reject();
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> Failed! Something was wrong";
                                    var status = "danger";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);
                                }
                            });
                        });
                    },
                    updateAction: function (postData, jtParams) {
                        console.log(postData);
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: 'User/UpdateUser',
                                type: 'get',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> User Updated succesfuly";
                                    var status = "success";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);

                                },
                                error: function () {
                                    $dfd.reject();
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> Failed! Something was wrong";
                                    var status = "danger";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);
                                }
                            });
                        });
                    }
                  
                },
                fields: {
                    Id: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    RegistrationDate: {
                        key: true,
                        type: 'date',
                        create: false,
                        edit: false,
                        list: false
                    },
                    RoleId: {
                        title: 'Role',
                        width: '12%',
                        options: function () {

                            if (cachedRoleOptions) { //Check for cache
                                return cachedRoleOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'User/GetRoleOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function (data) {
                                    if (data.Result !== 'OK') {
                                        alert(data.Message);
                                        return;
                                    }
                                    options = data.Options;
                                }
                            });

                            return cachedRoleOptions = options; //Cache results and return options
                        }
                    },
                    TypeId: {
                        title: 'Type',
                        width: '12%',
                        options: function () {

                            if (cachedTypeOptions) { //Check for cache
                                return cachedTypeOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'User/GetTypeOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function (data) {
                                    if (data.Result !== 'OK') {
                                        alert(data.Message);
                                        return;
                                    }
                                    options = data.Options;
                                }
                            });

                            return cachedTypeOptions = options; //Cache results and return options
                        }
                    },
                    Username: {
                        title: "UserName"
                    },
                    MaritalStatus: {
                        key: true,
                        title: "MaritalStatus",
                        create: false,
                        edit: false,
                        list: false
                    },
                    Salt: {
                        key: true,
                        title: "Salt",
                        create: false,
                        edit: false,
                        list: false
                    },
                    LoginCount: {
                        key: true,
                        title: "LoginCount",
                        create: false,
                        edit: false,
                        list: false
                    },
                    LastLoginDate: {
                        key: true,
                        title: "LastLoginDate",
                        create: false,
                        edit: false,
                        list: false,
                        type: 'date'
                    },
                    FailedLoginCount: {
                        key: true,
                        title: "FailedLoginCount",
                        create: false,
                        edit: false,
                        list: false
                    },
                    Password: {
                        key: true,
                        title: "Password",
                        create: false,
                        edit: false,
                        list: false
                    },
                    FirstName: {
                        title: "FirstName"
                    },
                    LastName: {
                        title: "LastName"
                    },
                    Phone: {
                        title: "Phone"
                    },
                    Birthday: {
                        title: 'BirthDay',
                        width: '15%',
                        type: 'date',
                        displayFormat: 'yy-mm-dd'
                    },
                    StatusId: {
                        title: 'Status',
                        width: '12%',
                        options: function () {

                            if (cachedStatusOptions) { //Check for cache
                                return cachedStatusOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'User/GetStatusOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function (data) {
                                    if (data.Result !== 'OK') {
                                        alert(data.Message);
                                        return;
                                    }
                                    options = data.Options;
                                }
                            });

                            return cachedStatusOptions = options; //Cache results and return options
                        }
                    },
                    CreatedDate: {
                        title: 'Created date',
                        width: '15%',
                        type: 'date',
                        displayFormat: 'yy-mm-dd'
                    }

                }
            })
            .jtable("load"), $(".ui-dialog-buttonset")
            .children("button")
            .attr("class", "")
            .addClass("md-btn md-btn-flat")
            .off("mouseenter focus"), $("#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton")
            .addClass("md-btn-flat-primary");
    }
};