﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimeOnex.ModelData.Logic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnimeOnexDBEntities : DbContext
    {
        public AnimeOnexDBEntities()
            : base("name=AnimeOnexDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Anime> Anime { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Episodio> Episodio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
