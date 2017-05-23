/***public script***/

//刷新页面
function btnRefresh_OnClick() {
    location.reload()
}

//ajax
function getAjax(url, data, callBack, dtype, method) {
    var type = 'post';
    var dataType = 'text';
    if (dtype != null) dataType = dtype;
    if (method != null) type = method;
    $.ajax({
        url: url,
        type: type,
        data: data,
        dataType: dataType,
        success: callBack
    })
}

//查询数据 datagrid load or reload
function queryData(t, data) {
    $("#dg").datagrid("clearSelections"); //清除所有选择的行 设置了idField会存在缓存
    $("#dg").datagrid("clearChecked");
    $("#dg").datagrid(t == null ? 'load' : 'reload', data);
}
//删除数据
function deleteData(url, msg) {
    var _msg = "您确定要删除吗?";
    if (msg != null) {
        _msg = msg;
    }
    var row = $("#dg").datagrid("getSelected");
    if (row == null) {
        message('warning', '请选择数据！');
        return false;
    }
    var idField = row[$("#dg").datagrid("options").idField];
    message("confirm", _msg, function (r) {
        if (r) {
            getAjax(url, { id: idField }, function (data) {
                if (data == '') {
                    btnSearch_OnClick('r');
                }
                else {
                    message("error", data);
                }
            });
        }
    })
}

//新增数据
function addData(url, title, width, height, cls) {
    openTopWin(url, title, width, height, cls != null ? cls : 'icon-add');
}

//编辑数据
function editData(url, title, width, height, cls) {
    var row = $("#dg").datagrid("getSelected");
    if (row == null) {
        message('warning', '请选择数据！');
        return false;
    }
    if (!cls) {
        cls = 'icon-edit';
    }
    var idField = row[$("#dg").datagrid("options").idField];
    openTopWin(url + "/" + idField, title, width, height, cls != null ? cls : 'icon-edit');
}

//在父页面弹出提示框
function message(type, msg, callback) {
    if (type == "confirm") {
        return parent.$.messager.confirm('系统提示', msg, callback);
    } else if (type == "show") {
        parent.$.messager.show({
            title: '系统提示',
            msg: msg,
            style: {}, //加上这一句会居中显示
            timeout: 600,
            showType: 'fade',
            border: 'thin'
        });
    } else {
        parent.$.messager.alert('系统提示', msg, type);
    }
}

//在父页面弹出窗口
function openTopWin(url, title, width, height, iconCls, maximizable) {
    var _width = 800;
    var _height = 500;
    var _maximizable = false;
    if (width != null) {
        _width = width;
    }
    if (height != null) {
        _height = height;
    }
    if (maximizable != null) {
        _maximizable = maximizable;
    }
    parent.$("<div id='topWin'></div>").window({
        title: title,
        iconCls: iconCls,
        border: 'thin',
        href: url,
        modal: true,
        width: _width,
        height: _height,
        top: ($(parent.window).height() - _height) * 0.5,
        left: ($(parent.window).width() - _width) * 0.5,
        openAnimation: 'slide',
        closeAnimation: 'show',
        //closeDuration:1000,
        minimizable: false,
        maximizable: _maximizable,
        collapsible: false,
        resizable: false,
        cache: false,
        onClose: function () {
            parent.$("#topWin").window("destroy");
        }
    })
    return false;
}

//表单提交回调函数 在弹出窗体中保存数据时候调用
function submitSuccess(data) {
    if (data == '') {
        $("#topWin").window("close");
        var currTab = $('#tabs').tabs('getSelected');
        var curTabFrm = currTab.find('iframe')[0].contentWindow;
        //curTabFrm.$("#dg").datagrid("clearSelections"); //清除所有选择的行 设置了idField会存在缓存
        curTabFrm.btnSearch_OnClick('r');
    }
    else {
        message("error", data);
    }
}

//将列表中日期格式化 yyyy-MM-dd
function formateDate(value)
{
    if (value) {
        return value.substr(0, 10);
    }
    else {
        return '';
    }
}

//将列表中时间格式化 yyyy-MM-dd hh:mm:ss
function formateTime(value) {
    if (value) {
        return value.substr(0, 19).replace('T', ' ');
    }
    else {
        return '';
    }
}



