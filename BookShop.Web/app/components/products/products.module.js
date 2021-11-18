/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookshop.products',['bookshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",//url thực tế ở trên trang
            templateUrl: "/app/components/products/productListView.html",//gọi đến template đã tách
            controller: "productListController"// vao đc homeView.html nó tự động nhận đc homeController , 
            //nhưng cần khai báo 1 file có tên zi
        }).state('product_add', {
            url: "/product_add",//url thực tế ở trên trang
            templateUrl: "/app/components/products/productAddView.html",//gọi đến template đã tách
            controller: "productAddController"// vao đc homeView.html nó tự động nhận đc homeController , 
            //nhưng cần khai báo 1 file có tên zi
        });
    }

})();