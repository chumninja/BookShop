(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window',
        function ($http, $q, $window) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                $window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
                //window và http là 1 service của angular cho phép lưu các token vào ssionStorage vào.
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                $window.sessionStorage["TokenInfo"] = null;
            }

            this.init = function () {
                if ($window.sessionStorage["TokenInfo"]) {
                    tokenInfo = JSON.parse($window.sessionStorage["TokenInfo"]);
                }
            }

            //gán cái token vào cái header để truyền lên service.
            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            //Để xem user đăng nhập chưa tí tạo 1 cái test để test
            this.validateRequest = function () {
                var url = 'api/home/TestMethod';
                var deferred = $q.defer();
                $http.get(url).then(function () {
                    deferred.resolve(null);//thành công trả về đúng
                }, function (error) {
                    deferred.reject(error);//Sai trả về error
                });
                return deferred.promise;//pattern promise giúp cho chúng ra đảm bảo việc thực thi trước sau.
            }

            this.init();
        }
    ]);
})(angular.module('bookshop.common'));