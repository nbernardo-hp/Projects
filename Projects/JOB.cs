//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects
{
    using System;
    using System.Collections.Generic;
    
    public partial class JOB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOB()
        {
            this.JOB_DATES = new HashSet<JOB_DATES>();
            this.JOB_DESC = new HashSet<JOB_DESC>();
        }
    
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
    
        public virtual COMPANY COMPANY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB_DATES> JOB_DATES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB_DESC> JOB_DESC { get; set; }
    }
}
