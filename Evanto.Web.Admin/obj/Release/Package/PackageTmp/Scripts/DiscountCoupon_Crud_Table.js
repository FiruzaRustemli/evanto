$(function () {
    altair_crud_table.init();
}), altair_crud_table = {
    init: function () {
        var cachedCouponTypeOptions = null;
        var cachedDiscountTypeOptions = null;
        var cachedStatusOptions = null;
        $("#DiscountCoupon_crud")
            .jtable({
                title: "The DiscountCoupon List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                addRecordButton: $("#recordAdd"),
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete DiscountCoupon : " + t.record.Name + "?";
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
                                                        });
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
                                        function () {
                                            t.parent("div.icheckbox_md").next("span").text("Active");
                                        })
                                        .on("ifUnchecked",
                                        function () {
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
                                url: 'DiscountCoupon/DiscountCouponList?jtStartIndex=' + jtParams.jtStartIndex + '&jtPageSize=' + jtParams.jtPageSize,
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
                    createAction: function (postData) {
                        return $.Deferred(function ($dfd) {
                            $.ajax({
                                url: 'DiscountCoupon/CreateDiscountCoupon',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {
                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> Discount Coupon added succesfuly";
                                        var status = "success";
                                        var pos = "top-right";
                                        showNotification(message, status, pos);
                                    }

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
                    updateAction: function (postData) {
                        return $.Deferred(function ($dfd) {
                            console.log(postData);
                            $.ajax({
                                url: 'DiscountCoupon/UpdateDiscountCoupon',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {

                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> Discount Coupon Updated succesfuly";
                                        var status = "success";
                                        var pos = "top-right";
                                        showNotification(message, status, pos);
                                    }

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

                    //deleteAction: function (postData) {
                    //    console.log(postData);
                    //    return $.Deferred(function ($dfd) {
                    //        $.ajax({
                    //            url: 'DiscountCoupon/DeleteDiscountCoupon',
                    //            type: 'post',
                    //            dataType: 'json',
                    //            data: postData,
                    //            success: function (data) {
                    //                $dfd.resolve(data);
                    //                var message =
                    //                    "<a href='#' class='notify-action'>Clear</a> Discount Coupon Deleted succesfuly";
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
                        create: false,
                        edit: false,
                        list: false
                    },

                    CouponTypeId: {
                        title: 'Coupon Type',
                        width: '12%',
                        options: function () {

                            if (cachedCouponTypeOptions) { //Check for cache
                                return cachedCouponTypeOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'DiscountCoupon/GetCouponTypeOptions',
                                type: 'POST',
                                dataType: 'json',
                                async: false,
                                success: function (data) {
                                    if (data.Result !== 'OK') {
                                        return;
                                    }
                                    options = data.Options;
                                }
                            });

                            return cachedCouponTypeOptions = options; //Cache results and return options
                        }
                    },

                    DiscountTypeId: {
                        title: 'Discount Type',
                        width: '12%',
                        options: function () {

                            if (cachedDiscountTypeOptions) { //Check for cache
                                return cachedDiscountTypeOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'DiscountCoupon/GetDiscountTypeOptions',
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

                            return cachedDiscountTypeOptions = options; //Cache results and return options
                        }
                    },

                    Quantity: {
                        title: "Value",
                        inputClass: 'validate[required,custom[integer]] '
                    },
                    CouponNumber: {
                        title: "Coupon Number",
                        inputClass: 'validate[required]'
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
                                url: 'DiscountCoupon/GetStatusOptions',
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

                    CreatedTime: {
                        title: 'Created date',
                        create: false,
                        edit: false,
                        width: '15%',
                        type: 'date',
                        displayFormat: 'yy-mm-dd'
                    }
                },
                messages:{noDataAvailable:''},
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