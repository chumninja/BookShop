/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookshop.product_categories', ['bookshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",//url thực tế ở trên trang
            templateUrl: "/app/components/product_categories/productCategoryListView.html",//gọi đến template đã tách
            controller: "productCategoryListController"// vao đc homeView.html nó tự động nhận đc homeController , 
            //nhưng cần khai báo 1 file có tên zi
        }).state('add_product_category', {
            url: "/add_product_category",//url thực tế ở trên trang
            templateUrl: "/app/components/product_categories/productCategoryAddView.html",//gọi đến template đã tách
            controller: "productCategoryAddController"// vao đc homeView.html nó tự động nhận đc homeController , 
            //nhưng cần khai báo 1 file có tên zi
        });
    }

})();