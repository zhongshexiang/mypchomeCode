var viewModel = function () {
    var self = this;
    this.form = {
        UserName: ko.observable(),
        Password: ko.observable(),
        CheckCode:ko.observable(),
        RememberMe: ko.observable(false),
        IP: null,
        City: null,

    };
    this.message = ko.observable();

    function refreshCheckCode() {
        var newSrc = "Login/ShowValidateCode?" + (new Date()).getTime();;
        $("#imgCode").attr("src", newSrc);
    }

    this.loginClick = function (form) {
        if (!self.form.Password())
            self.form.Password($('[type=password]').val());

        var token = $('input[name=__RequestVerificationToken]').val();
        var headers = {};
        headers['__RequestVerificationToken'] = token;
        $.ajax({
            type: "POST",
            url: "/Login/LoginAction",
            headers: headers,
            data: ko.toJSON(self.form),
            dataType: "json",
            contentType: "application/json",
            success: function (d) {
                if (d.status == 'ok') {
                    self.message("登陆成功正在跳转，请稍候...");
                    window.location.href = '/';
                } else {
                    refreshCheckCode();
                    self.message(d.message);
                }
            },
            error: function (e) {
                refreshCheckCode();
                self.message(e.responseText);
            },
            beforeSend: function () {
                $(form).find("input").attr("disabled", true);
                self.message("正在登陆处理，请稍候...");
            },
            complete: function () {
                $(form).find("input").attr("disabled", false);
            }
        });
    };

    //重置
    this.resetClick = function () {
        self.form.UserName("");
        self.form.Password("");
        self.form.RememberMe(false);
        self.form.CheckCode("");
    };

    this.init = function () {
        $.getJSON("http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&callback=?", function (d) {
            self.form.City = d.content.address;
        });
        //if (top != window) top.window.location = window.location;
    };

    this.checkCodeClick = function() {
        refreshCheckCode();
    }

    this.init();
}

$(function () { ko.applyBindings(new viewModel()); });