namespace DBScriptReleaseManagement.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	public class ReleaseScriptMetadata
	{
		public int ReleaseScriptId { get; set; }
		public Nullable<int> ReleaseId { get; set; }
		public Nullable<int> SequenceNo { get; set; }
		public string SVNScriptPath { get; set; }
	}

}
