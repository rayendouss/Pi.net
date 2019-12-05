namespace Pidev.data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<tableemploye> tableemploye { get; set; }
        public virtual DbSet<tp_jsf_employe> tp_jsf_employe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categories>()
                .Property(e => e.nomcomp)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.niveaudesktops)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.niveaulangues)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.niveauweb)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<tableemploye>()
                .Property(e => e.tablecategoriesniv)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
