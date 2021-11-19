/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookshop', ['bookshop.products', 'bookshop.product_categories', 'bookshop.common']).config(config);

    config.$inject =['$stateProvider','$urlRouterProvider']
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",//url thực tế ở trên trang
            templateUrl: "/app/components/home/homeView.html",//gọi đến template đã tách
            controller: "homeController"// vao đc homeView.html nó tự động nhận đc homeController , 
            //nhưng cần khai báo 1 file có tên zi
        });
        $urlRouterProvider.otherwise('/admin');
        //Ngược lại nếu ko có url route nào nó tự động trả về admin.
    }

})();