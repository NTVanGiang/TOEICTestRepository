//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Question()
        {
            this.tb_SubQuestion = new HashSet<tb_SubQuestion>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_Topic { get; set; }
        public Nullable<int> id_Level { get; set; }
        public string Title { get; set; }
        public string contentQuestion { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public bool Status { get; set; }
        public Nullable<int> id_Part { get; set; }
    
        public virtual tb_Level tb_Level { get; set; }
        public virtual tb_Part tb_Part { get; set; }
        public virtual tb_Topic tb_Topic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SubQuestion> tb_SubQuestion { get; set; }
    }
}