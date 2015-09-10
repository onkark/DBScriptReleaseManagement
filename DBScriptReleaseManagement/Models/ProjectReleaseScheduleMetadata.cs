namespace DBScriptReleaseManagement.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	public class ProjectReleaseScheduleMetadata
	{
		public int ReleaseId { get; set; }
		public int ProjectId { get; set; }
		public Nullable<System.DateTime> ReleaseDate { get; set; }
		public string Comment { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime ModifiedOn { get; set; }
		public string ReleaseStatusId { get; set; }

	}


	public partial class ProjectReleaseSchedule
	{
		public string ReleaseStatusItemName { get; set; }
	}

}
