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
    
    public partial class tb_Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Part()
        {
            this.tb_Question = new HashSet<tb_Question>();
        }
    
        public int id { get; set; }
        public string partNumber { get; set; }
        public Nullable<int> id_Skill { get; set; }
        public bool Status { get; set; }
        public int Ordering { get; set; }
    
        public virtual tb_Skill tb_Skill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Question> tb_Question { get; set; }
    }
}