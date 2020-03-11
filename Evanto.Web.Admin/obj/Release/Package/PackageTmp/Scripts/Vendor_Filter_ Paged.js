$(function () {
    if (Modernizr.touch) {
        var e = $(".focus-highlight");
        e.length && e.find("td, th").attr("tabindex", "1").on("touchstart", function () {
            $(this).focus()
        }), $(".tablesorter").find("th").addClass("needsclick")
    }
    altair_tablesorter.custom_filters();
}), altair_tablesorter = {

    custom_filters: function () {
        debugger;
        var z = $("#ts_custom_filters");
        n = {
            container: $(".ts_pager"),
            output: "{startRow} - {endRow} / {filteredRows} ({totalRows})",
            fixedHeight: !0,
            removeRows: !1,
            cssGoto: ".ts_gotoPage"
        };

        z.tablesorter({
            theme: "altair",
            headerTemplate: "{content} {icon}",
            widgets: ["zebra", "filter"],
            showProcessing: true,
            widgetOptions: {
                scroller_upAfterSort: false,
                // pop table header into view while scrolling up the page
                scroller_jumpToHeader: false,
                filter_reset: "button.ts_cf_reset",
                filter_cssFilter: ["ts_cf_select_single", "", "", "", "",  "ts_cf_range", "ts_cf_select_single"]
            }
        }).tablesorterPager(n).on("pagerComplete", function (e, t) {
            "undefined" != typeof selectizeObj && selectizeObj.data("selectize") && (selectizePage = selectizeObj[0].selectize, selectizePage.setValue($("select.ts_gotoPage option:selected").index() + 1, !1))
            });
        
        var t = $(".ts_cf_range").ionRangeSlider(
            {
                min: "0",
                max: "200",
                type: "double",
                "grid-num": "10",
                "from-min": "10",
                "from-max": "30",
                input_values_separator: " - "
            }).data("ionRangeSlider"),
            i = $(".ts_cf_select_single").after('<div class="selectize_fix"></div>').selectize({
                hideSelected: !0,
                dropdownParent: "body",
                closeAfterSelect: !0,
                onDropdownOpen: function (e) {
                    e.hide().velocity("slideDown", {
                        duration: 200,
                        easing: [.4, 0, .2, 1]
                    })
                },
                onDropdownClose: function (e) {
                    e.show().velocity("slideUp",
                    {
                        duration: 200,
                        easing: [.4, 0, .2, 1]
                    });
                }
            }),
            n = i[0].selectize,
            a = UIkit.modal("#modal_daterange", {
                center: !0
            });
        $(".ts_cf_datepicker").on("focus", function () {
            a.isActive() ? a.hide() : a.show()
        });
        var o = $("#ts_dp_start"),
            l = $("#ts_dp_end"),
            s = UIkit.datepicker(o, {
                format: "MMM D, YYYY"
            }),
            c = UIkit.datepicker(l, {
                format: "MMM D, YYYY"
            });
        o.on("change", function () {
            c.options.minDate = o.val()
        }), l.on("change", function () {
            s.options.maxDate = l.val()
        }), $("#daterangeApply").on("click", function (e) {
            e.preventDefault(), a.hide(), $(".ts_cf_datepicker").val(o.val() + " - " + l.val()).change().blur()
        }), $("button.ts_cf_reset").on("click", function () {
            n.clear(), t.reset()
        })
    }
};