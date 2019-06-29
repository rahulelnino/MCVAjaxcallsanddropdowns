$(document).ready(function () {
    $("#RoomNos").on("change", function () {
        var value = $(this).val();
        $.ajax({
            url: '/Room/getRoomType',
            //url: '@Url.Action("getRoomType","Room")',
            type: 'GET',
            data: { id: value },
            datatype: 'json',
            success: function (res) {
                $("#RoomType").val(res);
            },
            error: function (err) {
                alert(err);
            }
        });
        
    });
});