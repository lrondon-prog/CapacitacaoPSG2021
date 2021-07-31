using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Encontro26Listas.Data.Atacado
{
    public partial class AtacadoModel : DbContext
    {
        public AtacadoModel()
            : base("name=AtacadoModel")
        {
        }

        public virtual DbSet<categoria> categorias { get; set; }
        public virtual DbSet<produto> produtos { get; set; }
        public virtual DbSet<subcategoria> subcategorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.subcategorias)
                .WithRequired(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<produto>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<subcategoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<subcategoria>()
                .HasMany(e => e.produtos)
                .WithRequired(e => e.subcategoria)
                .WillCascadeOnDelete(false);
        }
    }
}
