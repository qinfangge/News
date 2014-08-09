$(document).ready(function () {
    $("#checkAll").click(function () {
        if ($(this).attr("checked")) {
            $(this).parents("table").find(":checkbox").attr("checked", "checked");
        } else {
            $(this).parents("table").find(":checkbox").attr("checked", "");
        }
    });
});