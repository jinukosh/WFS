﻿window.publication = angular.module('login', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'WFSControllers']);

publication.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider
        .when('/', { templateUrl: '../AngularJS/App/User/Login/Login.view.html', controller: 'LoginController' });

    $httpProvider.interceptors.push('authorizationInterceptor');
}]);


window.WFSControllers = angular.module('WFSControllers', []);
