/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];
    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.product = { 
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '100px'
        }
        $scope.EditProduct = EditProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeotitle($scope.product.NameProduct);
        }
        //ChooseImage
        $scope.ChooseImages = ChooseImages;
        function ChooseImages() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Images = fileUrl;
                });
            }
            finder.popup();
        }
        //More Image
        $scope.moreImages = [];
        $scope.ChooseMoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                //bắt nó load ngay ko cần đợi 
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });
            }
            finder.popup();
        }
        //get details
        function loadproductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id,null, function (result) {
                $scope.product = result.data;//gán đối tượng lấy dc vào
                if(result.data.MoreImage.length > 0)
                {
                    $scope.moreImages = JSON.parse($scope.product.MoreImage);
                }
            }, function (error) {
                notificationService.displayError(error.data)
            });
        }

        function EditProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);//nó là 1 list nên cần chuyển về chuỗi..
            apiService.put('/api/product/edit_product', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.NameProduct + ' đã được cập nhật.');
                $state.go('edit_product');// $state điều hướng của ui-route
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công');
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
        loadproductDetail();
      
    }

})(angular.module('bookshop.products'))