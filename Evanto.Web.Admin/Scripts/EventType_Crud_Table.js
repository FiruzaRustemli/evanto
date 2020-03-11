$(function () {
    altair_crud_table.init()
}), altair_crud_table = {
    init: function () {
        $("#EventType_crud")
            .jtable({
                title: "The Event Type List",
                paging: true,
                pageSize: 10,
                sorting: false,
                multiSorting: true,
                //selecting: true, //Enable selecting
                //multiselect: true, //Allow multiple selecting
                //selectingCheckboxes: true, //Show checkboxes on first column
                //selectOnRowClick: false, //Enable this to only select using checkboxes
                addRecordButton: $("#recordAdd"),
                deleteConfirmation: function (t) {
                    t.deleteConfirmMessage = "Are you sure to delete Event Type : " + t.record.Name + "?"
                },
                formCreated: function (t, e) {
                    $("#Edit-Name").prop("disabled", true);
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
                                url: 'EventType/EventTypeList?jtStartIndex=' + jtParams.jtStartIndex + '&jtPageSize=' + jtParams.jtPageSize,
                                type: 'get',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    console.log(data);
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
                                url: 'EventType/CreateEventType',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {
                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> EventType added succesfuly";
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
                    updateAction: function (postData, jtParams) {
                        return $.Deferred(function ($dfd) {
                            var remember = document.getElementById('Edit-Status');
                            
                           
                            $.ajax({
                                url: 'EventType/UpdateEventType',
                                type: 'post',
                                dataType: 'json',
                                data: postData,
                                success: function (data) {
                                    $dfd.resolve(data);
                                    if (data.Result === "OK") {
                                        var message =
                                            "<a href='#' class='notify-action'>Clear</a> EventType Updated succesfuly";
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
                    
                },
                fields: {
                    
                    Id: {
                        title: "Id",
                        key: true,
                        edit: false,
                        width: "5%",
                        type: "number",
                        inputClass: 'validate[required,custom[integer]] '
                    },
                    Name: {
                        create: false,
                        title: "Resource Key",
                        width: "13%"
                    },
                    NameEn: {
                        title: "NameEn",
                        width: "13%",
                        inputClass: 'validate[required]] '
                    },

                    NameAz: {

                        title: "NameAz",
                        width: "13%",
                        inputClass: 'validate[required]] '
                    },

                    NameRu: {
                        title: "NameRu",
                        width: "13%",
                        inputClass: 'validate[required]] '
                    },
                    CreatedDate: {
                        title: 'CreatedDate',
                        width: '12%',
                        create: false,
                        edit: false,
                        type: 'date'
                    },
                    Description: {
                        title: "Description",
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
                },
                selectionChanged: function () {
                    //Get all selected rows
                    var $selectedRows = $('#EventType_crud').jtable('selectedRows');
 
                    $('#SelectedRowList').empty();
                    if ($selectedRows.length > 0) {
                        //Show selected rows
                        $selectedRows.each(function () {
                            var record = $(this).data('record');
                            $('#SelectedRowList').append(
                                '<b>StudentId</b>: ' + record.StudentId +
                                '<br /><b>Name</b>:' + record.Name + '<br /><br />'
                                );
                        });
                    } else {
                        //No rows selected
                        $('#EventType_crud').append('No row selected! Select rows to see here...');
                    }
                },
                rowInserted: function (event, data) {
                    if (data.record.Name.indexOf('Andrew') >= 0) {
                        $('#EventType_crud').jtable('selectRows', data.row);
                    }
                }
            
            })
            .jtable("load"), $(".ui-dialog-buttonset")
            .children("button")
            .attr("class", "")
            .addClass("md-btn md-btn-flat")
            .off("mouseenter focus"), $("#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton")
            .addClass("md-btn-flat-primary");

        $('#DeleteAllButton').button().click(function () {
            var $selectedRows = $('#EventType_crud').jtable('selectedRows');
            console.log($selectedRows);
            //$('#EventType_crud').jtable('deleteRows', $selectedRows);
        });
    }
};