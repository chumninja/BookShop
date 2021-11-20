/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope','notificationService','$state','commonService'];
    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.AddProductCategory = AddProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeotitle($scope.productCategory.NameCategory);
        }
        function AddProductCategory() {
            apiService.post('/api/productcategory/create_productcategory', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.NameCategory + ' đã được thêm mới.');
                $state.go('add_product_category');// $state điều hướng của ui-route
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công');
            });
        }
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parents');
            }); 
        }

        loadParentCategory();
    }

})(angular.module('bookshop.product_categories'))