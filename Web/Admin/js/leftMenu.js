$(document).ready(function () {
   
    var currentUrl = window.location.pathname;
    var url = window.location.search;
   
    currentUrl = currentUrl.replace("/Admin/", "");
    currentUrl = currentUrl.replace("Modify.aspx", "List.aspx").replace("Assign.aspx", "List.aspx");
    $(".content").hide();
    
    $("#leftMenu a[href*=" + currentUrl + "]").addClass("hover").parents("div.content").prev().next().slideDown();
    $(".type").click(function () {
        $(".content").hide();
        $(this).next().slideDown();
    });


});