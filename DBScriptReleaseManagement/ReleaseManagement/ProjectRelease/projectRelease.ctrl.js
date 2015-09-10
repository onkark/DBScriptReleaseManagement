/// <reference path="../Project/project.ctrl.js" />
'use strict';

angular
.module('app.core')
.controller('ProjectReleaseController', ['$scope', '$modal', '$routeParams', 'ProjectReleaseService', 'sharedServices', function ($scope, $modal, $routeParams, ProjectReleaseService, sharedServices) {

	$scope.selectedReleaseId = null;

	$scope.selectedProjectId = -1;

	//Watch event 
	$scope.$on('projectSelected', function (event, data) {
		$scope.selectedProjectId = data.selectedProjectId;
		$scope.projectReleaseSchedule = ProjectReleaseService.query({ projectId: $scope.selectedProjectId });
	});

	
	$scope.selectReleaseProject = function (releaseId) {
	
		$scope.selectedReleaseId = releaseId;
		sharedServices.broadcastSelectedReleaseProject(releaseId);
	}

	//Open Release Schedule Dialog
	$scope.openReleaseSchedule = function (releaseId) {

		var openWindowInstance = $modal.open({

			templateUrl: 'add_releaseSchedule_modal',
			controller: $scope.releaseSchedule,
			resolve: {
				releaseId: function () {
					return releaseId;
				},
				selectedProjectId: function () {
					return $scope.selectedProjectId;
				}
			}
		});

		//on modal window close update table data
		openWindowInstance.result.then(function (releaseId) {
			$scope.projectReleaseSchedule = ProjectReleaseService.query({ projectId: $scope.selectedProjectId });
		});
	};

	$scope.deleteReleaseSchedule = function (releaseId) {
		$scope.releaseSchedule = new ProjectReleaseService();
		$scope.releaseSchedule.$delete({ id: releaseId });
		
		//reload table data
		setTimeout(function () {
			$scope.projectReleaseSchedule = ProjectReleaseService.query({ projectId: $scope.selectedProjectId });
		});
	};


	//Open Release schedule window controller/model
	$scope.releaseSchedule = function ($scope, $modalInstance, ProjectReleaseService, releaseId, selectedProjectId) {

		$scope.releaseSchedule = new ProjectReleaseService();

		//Edit action is releaseId have value.
		if (angular.isDefined(releaseId)) {
			$scope.releaseSchedule = ProjectReleaseService.get({ id: releaseId });
		}

		$scope.cancelReleaseSchedule = function () {
			$modalInstance.dismiss('cancel');
		}

		//Save release schedule
		$scope.saveReleaseSchedule = function () {

			if (!angular.isDefined(releaseId)) {
				$scope.releaseSchedule.ProjectId = selectedProjectId;
				$scope.releaseSchedule.$save({ id: releaseId }, function () { $modalInstance.close(releaseId); });

			} else {
				ProjectReleaseService.update( { id: releaseId }, $scope.releaseSchedule, function () { $modalInstance.close( releaseId ); } );
			}
		};
	}

}]);

