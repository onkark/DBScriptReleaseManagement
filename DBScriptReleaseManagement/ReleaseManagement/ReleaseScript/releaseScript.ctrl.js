/// <reference path="../Project/project.ctrl.js" />
'use strict';

angular
.module('app.core')
.controller( 'ReleaseScriptsController', ['$scope', '$modal', '$routeParams', 'ReleaseScriptsService', 'sharedServices', function ( $scope, $modal, $routeParams, ReleaseScriptsService, sharedServices ) {

	$scope.selectedReleaseId = null;
	

	//Watch event 
	$scope.$on( 'releaseSelected', function ( event, data ) {
		$scope.selectedReleaseId = data.selectedReleaseId;
		$scope.projectReleaseScripts = ReleaseScriptsService.query({ releaseId: $scope.selectedReleaseId });
	});


    //Open Release Script Dialog
	$scope.openReleaseScript = function (releaseScriptId) {

	    var openWindowInstance = $modal.open({

	        templateUrl: 'add_releaseScript_modal',
	        controller: $scope.releaseScript,
	        resolve: {
	            releaseScriptId: function () {
	                return releaseScriptId;
	            },
	            selectedReleaseId: function () {
	                return $scope.selectedReleaseId;
	            }
	        }
	    });

	    //on modal window close update table data
	    openWindowInstance.result.then(function (releaseScriptId) {
	        $scope.projectReleaseScripts = ReleaseScriptsService.query({ releaseId: $scope.selectedReleaseId });
	    });
	};

	$scope.deleteReleaseScript = function (releaseScriptId) {
	    $scope.releaseScripts = new ReleaseScriptsService();
	    $scope.releaseScripts.$delete({ id: releaseScriptId });

	    //reload table data
	    setTimeout(function () {
	        $scope.projectReleaseScripts = ReleaseScriptsService.query({ releaseId: $scope.selectedReleaseId });
	    });
	};


    //Open Release schedule window controller/model
	$scope.releaseScript = function ($scope, $modalInstance, ReleaseScriptsService, releaseScriptId, selectedReleaseId) {

	    $scope.releaseScript = new ReleaseScriptsService();

	    //Edit action is releaseScriptId have value.
	    if (angular.isDefined(releaseScriptId)) {
	        $scope.releaseScript = ReleaseScriptsService.get({ id: releaseScriptId });
	    }

	    $scope.cancelReleaseScript = function () {
	        $modalInstance.dismiss('cancel');
	    }

	    //Save release schedule
	    $scope.saveReleaseScript = function () {

	        if (!angular.isDefined(releaseScriptId)) {
	            $scope.releaseScript.ReleaseId = selectedReleaseId;
	            $scope.releaseScript.$save({ id: releaseScriptId }, function () { $modalInstance.close(releaseScriptId); });

	        } else {
	            ReleaseScriptsService.update({ id: releaseScriptId }, $scope.releaseScript, function () { $modalInstance.close(releaseScriptId); });
	        }
	    };
	}


}]);

