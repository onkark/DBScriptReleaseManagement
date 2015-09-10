'use strict';

angular
.module( 'app.services' )
.factory( 'ReleaseScriptsService', ['$resource', function ( $resource ) {
	return $resource( '../api/ReleaseScripts/:id', { id: '@id' }, {
		update: { method: 'PUT' }
	} );
}] );
