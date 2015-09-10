namespace DBScriptReleaseManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectMetadata))]
    public partial class Project
    {
        public Project()
        {
            this.ProjectReleaseSchedules = new HashSet<ProjectReleaseSchedule>();
        }
    
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string SVNPath { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
    
        public virtual ICollection<ProjectReleaseSchedule> ProjectReleaseSchedules { get; set; }
    }
}
