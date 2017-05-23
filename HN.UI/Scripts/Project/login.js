
var defaultEntrance = '';

$(function () {
    loadErCode();
    showPage();
})

function loadErCode() {
    $.ajax(
        {
            url: 'erCode',
            data: {},
            success: function (data) {

            },
            error: function () {

            }
        })
}
function showPage() {
    if (defaultEntrance == 'erCode') {
        $(".erCodeLogin").show();
        $(".inputLogin").hide();
        defaultEntrance = "";
        $(".login-title").text('二维码登陆');
        $("#picture-zone i").removeClass('fa-television fa-4x').addClass('fa-qrcode fa-5x');
    } else {
        $(".erCodeLogin").hide();
        $(".inputLogin").show();
        defaultEntrance = 'erCode';
        $(".login-title").text('密码登陆');
        $("#picture-zone i").removeClass('fa-qrcode fa-5x').addClass('fa-television fa-4x');
        if (document.cookie.username != '') {
            var array = document.cookie.split(';')
            for (var i = 0; i < array.length; i++) {
                if (array[i].indexOf('username') != -1 && array[i].length > 12) {
                    $("input[name=Email]").val(array[i].slice(9));
                } else if (array[i].indexOf('password') != -1 && array[i].length > 12) {
                    $("input[name=Password]").val(array[i].slice(10));
                }
            }
            $("input[type='checkbox']").attr('checked', true);
        }
    }
}
$("#picture-zone").click(function () {
    showPage();
});
$("#loginBtn").click(function () {
    storeName();
    checkUserName();
    return false;
});
function checkUserName() {
    var phoneReg = /^1[3|5|7|8]\d{9}$/gi, emailReg = /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/;
    //var passWordReg = /^(?=.*?[a-zA-Z])(?=.*?[0-9])[a-zA-Z0-9]{6,16}$/;
    var value = $("input[name=loginName]").val(), password = $("input[name=pwd]").val();
    if (phoneReg.test(value) || emailReg.test(value)) {
        $("#passWord_error").hide();
        ajaxUserData();
        //if (passWordReg.test(password)) {
        //} else {
        //    $("#passWord_error").show();
        //}
    } else {
        //用户名出错
        $("#userName_error").show();
    }
}
function ajaxUserData() {
    debugger;
    $.ajax({
        url: '/Home/Login',
        type: 'post',
        data: $("#loginForm").serialize(),
        success: function (data) {
            if (data) {
                //判断登录成功
                if (data.State && data.State == 1)
                    window.location.href = '/Home/Default';
                else
                    layer.alert(data.Content, { icon: data.Icon });
            }
        }
    })
}
function storeName() {
    if ($('input[type="checkbox"]').is(':checked')) {
        document.cookie = "username=" + $("input[name=Email]").val();
        document.cookie = "password=" + $("input[name=Password]").val();
    } else {
        document.cookie = "username=";
        document.cookie = "password=";
    }
}
