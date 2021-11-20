/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope'];
    function productCategoryAddController(apiService,$scope) {
        $scope.productCategory = {
            CreateDate : new Date(),
        }
       
        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parents');
            })
        }

        loadParentCategory();
    }

})(angular.module('bookshop.product_categories'))