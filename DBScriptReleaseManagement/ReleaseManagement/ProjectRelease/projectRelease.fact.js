'use strict';

angular
.module( 'app.services' )
.factory( 'ProjectReleaseService', ['$resource', function ( $resource ) {
	return $resource( '../api/ProjectReleaseSchedules/:id', { id: '@id' }, {
		update: { method: 'PUT' }
	} );
}] );
