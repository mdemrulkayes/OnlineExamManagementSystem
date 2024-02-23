using api.oems.Core.Models;
using api.oems.Core.Models.Tutor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class OemsDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "User"); });
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Role"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaim"); });
        }

        public OemsDbContext(DbContextOptions<OemsDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Institute> Institutes { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<UserInstituteJoinRequest> UserInstituteJoinRequests { get; set; }

        public DbSet<QuestionSet> QuestionSets { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionOption> QuestionOptions { get; set; }

        public DbSet<MembershipDetail> MembershipDetails { get; set; }

        public DbSet<UserInMembership> UserInMemberships { get; set; }

        public DbSet<QuestionAnswers> QuestionAnswers { get; set; }

        public DbSet<QuestionAnswersMark> QuestionAnswersMark { get; set; }

        public virtual DbSet<ClassInMedium> ClassInMediums { get; set; }

        public virtual DbSet<SubjectInClass> SubjectInClasses { get; set; }

        public virtual DbSet<TutorClass> TutorClasses { get; set; }

        public virtual DbSet<TutorMedium> TutorMediums { get; set; }

        public virtual DbSet<TutorSubject> TutorSubjects { get; set; }

        public DbSet<TutorDistrict> Districts { get; set; }

        public DbSet<TutorArea> Areas { get; set; }

        public DbSet<TutorCommonEntity> TutorCommonEntities { get; set; }

        public DbSet<TutorPersonalInformation> TutorPersonalInformations { get; set; }

        public DbSet<TutorTutionInformation> TutorTutionInformations { get; set; }

        public DbSet<TutorEducationalInformation> TutorEducationalInformations { get; set; }

        public DbSet<TutorRequest> TutorRequests { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<TutorInPackage> TutorInPackages { get; set; }
    }
}
