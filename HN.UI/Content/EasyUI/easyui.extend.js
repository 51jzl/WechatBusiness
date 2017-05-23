$.extend($.fn.textbox.defaults, {
    inputEvents: {
        blur: function (e) {
            var t = $(e.data.target);
            var opts = t.textbox("options");
            if (opts.refer) {
                if (t.textbox('getValue') == '' || t.textbox('getValue') == undefined || t.textbox('getValue') == 0) {
                    t.textbox('setText', '');
                }
            }
            else {
                t.textbox("setValue", opts.value);
            }
        }, keydown: function (e) {
            if (e.keyCode == 13) {
                var t = $(e.data.target);
                var opts = t.textbox("options");
                if (!opts.refer) {
                    t.textbox("setValue", t.textbox("getText"));
                }
            }
        }
    }
})




