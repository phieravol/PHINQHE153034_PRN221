using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EduTech.Data;

namespace EduTech.Models
{
    public partial class EduTechContext : EduIdentityContext
    {
        public EduTechContext(DbContextOptions<EduTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorGroup> AuthorGroups { get; set; } = null!;
        public virtual DbSet<AuthorGroupFeature> AuthorGroupFeatures { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyAttribute> CompanyAttributes { get; set; } = null!;
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobAttribute> JobAttributes { get; set; } = null!;
        public virtual DbSet<JobDetail> JobDetails { get; set; } = null!;
        public virtual DbSet<JobsUser> JobsUsers { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LessonDone> LessonDones { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<SkillCourse> SkillCourses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAuthorGroup> UserAuthorGroups { get; set; } = null!;
        public virtual DbSet<UserCompany> UserCompanies { get; set; } = null!;
        public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
				var connectionString = configuration.GetConnectionString("EdTechDb");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("AuthorGroup");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupDescription)
                    .HasMaxLength(500)
                    .HasColumnName("group_description");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(150)
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<AuthorGroupFeature>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AuthorGroup_Feature");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("group_id");

                entity.HasOne(d => d.Feature)
                    .WithMany()
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_AuthorGroup_Feature_Feature");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorGroup_Feature_AuthorGroup");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("Chapter");

                entity.Property(e => e.ChapterId).HasColumnName("chapter_id");

                entity.Property(e => e.ChapterDescription).HasColumnName("chapter_description");

                entity.Property(e => e.ChapterTitile)
                    .HasMaxLength(500)
                    .HasColumnName("chapter_titile");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_Chapter_Course");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyDescription).HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(500)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<CompanyAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeCode);

                entity.ToTable("Company_Attributes");

                entity.Property(e => e.AttributeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("attribute_code")
                    .IsFixedLength();

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(500)
                    .HasColumnName("attribute_name");

                entity.Property(e => e.CompanyDetailsId).HasColumnName("company_detailsId");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.HasOne(d => d.CompanyDetails)
                    .WithMany(p => p.CompanyAttributes)
                    .HasForeignKey(d => d.CompanyDetailsId)
                    .HasConstraintName("FK_Company_Attributes_company_details");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyAttributes)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Company_Attributes_Company");
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.HasKey(e => e.CompanyDetailsId);

                entity.ToTable("company_details");

                entity.Property(e => e.CompanyDetailsId).HasColumnName("company_detailsId");

                entity.Property(e => e.DetailsValue)
                    .HasMaxLength(50)
                    .HasColumnName("details_value");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode);

                entity.ToTable("Course");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.Property(e => e.CourseTarget)
                    .HasMaxLength(2000)
                    .HasColumnName("course_target");

                entity.Property(e => e.CourseTitle)
                    .HasMaxLength(500)
                    .HasColumnName("course_title");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.TotalLesson).HasColumnName("total_lesson");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.FeatureDescription)
                    .HasMaxLength(500)
                    .HasColumnName("feature_description");

                entity.Property(e => e.FeatureName)
                    .HasMaxLength(150)
                    .HasColumnName("feature_name");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId)
                    .ValueGeneratedNever()
                    .HasColumnName("job_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.JobsTitle)
                    .HasMaxLength(500)
                    .HasColumnName("jobs_title");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Jobs_Company");
            });

            modelBuilder.Entity<JobAttribute>(entity =>
            {
                entity.HasKey(e => e.JobAttributeCode);

                entity.ToTable("Job_Attributes");

                entity.Property(e => e.JobAttributeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("jobAttribute_code")
                    .IsFixedLength();

                entity.Property(e => e.JobAttributeName)
                    .HasMaxLength(500)
                    .HasColumnName("jobAttribute_name");

                entity.Property(e => e.JobDetailsId).HasColumnName("job_detailsId");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.HasOne(d => d.JobDetails)
                    .WithMany(p => p.JobAttributes)
                    .HasForeignKey(d => d.JobDetailsId)
                    .HasConstraintName("FK_Job_Attributes_JobDetails");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobAttributes)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Job_Attributes_Jobs");
            });

            modelBuilder.Entity<JobDetail>(entity =>
            {
                entity.HasKey(e => e.JobDetailsId);

                entity.Property(e => e.JobDetailsId)
                    .ValueGeneratedNever()
                    .HasColumnName("job_detailsId");

                entity.Property(e => e.JobDetailsValue)
                    .HasMaxLength(50)
                    .HasColumnName("job_detailsValue");
            });

            modelBuilder.Entity<JobsUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Jobs_User");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobsExperience)
                    .HasMaxLength(50)
                    .HasColumnName("jobs_experience");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Job)
                    .WithMany()
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Jobs_User_Jobs");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Jobs_User_User");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("lesson_id");

                entity.Property(e => e.ChapterId).HasColumnName("chapter_id");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.LessonDetail).HasColumnName("lesson_detail");

                entity.Property(e => e.LessonTitle)
                    .HasMaxLength(1000)
                    .HasColumnName("lesson_title");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("videoURL");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterId)
                    .HasConstraintName("FK_Lesson_Chapter");
            });

            modelBuilder.Entity<LessonDone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lesson_Done");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.Property(e => e.LessonId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("lesson_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_Lesson_Done_Course");

                entity.HasOne(d => d.Lesson)
                    .WithMany()
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Done_Lesson");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Lesson_Done_User");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(10)
                    .HasColumnName("skill_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SkillCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Skill_Course");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.Property(e => e.SkillId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("skill_id");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_Skill_Course_Course");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Skill_Course_Skills");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .HasColumnName("address");

                entity.Property(e => e.Company)
                    .HasMaxLength(500)
                    .HasColumnName("company");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(150)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserAuthorGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_AuthorGroup");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_User_AuthorGroup_AuthorGroup");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_User_AuthorGroup_User");
            });

            modelBuilder.Entity<UserCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Position)
                    .HasMaxLength(500)
                    .HasColumnName("position");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_User_Company_Company");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_User_Company_User");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Skills");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillLevel).HasColumnName("skill_level");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_User_Skills_Skills");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_User_Skills_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
