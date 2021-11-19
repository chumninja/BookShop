/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService']
    function productCategoryListController($scope,apiService) {
        $scope.productCategories = [];
        //phuong thuc lay data tu sever ve
        $scope.getProductCategories = function getProductCategories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('load product category falied');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('bookshop.product_categories'));// cái này phải phụ thuộc module products