$(function () {
    altair_crud_table.init();
}), altair_crud_table = {
    init: function () {
        var cachedTypeOptions = null;
        var cachedStatusOptions = null;
        $("#students_crud")
            .jtable({
                title: "The Rating List",
                paging: true,
                pageSize: 10,
                sorting: false,
                selecting: true, //Enable selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                multiSorting: true,
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete Rating : " + t.record.Name + "?";
                },

                //formCreated: function (t, e) {
                //    $("#Edit-Text").prop("disabled", true);
                //    e.form.find(".jtable-option-text-clickable")
                //        .each(function () {
                //            var t = $(this).prev().attr("id");
                //            $(this)
                //                .attr("data-click-target", t)
                //                .off("click")
                //                .on("click",
                //                function (t) {
                //                    t.preventDefault(), $("#" + $(this).attr("data-click-target")).iCheck("toggle");
                //                });
                //        }), e.form.find("select")
                //            .each(function () {
                //                var t = $(this);
                //                t.after('<div class="selectize_fix"></div>')
                //                    .selectize({
                //                        dropdownParent: "body",
                //                        placeholder: "Click here to select ...",
                //                        onDropdownOpen: function (t) {
                //                            t.hide()
                //                                .velocity("slideDown",
                //                                {
                //                                    begin: function () {
                //                                        t.css({
                //                                            "margin-top": "0"
                //                                        });
                //                                    },
                //                                    duration: 200,
                //                                    easing: easing_swiftOut
                //                                });
                //                        },
                //                        onDropdownClose: function (t) {
                //                            t.show()
                //                                .velocity("slideUp",
                //                                {
                //                                    complete: function () {
                //                                        t.css({
                //                                            "margin-top": ""
                //                                        });
                //                                    },
                //                                    duration: 200,
                //                                    easing: easing_swiftOut
                //                                });
                //                        }
                //                    });
                //            }), e.form.find('input[type="checkbox"],input[type="radio"]')
                //                .each(function () {
                //                    var t = $(this);
                //                    t.iCheck({
                //                        checkboxClass: "icheckbox_md",
                //                        radioClass: "iradio_md",
                //                        increaseArea: "20%"
                //                    })
                //                        .on("ifChecked",
                //                        function () {
                //                            t.val(t.prop('checked'));
                //                            t.parent("div.icheckbox_md").next("span").text("Send email");
                //                        })
                //                        .on("ifUnchecked",
                //                        function () {
                //                            t.parent("div.icheckbox_md").next("span").text("don't send");
                //                        });
                //                }), e.form.find(".jtable-input")
                //                    .children('input[type="text"],input[type="password"],textarea')
                //                    .not(".md-input")
                //                    .each(function () {
                //                        $(this).addClass("md-input"), altair_forms.textarea_autosize();
                //                    }), altair_md.inputs();
                //},
                actions: {
                    listAction: function (postData, jtParams) {
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: '/Rating/RatingList?jtStartIndex=' +jtParams.jtStartIndex +'&jtPageSize=' +jtParams.jtPageSize,
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
                    deleteAction: function (postData, jtParams) {
                        console.log(postData);
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: '/Rating/DeleteRating',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> Rating Deleted succesfuly";
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


                    Description: {
                        title: " Description",
                        type: "textarea",
                        width: "5%",
                        display: function (data) {
                            return '<b>' + data.record.Description.substring(0, 70) + ' ...</b>';
                        }
                    },
                    UserName: {
                        edit: false,
                        title: 'User Name',
                        width: '12%'
                        
                    },
                    VendorService: {
                        title: 'VendorService',
                        width: '12%'
                    },
                    Value: {
                        edit: false,
                        title: "Value"
                    }
                    //,
                    //CreatedTime: {
                    //    edit: false,
                    //    create: false,
                    //    title: 'Created date',
                    //    width: '15%',
                    //    type: 'date',
                    //    displayFormat: 'yy-mm-dd'
                    //}
                },
                messages: { noDataAvailable: '' },

                selectionChanged: function () {
                    //Get all selected rows
                    var $selectedRows = $('#students_crud').jtable('selectedRows');

                    if ($selectedRows.length > 0) {
                        //Show selected rows
                        $selectedRows.each(function () {
                            var record = $(this).data('record');
                            $('#ratingText').val(record.Description);
                            $('#myModal').modal();
                        });
                    } else {
                        //No rows selected
                    }
                },
                //rowInserted: function (event, data) {

                //},

                //formSubmitting: function (event, data) {

                //    console.log(data);
                //    debugger;


                //}

            })
            .jtable("load"), $(".ui-dialog-buttonset")
                .children("button")
                .attr("class", "")
                .addClass("md-btn md-btn-flat")
                .off("mouseenter focus"), $("#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton")
                    .addClass("md-btn-flat-primary");

    }
};