//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthTracker.DataAccess.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public int ActivityId { get; set; }
        public System.DateTime Date { get; set; }
        public int ActivityTypeId { get; set; }
        public string Notes { get; set; }
        public int PersonId { get; set; }
    
        public virtual ActivityType ActivityType { get; set; }
        public virtual Person Person { get; set; }
    }
}
