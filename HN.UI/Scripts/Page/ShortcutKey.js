/* shortcut key event*/

//Esc关闭窗口,Ctrl+S 保存
onkeydown = function (e) {
    // 兼容FF和IE和Opera
    if (!e) e = window.event;
    var code = e.keyCode || e.which || e.charCode;
    if (code == 27) {  //Esc
        $('#topWin').window('close');
        return false;
    } else if (e.ctrlKey && code == 83) {  //Ctrl+S
        $('#btnSave').click();
        return false;
    }

};

//在弹出窗口表单中默认第一个文本框获取焦点
$.parser.onComplete = function () {
    //表单ff中文本框
    $(".easyui-form :text:visible:enabled").each(function () {
        if ($(this).attr("readonly") != "readonly") {
            $(this).focus().select();
            return false;
        }
    })
}

$(".easyui-form :text:visible").live('keydown', function (e) {
    // 兼容FF和IE和Opera
    if (!e) e = window.event;
    var code = e.keyCode || e.which || e.charCode;
    if (code == 13)  //Enter
    {
        var obj = $(".easyui-form :input:visible");
        var index = obj.index($(this));
        if (index < obj.length - 1) {
            var $next = $(obj[index + 1]);
            $next.focus().select();
            return false;
        }
    } else if (code == 8 && $(this).attr("readonly") == "readonly") {   //只读文本屏蔽backsapce
        return false;
    }
})

