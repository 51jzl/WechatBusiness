//文本框验证类型扩展
$.extend($.fn.validatebox.defaults.rules, {
    number: {  //验证>=0的整数
        validator: function (value, param) {
            return /^\d+$/.test(value);
        },
        message: '请输入>=0的整数'
    },
    number_n: {  //验证>0的整数
        validator: function (value, param) {
            return /^[1-9]\d*$/.test(value);
        },
        message: '请输入>0的整数'
    },
    number_z: {  //验证非负数
        validator: function (value, param) {
            return /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test(value);
        },
        message: '输入值必须大于零'
    },
    chs: {  //验证汉字
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: '只能输入汉字'
    },
    mobile: {  //验证手机号
        validator: function (value) {
            return /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/.test(value);
        },
        message: '手机号码格式不正确'
    },
    tel: {  //验证固定电话
        validator: function (value) {
            return /^(^0\d{2}-?\d{8}$)|(^0\d{3}-?\d{7}$)|(^\(0\d{2}\)-?\d{8}$)|(^\(0\d{3}\)-?\d{7}$)$/.test(value);
        },
        message: '电话号码格式不正确'
    },
    zipcode: {  //邮编验证
        validator: function (value) {
            return /^[1-9]\d{5}$/.test(value);
        },
        message: '邮编格式不正确'
    },
    idcard: {  // 验证身份证
        validator: function (value) {
            return /(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(value);
        },
        message: '身份证号码格式不正确'
    },
    qq: {   // 验证QQ,从10000开始
        validator: function (value) {
            return /^[1-9]\d{4,9}$/i.test(value);
        },
        message: 'QQ号码格式不正确'
    },
})