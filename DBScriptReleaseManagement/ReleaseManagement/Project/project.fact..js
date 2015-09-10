'use strict';

angular
.module( 'app.services' )
.factory( 'ProjectService', ['$resource', function ( $resource ) {
	return $resource( '../api/Projects/:id', { id: '@id' }, {
		update: { method: 'PUT' }
	} );
}] );
