/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }
        $scope.AddProduct = AddProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeotitle($scope.product.NameProduct);
        }
        function AddProduct() {
            apiService.post('/api/product/create_product', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.NameProduct + ' đã được thêm mới.');
                $state.go('add_product');// $state điều hướng của ui-route
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công');
            });
        }
        function loadProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.listProductCategory = result.data;
            }, function () {
                console.log('Cannot get list parents');
            });
        }

        loadProductCategory();
    }
})(angular.module('bookshop.products'));// cái này phải phụ thuộc module products