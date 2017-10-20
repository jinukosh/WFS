window.publication = angular.module('WFS', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'WFSControllers']);   

publication.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider
        
        .when('/user/list', { templateUrl: 'AngularJS/App/User/List/UserList.view.html', controller: 'UserListController' })
        .when('/user/add', { templateUrl: 'AngularJS/App/User/Add/UserAdd.view.html', controller: 'UserAddController' })
        .when('/user/edit', { templateUrl: 'AngularJS/App/User/Edit/UserEdit.view.html', controller: 'UserEditController' })
        .when('/user/edit/:Id', { templateUrl: 'AngularJS/App/User/Edit/UserEdit.view.html', controller: 'UserEditController' })
        .when('/user/changepassword', { templateUrl: 'AngularJS/App/User/ChangePassword/ChangePassword.view.html', controller: 'ChangePasswordController' })
        .when('/user/logout', { templateUrl: 'AngularJS/App/User/Logout/Logout.view.html', controller: 'LogoutController' })

        .when('/note/add', { templateUrl: 'AngularJS/App/Note/Add/NoteAdd.view.html', controller: 'NoteAddController' })
        .when('/note/edit/:Id', { templateUrl: 'AngularJS/App/Note/Edit/NoteEdit.view.html', controller: 'NoteEditController' })
        .when('/note/list', { templateUrl: 'AngularJS/App/Note/List/NoteList.view.html', controller: 'NoteListController' })

        .when('/dashboard/default', { templateUrl: 'AngularJS/App/Dashboard/Default/DashboardDefault.view.html', controller: 'DashboardDefaultController' })

    $httpProvider.interceptors.push('authorizationInterceptor');
}]);


window.WFSControllers = angular.module('WFSControllers', ['ui.bootstrap', 'ngReallyClickModule', 'ui.select', 'ngSanitize', 'checklist-model']);
