namespace Solution.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ff : DbContext
    {
        public ff()
            : base("name=ff")
        {
        }

        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<ligneqst> ligneqsts { get; set; }
        public virtual DbSet<question> questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.evaluations)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id_Emp);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.TypeEval)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.commentaire)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.contexteEval)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.periodEval)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .HasMany(e => e.ligneqsts)
                .WithOptional(e => e.evaluation)
                .HasForeignKey(e => e.evaluation_id_Eval);

            modelBuilder.Entity<question>()
                .Property(e => e.descriptionQst)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.typeQst)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.ligneqsts)
                .WithRequired(e => e.question)
                .HasForeignKey(e => e.question_id_Qst)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.ligneqsts1)
                .WithRequired(e => e.question1)
                .HasForeignKey(e => e.question_id_Qst)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<Solution.Presentation.Models.QuestionModel> QuestionModels { get; set; }

        //  public System.Data.Entity.DbSet<Solution.Presentation.Models.EvaluationModel> EvaluationModels { get; set; }

        //   public System.Data.Entity.DbSet<Solution.Presentation.Models.EvaluationModel> EvaluationModels { get; set; }
    }
}
