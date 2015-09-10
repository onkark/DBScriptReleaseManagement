var app = angular.module("app", ['ngRoute', 'ngResource']);


app.factory('TeamMemberApi', ['$resource', function ($resource) {
    return $resource('../api/vpsTeamMembers/:employeeID', { employeeID: '@employeeID' }); // Note the full endpoint address
}]);


app.config(['$routeProvider', function ($routeProvider) {


    $routeProvider.
        when('/', {
            templateUrl: 'TeamMember/TeamIndex.html',
            controller: 'TeamMemberIndexCtrl'
        }).
        when('/TeamMember/Details/:employeeId', {
            templateUrl: 'TeamMember/Details.html',
            controller: 'TeamMemberIndexCtrl'
        })


}]);


app.controller('TeamMemberIndexCtrl', ['$scope', '$http', '$routeParams', 'TeamMemberApi', function ($scope, $http, $routeParams, TeamMemberApi) {

    $scope.message = "Hello World !!";

    if ($routeParams.employeeId)
        $scope.teamMember = TeamMemberApi.get({ employeeID: $routeParams.employeeId });
    else
        $scope.teamMembers = TeamMemberApi.query({ employeeID: $routeParams.employeeId });


}]);


app.controller('SearchTeammemberCtrl', ['$scope', '$http', '$routeParams', 'TeamMemberApi', function ($scope, $http, $routeParams, TeamMemberApi) {

    $scope.message = "Search World !!";


    $scope.getTeamMembers = function (searchString) {
        
        //TeamMemberApi.get({ employeeID: $routeParams.employeeId });

        if(searchString.length > 2)
        {

        }
            
    }


}]);




