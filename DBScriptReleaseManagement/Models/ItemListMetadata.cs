namespace DBScriptReleaseManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ItemListMetadata
    {
		public int ItemId { get; set; }
        public string ItemValue { get; set; }
        public string ItemName { get; set; }
        public string GroupName { get; set; }
        public Nullable<bool> Active { get; set; }
    }

}
