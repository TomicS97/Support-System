$(document).ready(function () {
    $('#Save').attr("disabled", true);
    $("#AddComment").on("click", function () {
        $("#Comment").append("<div><input class='form-control' type='text'/></div>");
            $('#Save').attr("disabled", false);
    });

    $("#Save").on("click", function (result) {
        var data = JSON.stringify({
            comment: $("#Comment input").val()
        });
        console.log(data);
        $.ajax({
            type: "POST",
            url: "/Main/CreateComment",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () { console.log("bb"); }
        });
        $('#Save').attr("disabled", true);
        $("#Add").append(`<div style="margin-right: 30%" class="form-control" >
                        <p >`+ $("#Comment input").val() +`</p></div><br />`);

        $("#Comment input").remove();
    });
});