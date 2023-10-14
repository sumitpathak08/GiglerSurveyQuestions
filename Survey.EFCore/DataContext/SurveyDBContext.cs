using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Survey.EFCore.Entity;

namespace Survey.EFCore.DataContext;

public partial class SurveyDBContext : DbContext
{
    public SurveyDBContext()
    {
    }

    public SurveyDBContext(DbContextOptions<SurveyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblSurveyQuestion> TblSurveyQuestions { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-79KO581\\SQLEXPRESS;Initial Catalog=SurveyDB;Persist Security Info=True;User ID=sa;pwd=gipl;TrustServerCertificate=True");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                //optionsBuilder.UseSqlServer(@"Data Source=vsp13dev2\sp13;Initial Catalog=AssetIntegrityDev;Persist Security Info=True;User ID=devadmin;pwd=adco@2019");
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("conStr"));
            }
            catch (Exception ex)
            {
               
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblSurveyQuestion>(entity =>
        {
            entity.ToTable("Tbl_Survey_Question");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SimilarQid).HasColumnName("SimilarQId");

            //entity.HasOne(d => d.SimilarQ).WithMany(p => p.InverseSimilarQ)
            //    .HasForeignKey(d => d.SimilarQid)
            //    .HasConstraintName("FK_Tbl_Survey_Question_Tbl_Survey_Question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
