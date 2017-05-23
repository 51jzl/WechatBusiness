//Default.js
$(function () {
    //切换主题
    $("#skin").children().click(function () {
        $div = $(this);
        if ($div.attr("data-key") != null) {
            location.href = '/Home/ToggleTheme?skin=' + $div.attr("data-key");
        }
    })
    //退出登录
    $("#btnLogout").click(function () {
        $.messager.confirm('系统提示', '您确定要退出本次登录吗？', function (r) {
            if (r) {
                location.href = "/Home/Logout"
            }
        });
    })
    //打开窗口
    $("#btnChangePwd").click(function () {
        $('#win').window({
            onClose: null
        })
        $('#win').window('open');
    })
    //关闭窗口
    $("#btnCancel").click(function () {
        closed();
    })
    //提交修改
    $("#btnEp").click(function () {
        var oldPwd = $("#txtOldPass").val();
        var newPwd = $("#txtNewPass").val();
        var rePwd = $("#txtRePass").val();
        $("#errorMsg0").html("");
        $("#errorMsg1").html("");
        $("#errorMsg2").html("");
        if (oldPwd == "") {
            $("#txtOldPass").next().find("input").focus();
            $("#errorMsg0").html("请输入旧密码");
            return false;
        } else if (newPwd == "") {
            $("#txtNewPass").next().find("input").focus();
            $("#errorMsg1").html("请输入新密码");
            return false;
        } else if (rePwd == "") {
            $("#txtRePass").next().find("input").focus();
            $("#errorMsg2").html("请确认新密码");
            return false;
        } else if (newPwd != rePwd) {
            $("#txtRePass").next().find("input").focus();
            $("#errorMsg2").html("两次输入不一致");
            return false;
        }

        $.ajax({
            url: '/Home/UpdatePass',
            type: 'post',
            data: { oldPwd: oldPwd, newPwd: newPwd },
            dataType: 'text',
            success: function (data) {
                if (data != "") {
                    $("#errorMsg0").html(data);
                } else {
                    $('#win').window({
                        onClose: function () {
                            message("show", "更新成功！");
                        }
                    })
                    closed();
                }
            }
        })
    })
    //绑定左侧菜单树
    initTree();
    tabEvent();
    $('#tabs').tabs({
        tools: [{
            iconCls: 'icon-arrow_out_longer',
            handler: setFullScreen
        }]
    });
})
function initTree() {
    $.ajax({
        url: '/Home/GetMenuList',
        type: 'post',
        success: function (data) {
            var data = JSON.parse(data);
            $("#nav").accordion({ animate: true, fit: true, border: false });
            $.each(data, function (i, n) {
                var id = this.id;
                var select = i == 0 ? true : false;
                $("#nav").accordion('add', {
                    id: 'acord_' + id,
                    title: this.text,
                    selected: select,
                    iconCls: this.iconCls,
                    border: false
                });
                $("#acord_" + id).html('<ul id="tree_' + id + '" style="margin-top: 8px;padding:0px;"></ul>');
                $tree = $('#tree_' + id);
                $tree.tree({
                    url: '/Home/GetMenuList',
                    queryParams: { pid: id },
                    lines: true,
                    animate: true,
                    onClick: function (node) {
                        if ($tree.tree('isLeaf', node.target)) {//判断是子节点 添加选显卡
                            addTab(node.text, node.attributes.url, node.iconCls);
                        }
                        else {
                            $(this).tree('toggle', node.target);
                        }
                    },
                    onBeforeSelect: function () {
                        $("#nav").find(".tree-node-selected").removeClass("tree-node-selected");
                    }
                });
            })
        }
    })
}

function closed() {
    $("#txtOldPass").textbox("setValue", "");
    $("#txtNewPass").textbox("setValue", "");
    $("#txtRePass").textbox("setValue", "");
    $("#errorMsg0").html("");
    $("#errorMsg1").html("");
    $("#errorMsg2").html("");
    $('#win').window('close');
}
function addTab(title, url, icon)  //添加选项卡
{
    var tabCount = $("#tabs").tabs('tabs').length;
    var existTab = $("#tabs").tabs('exists', title);
    if (tabCount <= 10 || existTab) {
        openTab(title, url, icon);
    }
    else {
        $.messager.confirm("系统提示", '<b>您当前打开的页面太多，如果继续打开会造成程序运行缓慢，影响操作！</b>', function (r) {
            if (r) {
                openTab(title, url, icon);
            }
        });
    }
}
function openTab(title, url, icon) {
    if (!$("#tabs").tabs("exists", title)) {
        var iframe = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
        $("#tabs").tabs("add", {
            title: title,
            content: iframe,
            closable: true,
            iconCls: icon,
            cls: 'tabContent'
        })
    }
    else {
        $("#tabs").tabs("select", title)
    }
}
//选项卡相关事件
function tabEvent() {
    /*绑定右键菜单*/
    $(".tabs-inner").live('contextmenu', function (e) {
        var title = $(this).children("span").text();
        if (title != '我的桌面') {
            $('#tabMenu').menu('show', {
                left: e.pageX,
                top: e.pageY,
            });
        }
        $('#tabMenu').data("currtab", title);
        $('#tabs').tabs('select', title);
        return false;
    });
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").live("dblclick", function () {
        var title = $(this).children("span").text();
        if (title != '我的桌面') {
            $('#tabs').tabs('close', title);
        }
    })
    /*刷新*/
    $('#refresh').click(function () {
        var currTab = $('#tabs').tabs('getSelected');
        var url = $(currTab.panel('options').content).attr('src');
        var iframe = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
        $('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: iframe
            }
        })
    })
    /*关闭当前*/
    $('#close').click(function () {
        var title = $('#tabMenu').data("currtab");
        $('#tabs').tabs('close', title);
    })
    /*全部关闭*/
    $('#closeall').click(function () {
        $('.tabs-inner span').each(function (i, n) {
            if (i > 0) {
                var t = $(n).text();
                $('#tabs').tabs('close', t);
            }
        });
    });
    /*关闭除当前之外的TAB*/
    $('#closeother').click(function () {
        var nextall = $('.tabs-selected').siblings();
        if (nextall.length > 0) {
            nextall.each(function (i, n) {
                if (i > 0) {
                    var t = $('a:eq(0) span', $(n)).text();
                    $('#tabs').tabs('close', t);
                }
            });
        }
        return false;
    });
    /*退出*/
    $("#exit").click(function () {
        $('#tabMenu').menu('hide');
    })
}
//主页面最大化
function setFullScreen() {
    var tool = $(this);
    if (tool.find('.icon-arrow_out_longer').length) {
        tool.find('.icon-arrow_out_longer').removeClass('icon-arrow_out_longer').addClass('icon-arrow_in_longer');
        $('#north,#west').panel('close')
        var panels = $('body').data().layout.panels;
        panels.north.length = 0;
        panels.west.length = 0;
        if (panels.expandWest) {
            panels.expandWest.length = 0;
            $(panels.expandWest[0]).panel('close');
        }
        $('body').layout('resize');
    } else if ($(this).find('.icon-arrow_in_longer').length) {
        tool.find('.icon-arrow_in_longer').removeClass('icon-arrow_in_longer').addClass('icon-arrow_out_longer');
        $('#north,#west').panel('open');
        var panels = $('body').data().layout.panels;
        panels.north.length = 1;
        panels.west.length = 1;
        if ($(panels.west[0]).panel('options').collapsed) {
            panels.expandWest.length = 1;
            $(panels.expandWest[0]).panel('open');
        }
        $('body').layout('resize');
    }
}
