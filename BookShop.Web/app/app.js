/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookshop', ['bookshop.products', 'bookshop.product_categories', 'bookshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: "",
                templateUrl: "/app/Shared/views/baseView.html",
                abstract: true
            })
           .state('login', {
               url: "/login",
               templateUrl: "/app/components/LoginAdmin/loginView.html",
               controller: "loginController"
           })
           .state('home', {
               url: "/admin",
               parent: 'base',
               templateUrl: "/app/components/home/homeView.html",
               controller: "homeController"
           });
        $urlRouterProvider.otherwise('/admin');
        //Ngược lại nếu ko có url route nào nó tự động trả về admin.
    }

})();