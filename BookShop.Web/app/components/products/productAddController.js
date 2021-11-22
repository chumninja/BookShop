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
            height: '100px'
        }
        //ChooseImage
        $scope.ChooseImages = ChooseImages;
        function ChooseImages() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Images = fileUrl;
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

        
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeotitle($scope.product.NameProduct);
        }

        $scope.AddProduct = AddProduct;
        function AddProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);//nó là 1 list nên cần chuyển về chuỗi..
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