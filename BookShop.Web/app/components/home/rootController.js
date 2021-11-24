/// <reference path="D:\Angulur\Git_Source\BookShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', '$state'];
    function rootController($scope, $state) {
        $scope.logout = function () {
            $state.go('login');//đẩy nó ra ngoài
        }
    }
})(angular.module('bookshop'));