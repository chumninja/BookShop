/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.filter('statusFilter', function () {
        return function ($scope) {
            if ($scope == true) return 'Kích hoạt';
            else return 'Khóa';
        }
    });
    
})(angular.module('bookshop.common'));