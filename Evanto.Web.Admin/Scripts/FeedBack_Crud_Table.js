$(function () {
    altair_crud_table.init();
}), altair_crud_table = {
    init: function () {
        var cachedTypeOptions = null;
        var cachedStatusOptions = null;
        $("#students_crud")
            .jtable({
                title: "The FeedBack List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                addRecordButton: $("#recordAdd"),
                deleteConfirmation: function(t) {
                    t.deleteConfirmMessage = "Are you sure to delete FeedBack : " + t.record.Name + "?";
                },

                formCreated: function(t, e) {
                    $("#Edit-Text").prop("disabled", true);
                    e.form.find(".jtable-option-text-clickable")
                        .each(function() {
                            var t = $(this).prev().attr("id");
                            $(this)
                                .attr("data-click-target", t)
                                .off("click")
                                .on("click",
                                    function(t) {
                                        t.preventDefault(), $("#" + $(this).attr("data-click-target")).iCheck("toggle");
                                    });
                        }), e.form.find("select")
                        .each(function() {
                            var t = $(this);
                            t.after('<div class="selectize_fix"></div>')
                                .selectize({
                                    dropdownParent: "body",
                                    placeholder: "Click here to select ...",
                                    onDropdownOpen: function(t) {
                                        t.hide()
                                            .velocity("slideDown",
                                            {
                                                begin: function() {
                                                    t.css({
                                                        "margin-top": "0"
                                                    });
                                                },
                                                duration: 200,
                                                easing: easing_swiftOut
                                            });
                                    },
                                    onDropdownClose: function(t) {
                                        t.show()
                                            .velocity("slideUp",
                                            {
                                                complete: function() {
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
                        .each(function() {
                            var t = $(this);
                            t.iCheck({
                                    checkboxClass: "icheckbox_md",
                                    radioClass: "iradio_md",
                                    increaseArea: "20%"
                                })
                                .on("ifChecked",
                                    function() {
                                        t.val(t.prop('checked'));
                                        t.parent("div.icheckbox_md").next("span").text("Send email");
                                    })
                                .on("ifUnchecked",
                                    function() {
                                        t.parent("div.icheckbox_md").next("span").text("don't send");
                                    });
                        }), e.form.find(".jtable-input")
                        .children('input[type="text"],input[type="password"],textarea')
                        .not(".md-input")
                        .each(function() {
                            $(this).addClass("md-input"), altair_forms.textarea_autosize();
                        }), altair_md.inputs();
                },
                actions: {
                    listAction: function(postData, jtParams) {
                        return $.Deferred(function($dfd) {
                            $.ajax({
                                url: 'FeedBack/FeedBackList?jtStartIndex=' +
                                    jtParams.jtStartIndex +
                                    '&jtPageSize=' +
                                    jtParams.jtPageSize,
                                type: 'get',
                                dataType: 'json',
                                data: postData,
                                success: function(data) {
                                    $dfd.resolve(data);
                                },
                                error: function() {
                                    $dfd.reject();
                                }
                            });
                        });
                    },
                    //createAction: function (postData) {
                    //    return $.Deferred(function ($dfd) {
                    //        $.ajax({
                    //            url: 'FeedBack/CreateFeedBack',
                    //            type: 'post',
                    //            dataType: 'json',
                    //            data: postData,
                    //            success: function (data) {
                    //                $dfd.resolve(data);
                    //                var message =
                    //                    "<a href='#' class='notify-action'>Clear</a> FeedBack added succesfuly";
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
                    //},
                    updateAction: function(postData) {
                        return $.Deferred(function($dfd) {
                            console.log(postData);
                            $.ajax({
                                url: 'FeedBack/UpdateFeedBack',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function(data) {
                                    $dfd.resolve(data);
                                    debugger;
                                    if (data.Result === "OK")
                                        if (data.Record.SendEmail === true) {
                                            $('#myModal').modal();
                                            $('#userEmail').val(data.Record.Email);
                                        }
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> FeedBack Updated succesfuly";
                                    var status = "success";
                                    var pos = "top-right";
                                    showNotification(message, status, pos);
                                },
                                error: function() {
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


                },
                fields: {
                    Id: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },


                    TypeId: {
                        edit: false,
                        title: 'Type',
                        width: '12%',
                        options: function() {

                            if (cachedTypeOptions) { //Check for cache
                                return cachedTypeOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'FeedBack/GetTypeOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function(data) {
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

                    Email: {
                        edit: false,
                        title: "Email"
                    },
                    Subject: {
                        edit: false,
                        title: "Subject"
                    },
                    Text: {
                        title: " Text",
                        type: "textarea"
                    },

                    StatusId: {
                        title: 'Status',
                        width: '12%',
                        options: function() {

                            if (cachedStatusOptions) { //Check for cache
                                return cachedStatusOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'FeedBack/GetStatusOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function(data) {
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
                    SendEmail: {
                        list: false,
                        title: 'Send Email',
                        width: '12%',
                        type: 'checkbox',
                        values: { 'false': "Don't Send", 'true': 'Send Email' },
                        defaultValue: 'true'
                    },

                    CreatedTime: {
                        edit: false,
                        title: 'Created date',
                        width: '15%',
                        type: 'date',
                        displayFormat: 'yy-mm-dd'
                    }
                },
                messages: { noDataAvailable: '' },
                formSubmitting: function (event, data) {

                    console.log(data);
                    debugger;


                }

            })
            .jtable("load"), $(".ui-dialog-buttonset")
                .children("button")
                .attr("class", "")
                .addClass("md-btn md-btn-flat")
                .off("mouseenter focus"), $("#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton")
                    .addClass("md-btn-flat-primary");

        $(".jtable-delete-command-button").css("visibility:false");
    }
};