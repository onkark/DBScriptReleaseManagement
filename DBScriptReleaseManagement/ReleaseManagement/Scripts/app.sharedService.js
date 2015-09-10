'use strict';
//shared service example http://jsfiddle.net/onkark/8ouom1n8/4/
angular
	.module('app.services')
		.factory('sharedServices', ['$rootScope', function ($rootScope) {


			var sharedService = {};

			sharedService.projectId = 0;
			sharedService.releaseId = 0;

		    //Broadcast selected project
			sharedService.broadcastSelectedProject = function (projectId) {
				this.projectId = projectId;
				
				this.broadcastProjectSelected();
			};

			sharedService.broadcastProjectSelected = function () {
				$rootScope.$broadcast("projectSelected", { selectedProjectId: this.projectId });
			};



            //Broadcast selected release
			sharedService.broadcastSelectedReleaseProject = function (releaseId) {
				this.releaseId = releaseId;
				this.broadcastReleaseSelected();
			};

			sharedService.broadcastReleaseSelected = function () {
				$rootScope.$broadcast( "releaseSelected", { selectedReleaseId: sharedService.releaseId } );
			};

			return sharedService;

		}]);
