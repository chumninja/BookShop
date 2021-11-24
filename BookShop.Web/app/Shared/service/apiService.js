/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http', 'notificationService', 'authenticationService']
    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,//hien tai lam 1 pt get sau nay co nhieu post put
            post: post,
            put: put,
            del:del
        }
        //ném vào 4 tham số.
        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.')
                } else if (failure != null)
                {
                    failure(error);
                }
               
            });
        }

        //ném vào 4 tham số.
        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.')
                } else if (failure != null) {
                    failure(error);
                }

            });
        }
        //ném vào 4 tham số.
        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.')
                } else if (failure != null) {
                    failure(error);
                }

            });
        }
        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result)
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.')
                }
                failure(Error);
            });
        }
    }
})(angular.module('bookshop.common'));//namespace thuoc commonS