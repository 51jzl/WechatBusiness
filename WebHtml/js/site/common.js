

function openDialog(name, url,id) {
    var $content = $("<div class='dialog'><div class='dialogContent bg-white'>" +
        "<div class='dialog_head p-xs bg-muted h4'>" + name + "<i class='fa fa-times pull-right m-r-xs m-t-xxs' aria-hidden='true' onclick='closeThisDialog(this)'></i></div>" +
        "<div class='dialog_body p-xs'></div>" +
        "</div></div>");
    $("#wrapper").append($content);
    loadContentPath(url,id);
}
function loadContentPath(url, id) {
    $.cookie("dataId",id);
    $(".dialog_body").load(url+"?dataId="+id, function (response, status, xhr) {
        $(".dialog_body").html(response);
    });
}
function closeThisDialog(elem) {
    $(elem).parent('.dialog_head').parent('.dialogContent').parent('.dialog').remove();
}

function catchError(elem) {
    $("#error_" + elem).show();
}
function catchSuccess(elem) {
    $("#error_" + elem).hide();
}

function initProjectVeiw() {
    var url = window.location.href.split("#")[1];
    url != null || undefined ? $("#wrapper-content").load(url.split("=")[1] + ".html") : $("#wrapper-content").load("/account/create.html");
}
