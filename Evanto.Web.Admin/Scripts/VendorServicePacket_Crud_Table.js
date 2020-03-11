$(function () {
    altair_crud_table.init();
}), altair_crud_table = {
    init: function () {
        var cachedVendorOptions = null;
        var cachedDiscountCouponOptions = null;
        var cachedStatusOptions = null;
        $("#VendorServicePacket_crud")
            .jtable({
                title: "The VendorServicePacket List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                openChildAsAccordion: true,
                addRecordButton: $("#recordAdd"),
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete VendorServicePacket : " + t.record.Name + "?";
                },
                formCreated: function (t, e) {
                    e.form.find(".jtable-option-text-clickable")
                        .each(function () {
                            var t = $(this).prev().attr("id");
                            $(this)
                                .attr("data-click-target", t)
                                .off("click")
                                .on("click",
                                    function(t) {
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
                                        t.val(t.prop('checked'));
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
                                url: 'VendorServicePacket/VendorServicePacketList?jtStartIndex=' + jtParams.jtStartIndex + '&jtPageSize=' + jtParams.jtPageSize,
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
                                url: 'VendorServicePacket/CreateVendorServicePacket',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a> Vendor Service Packet added succesfuly";
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
                    updateAction: function (postData) {
                        return $.Deferred(function ($dfd) {
                            console.log(postData);
                            $.ajax({
                                url: 'VendorServicePacket/UpdateVendorServicePacket',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    debugger;
                                    console.log(data);
                                    $dfd.resolve(data);
                                    var message =
                                        "<a href='#' class='notify-action'>Clear</a>Vendor Service Packet Updated succesfuly";
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
                    //deleteAction: function (postData) {
                    //    console.log(postData);
                    //    return $.Deferred(function ($dfd) {
                    //        $.ajax({
                    //            url: 'VendorServicePacket/DeleteVendorServicePacket',
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
                    Exams: {
                        title: '',
                        width: '5%',
                        sorting: false,
                        edit: false,
                        create: false,
                        display: function (ServicePacketData) {
                            //Create an image that will be used to open child table
                            var $img = $('<img src="/Content/assets/img/list_metro.png" title="Edit exam results" />');
                            //Open child table when user clicks the image
                            $img.click(function () {
                                if ($(this).hasClass('closeChild')) {
                                    $('#VendorServicePacket_crud').jtable('closeChildTable', $img.closest('tr'));
                                    $(this).removeClass('closeChild'); // we remove the class after closing child.
                                }
                                else {
                                    $(this).addClass('closeChild');
                                    $('#VendorServicePacket_crud').jtable('openChildTable',
                                        $img.closest('tr'), //Parent row
                                        {
                                            title: ServicePacketData.record.VendorId + ' - Vendor services',
                                            actions: {
                                                listAction:
                                                function (postData) {
                                                    return $.Deferred(function ($dfd) {
                                                        $.ajax({
                                                            url: 'VendorServicePacket/GetVendorServiceOptions?VendorServicePacketId=' + ServicePacketData.record.Id,
                                                            type: 'post',
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
                                                }
                                            },
                                            fields: {
                                                Id: {
                                                    type: 'hidden',
                                                    defaultValue: ServicePacketData.record.Id
                                                },
                                                StudentExamId: {
                                                    key: true,
                                                    create: false,
                                                    edit: false,
                                                    list: false
                                                },
                                                Name: {
                                                    title: 'Service name',
                                                    width: '40%'
                                                },
                                                CreatedDate: {
                                                    title: 'Created date',
                                                    width: '30%',
                                                    type: 'date'
                                                }

                                            }
                                        }, function (data) { //opened handler
                                            data.childTable.jtable('load');
                                        });
                                }
                                
                            });
                            //Return image to show on the person row
                            return $img;
                        }
                    },
                    DiscountCouponId: {
                        title: 'DiscountCoupon',
                        width: '12%',
                        create: false,
                        edit:false,
                        options: function () {

                            if (cachedDiscountCouponOptions) { //Check for cache
                                return cachedDiscountCouponOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'VendorServicePacket/GetDiscountCouponOptions',
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

                            return cachedDiscountCouponOptions = options; //Cache results and return options
                        }
                    },

                    VendorId: {
                        title: 'Vendor',
                        width: '12%',
                        create: false,
                        edit:false,
                        options: function () {

                            if (cachedVendorOptions) { //Check for cache
                                return cachedVendorOptions;
                            }

                            var options = [];

                            $.ajax({ //Not found in cache, get from server
                                url: 'VendorServicePacket/GetVendorOptions',
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

                            return cachedVendorOptions = options; //Cache results and return options
                        }
                    },

                    ActivationDate: {
                        title: "ActivationDate",
                        type:'date',
                        create: false,
                        edit:false
                    },
                    ExpirationDay: {
                        title: "ExpirationDay",
                        type: 'text',
                        create: false,
                        edit: false
                    },
                    Amount: {
                        title: "Amount",
                        type: 'text',
                        create: false,
                        edit: false
                    },

                    Description: {
                        title: "Description"
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
                                url: 'VendorServicePacket/GetStatusOptions',
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
                    }
                },
                messages: { noDataAvailable: '' },
            })
            .jtable("load"), $(".ui-dialog-buttonset")
            .children("button")
            .attr("class", "")
            .addClass("md-btn md-btn-flat")
            .off("mouseenter focus"), $("#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton")
            .addClass("md-btn-flat-primary");
    }
};