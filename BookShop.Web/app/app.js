/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookshop',
        ['bookshop.products',
            'bookshop.product_categories',
            'bookshop.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/Shared/views/baseView.html',
                abstract: true
            }).state('login', {
                url: "/login",
                templateUrl: "/app/components/Login/loginAdmin.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",//url thực tế ở trên trang
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",//gọi đến template đã tách
                controller: "homeController"// vao đc homeView.html nó tự động nhận đc homeController , 
                //nhưng cần khai báo 1 file có tên zi
            });
        $urlRouterProvider.otherwise('/login');
        //Ngược lại nếu ko có url route nào nó tự động trả về admin.
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();