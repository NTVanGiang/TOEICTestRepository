﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToiecTestEntities : DbContext
    {
        public ToiecTestEntities()
            : base("name=ToiecTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_Account> tb_Account { get; set; }
        public virtual DbSet<tb_Answer> tb_Answer { get; set; }
        public virtual DbSet<tb_Image> tb_Image { get; set; }
        public virtual DbSet<tb_Level> tb_Level { get; set; }
        public virtual DbSet<tb_Part> tb_Part { get; set; }
        public virtual DbSet<tb_QuangCao> tb_QuangCao { get; set; }
        public virtual DbSet<tb_Question> tb_Question { get; set; }
        public virtual DbSet<tb_Quiz> tb_Quiz { get; set; }
        public virtual DbSet<tb_QuizDetail> tb_QuizDetail { get; set; }
        public virtual DbSet<tb_Skill> tb_Skill { get; set; }
        public virtual DbSet<tb_Sound> tb_Sound { get; set; }
        public virtual DbSet<tb_SubQuestion> tb_SubQuestion { get; set; }
        public virtual DbSet<tb_Topic> tb_Topic { get; set; }
        public virtual DbSet<tb_ViTriQC> tb_ViTriQC { get; set; }
    }
}