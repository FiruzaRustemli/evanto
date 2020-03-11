$(function () {
    altair_crud_table.init();
}), altair_crud_table = {
    init: function () {

        $("#students_crud")
            .jtable({
                title: "The Role List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                addRecordButton: $("#recordAdd"),
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete Role : " + t.record.Name + "?"
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
                                            t.val(t.prop('checked'));
                                            t.parent("div.icheckbox_md").next("span").text("Active");
                                        })
                                        .on("ifUnchecked",
                                        function (e) {
                                            t.parent("div.icheckbox_md").next("span").text("at");
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
                                url: 'Role/RoleList?jtStartIndex=' + jtParams.jtStartIndex + '&jtPageSize=' + jtParams.jtPageSize,
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
                                url: 'Role/CreateRole',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {

                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {
                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> Role added succesfuly";
                                        var status = "success";
                                        var pos = "top-right";
                                        showNotification(message, status, pos);
                                    }
                                },
                                error: function (data) {
                                    $dfd.reject(data);
                                    console.log(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a>" + data.responseJSON.Message;
                                    var status = "danger";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);
                                }
                            });
                        });
                    },
                    updateAction: function (postData, jtParams) {
                        return $.Deferred(function ($dfd) {
                            console.log(postData);
                            $.ajax({
                                url: 'Role/UpdateRole',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {
                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> Role Updated succesfuly";
                                        var status = "success";
                                        var pos = "top-right";
                                        showNotification(message, status, pos);
                                    }
                                },
                                error: function (data) {
                                    $dfd.reject();
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a>" + data.responseJSON.Message;
                                    var status = "danger";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);
                                }
                            });
                        });
                    },
                    //deleteAction: function (postData, jtParams) {
                    //    console.log(postData);
                    //    return $.Deferred(function ($dfd) {
                    //        $.ajax({
                    //            url: '/tyrebrand/DeleteTyreBrand',
                    //            type: 'post',
                    //            dataType: 'json',
                    //            data: postData,
                    //            success: function (data) {
                    //                $dfd.resolve(data);
                    //                var message =
                    //                    "<a href='#' class='notify-action'>Clear</a> Tyre Brand Deleted succesfuly";
                    //                var status = "success";
                    //                var pos = "top-right";
                    //                showNotification(message, status, pos);

                    //            },
                    //            error: function () {
                    //                $dfd.reject();
                    //                var message =
                    //                    "<a href='#' class='notify-action'>Clear</a> Failed! Something was wrong";
                    //                var status = "danger";
                    //                var pos = "top-right";
                    //                showNotification(message, status, pos);
                    //            }
                    //        });
                    //    });
                    //}
                },
                fields: {

                    Id: {
                        key: true,
                        title: "Id",
                        width: "5%",
                        type: "number",
                        edit: false,
                        create: true,
                        inputClass: 'validate[required,custom[integer]] '
                    },
                    Name: {
                        title: "Name",
                        width: "13%",
                        inputClass: 'validate[required] '
                    },
                    Description: {
                        title: "Role Description",
                        width: '20%',
                        type: "textarea"
                    },
                    Status: {
                        title: 'Status',
                        width: '12%',
                        type: 'checkbox',
                        values: { 'false': 'Passive', 'true': 'Active' },
                        defaultValue: 'true'
                    }

                },
                messages: { noDataAvailable: '' },
                //Initialize validation logic when a form is created

                //Validate form when it is being submitted
                formSubmitting: function (event, data) {

                    data.form.validationEngine({ promptPosition: "bottomLeft", scroll: false });
                    return data.form.validationEngine('validate');
                },
                //Dispose validation logic when form is closed
                formClosed: function (event, data) {
                    data.form.validationEngine('hide');
                    data.form.validationEngine('detach');
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