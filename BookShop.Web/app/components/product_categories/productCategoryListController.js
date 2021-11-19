/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService']
    function productCategoryListController($scope,apiService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
      
        //phuong thuc lay data tu sever ve
        $scope.getProductCategories = getProductCategories;

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,//phai giống với bên ProductCategoryAPIController.
                    pageSize: 5
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;//Page to này ở bên ProductCategoryAPIController trả sang của hàm PaginationSet
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load product category falied');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('bookshop.product_categories'));// cái này phải phụ thuộc module products