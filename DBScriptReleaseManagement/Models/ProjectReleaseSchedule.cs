namespace DBScriptReleaseManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectReleaseScheduleMetadata))]
    public partial class ProjectReleaseSchedule
    {
        public ProjectReleaseSchedule()
        {
            this.ReleaseScripts = new HashSet<ReleaseScript>();
        }
    
        public int ReleaseId { get; set; }
        public int ProjectId { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string ReleaseStatusId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ICollection<ReleaseScript> ReleaseScripts { get; set; }
    }
}
