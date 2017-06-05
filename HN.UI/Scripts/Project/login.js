
var defaultEntrance = '';
var phoneReg = /^1[3|5|7|8]\d{9}$/gi, emailReg = /^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$/;
var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;
var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
var registeType = '';//判断进来的入口

$(function () {
    showPage();
})
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
});
$(".nextStepBtn").click(function () {//下一步按钮
    registeType = window.location.search.split("=")[1];
    if (checkPhoneNum() && checkVerifyCode()) {
        $("input[name=varifyPhoneNum]").val($("input[name=phoneNum]").val());
        $(".stepTwo").animate({ "right": "0" }, 300);
    } else {
        catchError("verification")
    }
})
$("#submitForManager").click(function () {
    var manageSure = true;
    if ($("#passwordSure").val() != $("input[name=password]").val()) {
        manageSure = false;
        catchError("passwordSure");
    } else {
        catchSuccess("passwordSure");
    }
    if (checkInputValue("companyName") && checkInputValue("password") && manageSure) {
        $.ajax({
            url: "/Account/Register",//管理端接口
            type:"POST",
            data: {
                "LoginName": $("input[name=varifyPhoneNum]").val(),
                "Pwd": $("input[name=password]").val(),
                "UserName": $("input[name=companyName]").val()
            },
            success: function (data) {
                if (data.State == 1) {
                    alert(data.Content);
                } else {
                    alert(data.Content)
                }
            },
            error: function () {

            }
        })
    }
})
$("#submitAgent").click(function () {//申请代理确认
    var ifsure = true;
    if (isIDCard1.test($("input[name=idCard]").val()) || isIDCard2.test($("input[name=idCard]").val())) {
        catchSuccess("idCard");
    } else {
        ifsure = true;
        catchError("idCard");
    }
    if (emailReg.test($("input[name=emailForRegis]").val()) == false) {
        $("#error_emailForRegis").text("邮箱格式错误，请重新输入！");
        catchError("emailForRegis");
        ifsure = false;
    } else {
        catchSuccess("emailForRegis")
    }
    if (checkInputValue("personName") && checkInputValue("wechat") && checkInputValue("locationDetail")) {
        $.ajax({
            url: "userRequestAgentUrl",//申请代理接口
            data: $("#userAgentForm").serialize(),
            success: function () {

            },
            error: function () {

            }
        })
    }
});
function checkInputValue(elem) {
    console.log($("input[name=" + elem + "]"))
    if ($("input[name=" + elem + "]").val() == '') {
        catchError(elem);
        return false;
    } else {
        catchSuccess(elem);
        return true;
    }
}
function changeVerfyCode() {//图片验证码接口
    $("#verifyPic").attr("src", "/Home/VerifyCode?time=" + Math.random());
}
function getMessageVerifyCode() {//短信验证码接口
    if ($(".regetVerifyCode").text() == "重新获取验证码") {
        countNextTime();
        $.ajax({
            url: '/Verification/GetPhoneCode',
            type: "GET",
            data: { "mobile": $("input[name=varifyPhoneNum]").val() },
            success: function (data) {
                
            },
            error: function () {
                alert("出错啦！请检查网络设置！")
            }
        })
    } else {
        $("#error_register").show();
        $("#error_register").text("请不要频繁操作！")
    }

}
function countNextTime() {
    var millisec = 60;
    var time = setInterval(function () {
        if (millisec <= 0) {
            $(".regetVerifyCode ").text("重新获取验证码");
            window.clearInterval(time);
        } else {
            $(".regetVerifyCode ").text(millisec-- + "s 后重新获取");
        }
    }, 1000)

}
function toLastStep() {
    //判断手机验证码是否有误
    $.ajax({
        url: "/Verification/JudgePhoneCode",
        type: "POST",
        data: {
            'mobile': $("input[name=varifyPhoneNum]").val(),
            'code': $("input[name=phoneVerification]").val()
        },
        success: function (data) {
            if (data.State == 1) {
                catchSuccess("register");
                doTheLastStep();
            } else {
                catchError("register");
                doTheLastStep();
            }
        },
        error: function () {
            catchError("register");
        }
    })
}
function doTheLastStep() {
    //判断当前url根据url链接到最后一步
    $("#" + registeType).animate({ "right": "0px" }, 300);
    if (registeType == "customerReg") {
        $.ajax({
            url: "http://restapi.amap.com/v3/config/district?key=5fb18b633709700091f158f6dc49d239",
            success: function (data) {
                var provinceData = data.districts[0].districts;
                $("select[name=province]").empty();
                $.each(provinceData, function (index, value) {
                    $("select[name=province]").append("<option value=" + value.name + ">" + value.name + "</option>")
                });

            },
            error: function () {
                alert("error");
            }
        })
        initTownOpitons();
    }
}
function initTownOpitons() {
    var val = $("select[name=province]").val();
    $.ajax({
        url: "http://restapi.amap.com/v3/config/district?key=5fb18b633709700091f158f6dc49d239&keywords=" + val,
        async: true,
        success: function (data) {
            var provinceData = data.districts[0].districts;
            $("select[name=town]").empty();
            $.each(provinceData, function (index, value) {
                $("select[name=town]").append("<option value=" + value.name + ">" + value.name + "</option>")
            });
        }
    })
}
function checkPhoneNum() {
    //手机号码格式是否正确
    var phoneValue = $("input[name=phoneNum]").val();
    if (phoneReg.test(phoneValue)) {
        catchSuccess("phoneNum");
        return true;
    } else {
        catchError("phoneNum");
        return false;
    }
}
function checkVerifyCode() {
    var status = false;
    //验证码地址 /Verification/AuthorizationVerifyCode
    $.ajax({
        url: "/Verification/AuthorizationVerifyCode",
        type: "post",
        async:false,
        data: { "code": $("input[name=verification]").val() },
        success: function (data) {
            if (data.State == 1) {
                catchSuccess("verification");
                status = true;
            } else {
                catchError("verification")
                status = false;
            }
        },
        error: function () {
            catchError("verification");
            status = false;
        }
    })
    //验证码格式是否正确
    return status;
}
function checkUserName() {
    var value = $("input[name=loginName]").val(), password = $("input[name=pwd]").val();
    if (phoneReg.test(value) || emailReg.test(value)) {
        catchSuccess("passWord")
        ajaxUserData();
    } else {
        //用户名出错
        catchError("userName");
    }
}
function ajaxUserData() {
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
