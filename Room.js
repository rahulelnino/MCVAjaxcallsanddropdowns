$(document).ready(function () {
    $("#btncancel").click(function () {
       var url = '/Login/Index/';
        window.location.href=url;
    });
    $("#btncheckin").click(function () {
        var url = '/Room/CheckIn/';
        window.location.href = url;
    });
});

