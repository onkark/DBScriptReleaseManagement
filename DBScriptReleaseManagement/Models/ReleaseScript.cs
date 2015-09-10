namespace DBScriptReleaseManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ReleaseScriptMetadata))]
    public partial class ReleaseScript
    {
        public int ReleaseScriptId { get; set; }
        public Nullable<int> ReleaseId { get; set; }
        public Nullable<int> SequenceNo { get; set; }
        public string SVNScriptPath { get; set; }
    
        public virtual ProjectReleaseSchedule ProjectReleaseSchedule { get; set; }
    }
}
