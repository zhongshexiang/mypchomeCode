//初始化一个js的对象等同于 var wrapper = new Object();
var wrapper = {};


//对象的方法
//初始化
wrapper.init = function () {
    com.ajax({ type: 'GET', url: 'api/sys/Getmenu', success: wrapper.initMenu });
    $('.loginOut').click(wrapper.logout);
    $('.changepwd').click(wrapper.changePassword);
    $('#notity').jnotifyInizialize({ oneAtTime: true, appendType: 'append' }).css({ 'position': 'absolute', '*top': '2px', 'left': '50%', 'margin': '20px 0px 0px -120px', '*margin': '0px 0px 0px -120px', 'width': '240px', 'z-index': '9999' });
};

wrapper.logout = function () {
    $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (data) {
        if (data) {
            location.href = '/Home/Logout';
        }
    });
};

wrapper.changePassword = function () {
    com.dialog({
        title: "&nbsp;修改密码",
        iconCls: 'icon-key',
        width: 320,
        height: 180,
        html: "#password-template",
        viewModel: function (w) {
            form = {
                oldPw: ko.observable(),
                newPw: ko.observable(),
                confirmPw: ko.observable(),
            };

            $.extend($.fn.validatebox.defaults.rules, {
                equals: {
                    validator: function (value, param) {
                        return value == $(param[0]).val();
                    },
                    message: '两次输入密码不匹配'
                },
                PasswordStrength: {
                    validator: function (value, param) {
                        return com.calculatePasswordStrength(value);
                    },
                    message: '密码强度太弱'
                },
            });

            this.confirmClick = function () {
                if (com.formValidate(w)) {
                    var token = w.find('input[name=__RequestVerificationToken]').val();
                    var headers = {};
                    headers['__RequestVerificationToken'] = token;
                    com.ajax({
                        type: "POST",
                        url: "/home/changePWAction",
                        headers: headers,
                        data: ko.toJSON(form),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (d) {
                            if (d.status == 'ok') {
                                com.message('success', '保存成功！');
                                w.dialog('close');
                            }
                            else {
                                com.message('error', d.message);
                            }
                        }
                    });
                }
            };

            this.closeClick = function () {
                w.dialog('close');
            };
        }
    });
};

$(wrapper.init);