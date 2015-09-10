namespace DBScriptReleaseManagement.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ProjectMetadata
	{

		public int ProjectId { get; set; }

		public string ProjectName { get; set; }
		public string SVNPath { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime ModifiedOn { get; set; }
	}

}
