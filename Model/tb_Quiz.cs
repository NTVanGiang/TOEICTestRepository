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
    
    public partial class tb_Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Quiz()
        {
            this.tb_QuizDetail = new HashSet<tb_QuizDetail>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> totalQuestion { get; set; }
        public Nullable<int> totalTime { get; set; }
        public Nullable<int> id_Account { get; set; }
        public Nullable<System.DateTime> BeginTime { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public Nullable<int> scoreRead { get; set; }
        public Nullable<int> scoreListening { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool isAdminCreate { get; set; }
    
        public virtual tb_Account tb_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_QuizDetail> tb_QuizDetail { get; set; }
    }
}
