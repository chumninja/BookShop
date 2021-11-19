/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http']
    function apiService($http) {
        return {
            get: get//hien tai lam 1 pt get sau nay co nhieu post put
        }
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result)
            },function(error){
                failure(Error);
            });
        }
    }
})(angular.module('bookshop.common'));//namespace thuoc commonS