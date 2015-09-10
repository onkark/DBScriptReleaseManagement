'use strict';
angular
	.module('app.routes', ['ngRoute'])
	.config(config);

function config($routeProvider) {

	$routeProvider
		.when('/', {
			templateUrl: 'Project/Index.html',
			controller: 'ProjectsController'
		})
		.when('/Project/', {
			templateUrl: 'Project/Index.html',
			controller: 'ProjectsController'
		})
		.when('ProjectRelease/ProjectRelease.html', {
			templateUrl: 'Project/Index.html',
			controller: 'ProjectsController'
		})
		.otherwise({
			redirectTo: 'Project/Index.html',
			controller: 'ProjectsController'
		});
}