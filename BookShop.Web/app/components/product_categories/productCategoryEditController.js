/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.productCategory = {
           
        }

        $scope.EditProductCategory = EditProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeotitle($scope.productCategory.NameCategory);
        }
        //get details
        function loadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id,null, function (result) {
                $scope.productCategory = result.data;//gán đối tượng lấy dc vào
            }, function (error) {
                notificationService.displayError(error.data)
            });
        }

        function EditProductCategory() {
            apiService.put('/api/productcategory/edit_productcategory', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.NameCategory + ' đã được cập nhật.');
                $state.go('edit_product_category');// $state điều hướng của ui-route
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công');
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
        loadProductCategoryDetail();
      
    }

})(angular.module('bookshop.product_categories'))