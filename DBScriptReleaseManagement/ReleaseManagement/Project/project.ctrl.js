'use strict';

angular
.module('app.core')
.controller('ProjectsController', ['$scope', '$modal', '$routeParams', 'ProjectService', 'sharedServices', function ($scope, $modal, $routeParams, ProjectService, sharedServices) {


	$scope.projects = ProjectService.query({ id: $routeParams.id });

	$scope.selectedProjectId = null;

	//Select Project
	$scope.selectProject = function (projectId) {
		$scope.selectedProjectId = projectId;
	
		sharedServices.broadcastSelectedProject(projectId);

	};

	//Open Project Dialog
	$scope.open = function (projectId) {
		
		var openWindowInstance = $modal.open({
			templateUrl: 'add_project_modal',
			controller: $scope.projectModel,
			resolve: {
				projectId: function () {
					return projectId;
				}
			}
		});

		//get table
		openWindowInstance.result.then(function (projectId) {
			$scope.projects = ProjectService.query({ id: $routeParams.id });
		},
			function () {
				//$log.info('Modal dismissed at ' + new Date())
			}
		);
	};

	//Delete Project
	$scope.delete = function (projectId) {
		$scope.project = new ProjectService();
		$scope.project.$delete({ id: projectId });

		setTimeout(function () {
			$scope.projects = ProjectService.query({ id: $routeParams.id })
		}, 100);

	}

	//Open Project edit window 
	$scope.projectModel = function ($scope, $modalInstance, ProjectService, projectId) {

		$scope.project = new ProjectService();

		//Edit Action if id have value
		if (angular.isDefined(projectId)) {
			$scope.project = ProjectService.get({ id: projectId });
		}

		// close modal
		$scope.cancel = function () {
			$modalInstance.dismiss('cancel');
		};

		//Save project
		$scope.save = function () {

			if (!angular.isDefined(projectId)) {
				$scope.project.$save({ id: projectId }, function () { $modalInstance.close(projectId); });
			} else {
				ProjectService.update({ id: projectId }, $scope.project, function () { $modalInstance.close(projectId); });
			}
		}
	}


}]);

