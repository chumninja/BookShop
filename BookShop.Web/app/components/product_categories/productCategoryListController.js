/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','$filter']
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        //phuong thuc lay data tu sever ve
        $scope.getProductCategories = getProductCategories;

        //phuong thuc delete.
        $scope.deleteProductCategory = deleteProductCategory;
        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa danh mục này ?').then(function () {
                //then mang 2 phương thức là No và yes.
                var config = {
                    params: {
                        id: id,

                    }
                }
                apiService.del('/api/productcategory/delete_productcategory', config, function (result) {
                    //4 tham số data ,params,success,failure
                    notificationService.displaySuccess('Xóa thành công '+result.data.NameCategory);
                    searchProductCategory();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }


        //Phuong thức selected nhiều id
        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        },true);

        //button search
        $scope.searchProductCategory = searchProductCategory;
        function searchProductCategory() {
            getProductCategories();//chỉ cần gọi lại hàm này để load data, nhận đc page = 0; 
        }
        function getProductCategories(page, keyword) {
            page = page || 0;
            var config = {
                params: {
                    //tham số nào truyền vào thì mới cần cho zô function, và thứ tự ở ngoài
                    keyword: $scope.keyword,//cái này đc binding ra ngoài nên cần chú ý nó có dữ liệu ko ko thì nó mặc định null, để truyền xuống API
                    page: page,//phai giống với bên ProductCategoryAPIController.
                    pageSize: 5
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.')
                } else {
                    if (config.params.keyword == '') { 
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi là ' + config.params.keyword)
                    }
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;//Page to này ở bên ProductCategoryAPIController trả sang của hàm PaginationSet
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
                $scope.totalCountCurrent = result.data.TotalCountCunrent;
            }, function () {
                console.log('load product category falied');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('bookshop.product_categories'));// cái này phải phụ thuộc module products