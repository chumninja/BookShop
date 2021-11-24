(function (app) {
    'use strict';
    app.factory('authData', [function () {
        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,// xem user đăng nhập chưa
            userName: ""//gán mặc định rỗng
        };
        authDataFactory.authenticationData = authentication;

        return authDataFactory;//trả về 2 dư liệu là isauthen và user name.
        //do chi tương tác trên service nên chỉ lưu dữ liệu login trên client thui.
    }]);
})(angular.module('bookshop.common'));