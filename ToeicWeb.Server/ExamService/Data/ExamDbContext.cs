﻿using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Data
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<PartResult> PartResults { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ResultDetail> ResultDetails { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<History>()
                .HasKey(h => h.Id);
            modelBuilder.Entity<PartResult>()
                .HasKey(pr => pr.Id);
            modelBuilder.Entity<Part>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);
            modelBuilder.Entity<ResultDetail>()
                .HasKey(rd => rd.Id);
            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<UserAnswer>()
                .HasKey(ua => ua.Id);

            modelBuilder.Entity<Answer>()
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(a => a.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<History>()
                .HasOne<Test>()
                .WithMany()
                .HasForeignKey(h => h.TestID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartResult>()
                .HasOne<Test>()
                .WithMany()
                .HasForeignKey(pr => pr.TestID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartResult>()
                .HasOne<Part>()
                .WithMany()
                .HasForeignKey(pr => pr.PartID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Part>()
                .HasOne<Test>()
                .WithMany()
                .HasForeignKey(p => p.TestID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne<Part>()
                .WithMany()
                .HasForeignKey(q => q.PartID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResultDetail>()
                .HasOne<Part>()
                .WithMany()
                .HasForeignKey(rd => rd.PartID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResultDetail>()
                .HasOne<History>()
                .WithMany()
                .HasForeignKey(rd => rd.HistoryID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAnswer>()
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(ua => ua.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAnswer>()
                .HasOne<Answer>()
                .WithMany()
                .HasForeignKey(ua => ua.SelectedAnswerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
