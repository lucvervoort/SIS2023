using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SIS.Infrastructure.EFRepository.Models;

namespace SIS.Infrastructure.EFRepository.Context;

public partial class GenSisDbContext : DbContext
{
    public GenSisDbContext()
    {
    }

    public GenSisDbContext(DbContextOptions<GenSisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Concept> Concepts { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ControlLevel> ControlLevels { get; set; }

    public virtual DbSet<CoordinationRole> CoordinationRoles { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseGroup> CourseGroups { get; set; }

    public virtual DbSet<CourseGroupStudent> CourseGroupStudents { get; set; }

    public virtual DbSet<CourseGroupStudentGroup> CourseGroupStudentGroups { get; set; }

    public virtual DbSet<CourseGroupTeacher> CourseGroupTeachers { get; set; }

    public virtual DbSet<CourseGroupTeacherGroup> CourseGroupTeacherGroups { get; set; }

    public virtual DbSet<CourseTrajectory> CourseTrajectories { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<InfoType> InfoTypes { get; set; }

    public virtual DbSet<Internship> Internships { get; set; }

    public virtual DbSet<InternshipContact> InternshipContacts { get; set; }

    public virtual DbSet<Ioem> Ioems { get; set; }

    public virtual DbSet<LearningOutcome> LearningOutcomes { get; set; }

    public virtual DbSet<LearningOutcomeType> LearningOutcomeTypes { get; set; }

    public virtual DbSet<LearningTarget> LearningTargets { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Presence> Presences { get; set; }

    public virtual DbSet<PresenceState> PresenceStates { get; set; }

    public virtual DbSet<RegistrationState> RegistrationStates { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomKind> RoomKinds { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Rubric> Rubrics { get; set; }

    public virtual DbSet<RubricColumn> RubricColumns { get; set; }

    public virtual DbSet<RubricInstance> RubricInstances { get; set; }

    public virtual DbSet<RubricInstanceScore> RubricInstanceScores { get; set; }

    public virtual DbSet<RubricRow> RubricRows { get; set; }

    public virtual DbSet<RubricRowHeader> RubricRowHeaders { get; set; }

    public virtual DbSet<RubricRubricColumn> RubricRubricColumns { get; set; }

    public virtual DbSet<RubricRubricRow> RubricRubricRows { get; set; }

    public virtual DbSet<RubricRubricRowHeader> RubricRubricRowHeaders { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<SchedulingTimeslot> SchedulingTimeslots { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<StudentIoem> StudentIoems { get; set; }

    public virtual DbSet<StudentStudentGroup> StudentStudentGroups { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAssignmentPercentageInterest> TeacherAssignmentPercentageInterests { get; set; }

    public virtual DbSet<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; }

    public virtual DbSet<TeacherCourseInterest> TeacherCourseInterests { get; set; }

    public virtual DbSet<TeacherGroup> TeacherGroups { get; set; }

    public virtual DbSet<TeacherInterest> TeacherInterests { get; set; }

    public virtual DbSet<TeacherLocationInterest> TeacherLocationInterests { get; set; }

    public virtual DbSet<TeacherPreference> TeacherPreferences { get; set; }

    public virtual DbSet<TeacherTeacherGroup> TeacherTeacherGroups { get; set; }

    public virtual DbSet<TeacherType> TeacherTypes { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<TopicCategory> TopicCategories { get; set; }

    public virtual DbSet<Trajectory> Trajectories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,3025;Initial Catalog=SIS_DVLP;Persist Security Info=True;User ID=sis;TrustServerCertificate=True;Password=ZwarteRidder007");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicYearId).HasName("PK__Academic__C54C7A0142F95E11");

            entity.ToTable("AcademicYear", tb => tb.HasTrigger("TG_AcademicYear_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFBB90755EC");

            entity.ToTable("Address");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Country");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC4938CCDC0");

            entity.ToTable("Building", tb => tb.HasTrigger("TG_Building_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);

            entity.HasOne(d => d.Location).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_Location");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598DD6E448A613");

            entity.ToTable("Campus", tb => tb.HasTrigger("TG_Campus_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC97E18EDD");

            entity.ToTable("Company", tb => tb.HasTrigger("TG_Company_Update"));

            entity.HasIndex(e => e.Phone, "UQ__Company__5C7E359E99486581").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ__Company__6FAE0782D3A7105F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Company__A9D1053472E979B3").IsUnique();

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Mobile)
                .HasMaxLength(12)
                .HasDefaultValueSql("('+')");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasDefaultValueSql("('+')");
            entity.Property(e => e.Url)
                .HasDefaultValueSql("('https://')")
                .HasColumnName("URL");
            entity.Property(e => e.Vat)
                .HasMaxLength(13)
                .HasColumnName("VAT");

            entity.HasOne(d => d.Address).WithMany(p => p.Companies)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Address");
        });

        modelBuilder.Entity<Concept>(entity =>
        {
            entity.HasKey(e => e.ConceptId).HasName("PK__Concept__515AA756A46C05E8");

            entity.ToTable("Concept", tb => tb.HasTrigger("TG_Concept_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259B42E25EC3");

            entity.ToTable("Contact", tb => tb.HasTrigger("TG_Contact_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Department).HasMaxLength(512);
            entity.Property(e => e.FunctionRole).HasMaxLength(512);

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Company");

            entity.HasOne(d => d.Person).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Person");
        });

        modelBuilder.Entity<ControlLevel>(entity =>
        {
            entity.HasKey(e => e.ControlLevelId).HasName("PK__ControlL__5CDF013A80DC5453");

            entity.ToTable("ControlLevel", tb => tb.HasTrigger("TG_ControlLevel_Update"));

            entity.HasIndex(e => e.Name, "UQ__ControlL__737584F68A5DE8B9").IsUnique();

            entity.HasIndex(e => e.Abbreviation, "UQ__ControlL__9C41170E54CC49D7").IsUnique();

            entity.Property(e => e.Abbreviation).HasMaxLength(1);
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<CoordinationRole>(entity =>
        {
            entity.HasKey(e => e.CoordinationRoleId).HasName("PK__Coordina__19EB71C14F465F54");

            entity.ToTable("CoordinationRole", tb => tb.HasTrigger("TG_CoordinationRole_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609F2CF546BD");

            entity.ToTable("Country");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7DD3E00FD");

            entity.ToTable("Course", tb => tb.HasTrigger("TG_Course_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
            entity.Property(e => e.Weight).HasMaxLength(125);

            entity.HasOne(d => d.CourseType).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CourseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_CourseType");
        });

        modelBuilder.Entity<CourseGroup>(entity =>
        {
            entity.HasKey(e => e.CourseGroupId).HasName("PK__CourseGr__E9E863F09E615749");

            entity.ToTable("CourseGroup", tb => tb.HasTrigger("TG_CourseGroup_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<CourseGroupStudent>(entity =>
        {
            entity.HasKey(e => e.CourseGroupStudentId).HasName("PK__CourseGr__ACD48B4B6C1A87FD");

            entity.ToTable("CourseGroup_Student", tb => tb.HasTrigger("TG_CourseGroup_Student_Update"));

            entity.Property(e => e.CourseGroupStudentId).HasColumnName("CourseGroup_StudentId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.CourseGroup).WithMany(p => p.CourseGroupStudents)
                .HasForeignKey(d => d.CourseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_Student_CourseGroupId");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseGroupStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_Student_StudentId");
        });

        modelBuilder.Entity<CourseGroupStudentGroup>(entity =>
        {
            entity.HasKey(e => e.CourseGroupStudentGroupId).HasName("PK__CourseGr__C9DD5CEE69B631AF");

            entity.ToTable("CourseGroup_StudentGroup", tb => tb.HasTrigger("TG_CourseGroup_StudentGroup_Update"));

            entity.Property(e => e.CourseGroupStudentGroupId).HasColumnName("CourseGroup_StudentGroupId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.CourseGroup).WithMany(p => p.CourseGroupStudentGroups)
                .HasForeignKey(d => d.CourseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_StudentGroup_CourseGroupId");

            entity.HasOne(d => d.StudentGroup).WithMany(p => p.CourseGroupStudentGroups)
                .HasForeignKey(d => d.StudentGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_StudentGroup_StudentGroupId");
        });

        modelBuilder.Entity<CourseGroupTeacher>(entity =>
        {
            entity.HasKey(e => e.CourseGroupTeacherId).HasName("PK__CourseGr__7894AB1ACF222FBD");

            entity.ToTable("CourseGroup_Teacher", tb => tb.HasTrigger("TG_CourseGroup_Teacher_Update"));

            entity.Property(e => e.CourseGroupTeacherId).HasColumnName("CourseGroup_TeacherId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.CourseGroup).WithMany(p => p.CourseGroupTeachers)
                .HasForeignKey(d => d.CourseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_Teacher_CourseGroupId");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CourseGroupTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_Teacher_TeacherId");
        });

        modelBuilder.Entity<CourseGroupTeacherGroup>(entity =>
        {
            entity.HasKey(e => e.CourseGroupTeacherGroupId).HasName("PK__CourseGr__CBD36004FA560BF4");

            entity.ToTable("CourseGroup_TeacherGroup", tb => tb.HasTrigger("TG_CourseGroup_TeacherGroup_Update"));

            entity.Property(e => e.CourseGroupTeacherGroupId).HasColumnName("CourseGroup_TeacherGroupId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.CourseGroup).WithMany(p => p.CourseGroupTeacherGroups)
                .HasForeignKey(d => d.CourseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_TeacherGroup_CourseGroupId");

            entity.HasOne(d => d.TeacherGroup).WithMany(p => p.CourseGroupTeacherGroups)
                .HasForeignKey(d => d.TeacherGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseGroup_TeacherGroup_TeacherGroupId");
        });

        modelBuilder.Entity<CourseTrajectory>(entity =>
        {
            entity.HasKey(e => e.CourseTrajectoryId).HasName("PK__CourseTr__319C14EFD729B1A5");

            entity.ToTable("CourseTrajectory", tb => tb.HasTrigger("TG_CourseTrajectory_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseTrajectories)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseTrajectory_Course");

            entity.HasOne(d => d.Trajectory).WithMany(p => p.CourseTrajectories)
                .HasForeignKey(d => d.TrajectoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseTrajectory_Trajectory");
        });

        modelBuilder.Entity<CourseType>(entity =>
        {
            entity.HasKey(e => e.CourseTypeId).HasName("PK__CourseTy__81736972E7E413FB");

            entity.ToTable("CourseType", tb => tb.HasTrigger("TG_CourseType_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(512);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE3805A368A457");

            entity.ToTable("Education", tb => tb.HasTrigger("TG_Education_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.InfoId).HasName("PK__Info__4DEC9D7AAB4759B6");

            entity.ToTable("Info", tb => tb.HasTrigger("TG_Info_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Concept).WithMany(p => p.Infos)
                .HasForeignKey(d => d.ConceptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Info_Concept");

            entity.HasOne(d => d.InfoType).WithMany(p => p.Infos)
                .HasForeignKey(d => d.InfoTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Info_InfoTypeId");
        });

        modelBuilder.Entity<InfoType>(entity =>
        {
            entity.HasKey(e => e.InfoTypeId).HasName("PK__InfoType__E94AB52440DB0ADB");

            entity.ToTable("InfoType", tb => tb.HasTrigger("TG_InfoType_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Internship>(entity =>
        {
            entity.HasKey(e => e.InternshipId).HasName("PK__Internsh__01ADE5BBF813E51B");

            entity.ToTable("Internship", tb => tb.HasTrigger("TG_Internship_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Company).WithMany(p => p.Internships)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Internship_Company");

            entity.HasOne(d => d.Education).WithMany(p => p.Internships)
                .HasForeignKey(d => d.EducationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Internship_Education");
        });

        modelBuilder.Entity<InternshipContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Internship_Contact", tb => tb.HasTrigger("TG_Internship_Contact_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Contact).WithMany()
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Internship_Contact_Contact");

            entity.HasOne(d => d.Internship).WithMany()
                .HasForeignKey(d => d.InternshipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Internship_Contact_Internship");
        });

        modelBuilder.Entity<Ioem>(entity =>
        {
            entity.HasKey(e => e.Ioemid).HasName("PK__IOEM__AA343AAE87633AFE");

            entity.ToTable("IOEM", tb => tb.HasTrigger("TG_IOEM_Update"));

            entity.Property(e => e.Ioemid).HasColumnName("IOEMId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Detail).HasMaxLength(512);
            entity.Property(e => e.ShortName).HasMaxLength(125);
            entity.Property(e => e.Title).HasMaxLength(125);
        });

        modelBuilder.Entity<LearningOutcome>(entity =>
        {
            entity.HasKey(e => e.LearningOutcomeId).HasName("PK__Learning__05E3E2593122537B");

            entity.ToTable("LearningOutcome", tb => tb.HasTrigger("TG_LearningOutcome_Update"));

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6BD852CAE").IsUnique();

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);

            entity.HasOne(d => d.LearningOutcomeType).WithMany(p => p.LearningOutcomes)
                .HasForeignKey(d => d.LearningOutcomeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LearningOutcome_LearningOutcomeType");
        });

        modelBuilder.Entity<LearningOutcomeType>(entity =>
        {
            entity.HasKey(e => e.LearningOutcomeTypeId).HasName("PK__Learning__45AB90423B7A619D");

            entity.ToTable("LearningOutcomeType", tb => tb.HasTrigger("TG_LearningOutcomeType_Update"));

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6F61E3239").IsUnique();

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<LearningTarget>(entity =>
        {
            entity.HasKey(e => e.LearningTargetId).HasName("PK__Learning__0DD376A92A95ED09");

            entity.ToTable("LearningTarget", tb => tb.HasTrigger("TG_LearningTarget_Update"));

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6084861A1").IsUnique();

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);

            entity.HasOne(d => d.ControlLevel).WithMany(p => p.LearningTargets)
                .HasForeignKey(d => d.ControlLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LearningTarget_ControlLevel");

            entity.HasOne(d => d.LearningOutcome).WithMany(p => p.LearningTargets)
                .HasForeignKey(d => d.LearningOutcomeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LearningTarget_LearningOutcome");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497D760FB14");

            entity.ToTable("Location", tb => tb.HasTrigger("TG_Location_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);

            entity.HasOne(d => d.Campus).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_Campus");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Period__E521BB16A9CC0F69");

            entity.ToTable("Period", tb => tb.HasTrigger("TG_Period_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB858FD26A37");

            entity.ToTable("Person", tb => tb.HasTrigger("TG_Person_Update"));

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Mobile).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.SortName).HasMaxLength(255);

            entity.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Person_Address");
        });

        modelBuilder.Entity<Presence>(entity =>
        {
            entity.HasKey(e => e.PresenceId).HasName("PK__Presence__4980E86396FD33A9");

            entity.ToTable("Presence");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Qrcode)
                .HasMaxLength(512)
                .HasColumnName("QRCode");

            entity.HasOne(d => d.Person).WithMany(p => p.Presences)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presence_Person");

            entity.HasOne(d => d.PresenceState).WithMany(p => p.Presences)
                .HasForeignKey(d => d.PresenceStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presence_PresenceState");
        });

        modelBuilder.Entity<PresenceState>(entity =>
        {
            entity.HasKey(e => e.PresenceStateId).HasName("PK__Presence__41336BB83F33C500");

            entity.ToTable("PresenceState");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<RegistrationState>(entity =>
        {
            entity.HasKey(e => e.RegistrationStateId).HasName("PK__Registra__7504BB5A32ADF3D8");

            entity.ToTable("RegistrationState", tb => tb.HasTrigger("TG_RegistrationState_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863939C7681699");

            entity.ToTable("Room", tb => tb.HasTrigger("TG_Room_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Building");

            entity.HasOne(d => d.RoomKind).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomKindId)
                .HasConstraintName("FK_Room_RoomKind");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_Room_RoomType");
        });

        modelBuilder.Entity<RoomKind>(entity =>
        {
            entity.HasKey(e => e.RoomKindId).HasName("PK__RoomKind__6B8E0CD0B500BB6E");

            entity.ToTable("RoomKind", tb => tb.HasTrigger("TG_RoomKind_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8963176D6A1EC");

            entity.ToTable("RoomType", tb => tb.HasTrigger("TG_RoomType_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<Rubric>(entity =>
        {
            entity.HasKey(e => e.RubricId).HasName("PK__Rubric__8F6D078155F10827");

            entity.ToTable("Rubric");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.MaxScore).HasDefaultValueSql("((20))");
        });

        modelBuilder.Entity<RubricColumn>(entity =>
        {
            entity.HasKey(e => e.RubricColumnId).HasName("PK__RubricCo__2F7329F0F7A28EEC");

            entity.ToTable("RubricColumn");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<RubricInstance>(entity =>
        {
            entity.HasKey(e => e.RubricInstanceId).HasName("PK__RubricIn__261E36A3939025AB");

            entity.ToTable("RubricInstance");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AuthorPerson).WithMany(p => p.RubricInstanceAuthorPeople)
                .HasForeignKey(d => d.AuthorPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstance_AuthorPersonId");

            entity.HasOne(d => d.Rubric).WithMany(p => p.RubricInstances)
                .HasForeignKey(d => d.RubricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstance_Rubric");

            entity.HasOne(d => d.ScorePerson).WithMany(p => p.RubricInstanceScorePeople)
                .HasForeignKey(d => d.ScorePersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstance_ScorePersonId");
        });

        modelBuilder.Entity<RubricInstanceScore>(entity =>
        {
            entity.HasKey(e => e.RubricInstanceScoreId).HasName("PK__RubricIn__4640687916CBB9A2");

            entity.ToTable("RubricInstanceScore");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Score).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.RubricInstance).WithMany(p => p.RubricInstanceScores)
                .HasForeignKey(d => d.RubricInstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstanceScore_RubricInstance");

            entity.HasOne(d => d.RubricRubricColumn).WithMany(p => p.RubricInstanceScores)
                .HasForeignKey(d => d.RubricRubricColumnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstanceScore_RubricColumn");

            entity.HasOne(d => d.RubricRubricRow).WithMany(p => p.RubricInstanceScores)
                .HasForeignKey(d => d.RubricRubricRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricInstanceScore_RubricRow");
        });

        modelBuilder.Entity<RubricRow>(entity =>
        {
            entity.HasKey(e => e.RubricRowId).HasName("PK__RubricRo__A7062D351A47C1D0");

            entity.ToTable("RubricRow");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.MaxScore).HasDefaultValueSql("((20))");
        });

        modelBuilder.Entity<RubricRowHeader>(entity =>
        {
            entity.HasKey(e => e.RubricRowHeaderId).HasName("PK__RubricRo__BDC4FFB98CD0F20C");

            entity.ToTable("RubricRowHeader");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).IsUnicode(false);

            entity.HasOne(d => d.RubricRowHeaderParent).WithMany(p => p.InverseRubricRowHeaderParent)
                .HasForeignKey(d => d.RubricRowHeaderParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RubricRowHeader_RubricRowHeader");
        });

        modelBuilder.Entity<RubricRubricColumn>(entity =>
        {
            entity.HasKey(e => e.RubricRubricColumnId).HasName("PK__Rubric_R__A1AE8720E08B99D6");

            entity.ToTable("Rubric_RubricColumn");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.RubricColumn).WithMany(p => p.RubricRubricColumns)
                .HasForeignKey(d => d.RubricColumnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricColumn_RubricColumn");

            entity.HasOne(d => d.RubricHeader).WithMany(p => p.RubricRubricColumns)
                .HasForeignKey(d => d.RubricHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricColumn_RubricRowHeader");

            entity.HasOne(d => d.Rubric).WithMany(p => p.RubricRubricColumns)
                .HasForeignKey(d => d.RubricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricColumn_Rubric");
        });

        modelBuilder.Entity<RubricRubricRow>(entity =>
        {
            entity.HasKey(e => e.RubricRubricRowId).HasName("PK__Rubric_R__248037BFFBD16491");

            entity.ToTable("Rubric_RubricRow");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Rubric).WithMany(p => p.RubricRubricRows)
                .HasForeignKey(d => d.RubricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricRow_Rubric");

            entity.HasOne(d => d.RubricRow).WithMany(p => p.RubricRubricRows)
                .HasForeignKey(d => d.RubricRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricRow_RubricRow");
        });

        modelBuilder.Entity<RubricRubricRowHeader>(entity =>
        {
            entity.HasKey(e => e.RubricRubricRowHeaderId).HasName("PK__Rubric_R__92D93916BE8F8C52");

            entity.ToTable("Rubric_RubricRowHeader");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.Rubric).WithMany(p => p.RubricRubricRowHeaders)
                .HasForeignKey(d => d.RubricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricRowHeader_Rubric");

            entity.HasOne(d => d.RubricRowHeader).WithMany(p => p.RubricRubricRowHeaders)
                .HasForeignKey(d => d.RubricRowHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rubric_RubricRowHeader_RubricRowHeader");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B49EA0A137E");

            entity.ToTable("Schedule", tb => tb.HasTrigger("TG_Schedule_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.CourseGroup).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.CourseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_CourseGroup");

            entity.HasOne(d => d.Course).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Course");

            entity.HasOne(d => d.Room).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Room");

            entity.HasOne(d => d.SchedulingTimeslot).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SchedulingTimeslotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Timeslot");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Teacher");
        });

        modelBuilder.Entity<SchedulingTimeslot>(entity =>
        {
            entity.HasKey(e => e.SchedulingTimeslotId).HasName("PK__Scheduli__18163E442FF96D1D");

            entity.ToTable("SchedulingTimeslot", tb => tb.HasTrigger("TG_SchedulingTimeslot_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__Score__7DD229D13C7150AE");

            entity.ToTable("Score");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Total).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TotalPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Test).WithMany(p => p.Scores)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_Test");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99F07F646B");

            entity.ToTable("Student", tb => tb.HasTrigger("TG_Student_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Mobile).HasMaxLength(255);

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Person");

            entity.HasOne(d => d.RegistrationState).WithMany(p => p.Students)
                .HasForeignKey(d => d.RegistrationStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_RegistrationState");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.StudentGroupId).HasName("PK__StudentG__DCEA17E426DDE3C7");

            entity.ToTable("StudentGroup", tb => tb.HasTrigger("TG_StudentGroup_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<StudentIoem>(entity =>
        {
            entity.HasKey(e => e.StudentIoemid).HasName("PK__StudentI__F33128C3F20996D0");

            entity.ToTable("StudentIOEM", tb => tb.HasTrigger("TG_StudentIOEM_Update"));

            entity.Property(e => e.StudentIoemid).HasColumnName("StudentIOEMId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Ioemid).HasColumnName("IOEMId");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.StudentIoems)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentIOEM_AcademicYear");

            entity.HasOne(d => d.Ioem).WithMany(p => p.StudentIoems)
                .HasForeignKey(d => d.Ioemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentIOEM_IOEM");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentIoems)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentIOEM_Student");
        });

        modelBuilder.Entity<StudentStudentGroup>(entity =>
        {
            entity.HasKey(e => e.StudentStudentGroupId).HasName("PK__Student___F2A7506909C17B40");

            entity.ToTable("Student_StudentGroup", tb => tb.HasTrigger("TG_Student_StudentGroup_Update"));

            entity.Property(e => e.StudentStudentGroupId).HasColumnName("Student_StudentGroupId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.StudentGroup).WithMany(p => p.StudentStudentGroups)
                .HasForeignKey(d => d.StudentGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_StudentGroup_StudentGroup");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentStudentGroups)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_StudentGroup_Student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF2596429850731");

            entity.ToTable("Teacher", tb => tb.HasTrigger("TG_Teacher_Update"));

            entity.Property(e => e.Abbreviation)
                .HasMaxLength(10)
                .HasDefaultValueSql("('?')");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Mobile).HasMaxLength(255);
            entity.Property(e => e.RegistrationStateId).HasDefaultValueSql("((1))");
            entity.Property(e => e.TeacherTypeId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Person");

            entity.HasOne(d => d.RegistrationState).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.RegistrationStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_RegistrationState");

            entity.HasOne(d => d.TeacherType).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.TeacherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_TeacherType");
        });

        modelBuilder.Entity<TeacherAssignmentPercentageInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherAssignmentPercentageInterestId).HasName("PK__TeacherA__6E1EBD68B3BE44ED");

            entity.ToTable("TeacherAssignmentPercentageInterest", tb => tb.HasTrigger("TG_TeacherAssignmentPercentageInterest_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.TeacherAssignmentPercentageInterests)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherAssignmentPercentageInterest_AcademicYear");

            entity.HasOne(d => d.Period).WithMany(p => p.TeacherAssignmentPercentageInterests)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherAssignmentPercentageInterest_Period");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAssignmentPercentageInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherAssignmentPercentageInterest_Teacher");
        });

        modelBuilder.Entity<TeacherCoordinationRoleInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherCoordinationRoleInterestId).HasName("PK__TeacherC__7C49B476004BD0CC");

            entity.ToTable("TeacherCoordinationRoleInterest", tb => tb.HasTrigger("TG_TeacherCoordinationRoleInterest_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.TeacherCoordinationRoleInterests)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCoordinationRoleInterest_AcademicYear");

            entity.HasOne(d => d.CoordinationRole).WithMany(p => p.TeacherCoordinationRoleInterests)
                .HasForeignKey(d => d.CoordinationRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCoordinationRoleInterest_CoordinationRoleId");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherCoordinationRoleInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCoordinationRoleInterest_Teacher");

            entity.HasOne(d => d.TeacherPreference).WithMany(p => p.TeacherCoordinationRoleInterests)
                .HasForeignKey(d => d.TeacherPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCoordinationRoleInterest_TeacherPreference");
        });

        modelBuilder.Entity<TeacherCourseInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherCourseInterestId).HasName("PK__TeacherC__126AF6334B8FAE9E");

            entity.ToTable("TeacherCourseInterest", tb => tb.HasTrigger("TG_TeacherCourseInterest_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.TeacherCourseInterests)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCourseInterest_AcademicYear");

            entity.HasOne(d => d.Course).WithMany(p => p.TeacherCourseInterests)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCourseInterest_Course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherCourseInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCourseInterest_Teacher");

            entity.HasOne(d => d.TeacherPreference).WithMany(p => p.TeacherCourseInterests)
                .HasForeignKey(d => d.TeacherPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherCourseInterest_TeacherPreference");
        });

        modelBuilder.Entity<TeacherGroup>(entity =>
        {
            entity.HasKey(e => e.TeacherGroupId).HasName("PK__TeacherG__177624185770B1CD");

            entity.ToTable("TeacherGroup", tb => tb.HasTrigger("TG_TeacherGroup_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<TeacherInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherInterestId).HasName("PK__TeacherI__F7A67321FFF77E60");

            entity.ToTable("TeacherInterest", tb => tb.HasTrigger("TG_TeacherInterest_Update"));

            entity.Property(e => e.TeacherInterestId).ValueGeneratedNever();
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.TeacherInterests)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherInterest_AcademicYear");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherInterest_Teacher");
        });

        modelBuilder.Entity<TeacherLocationInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherLocationInterestId).HasName("PK__TeacherL__9D8ACF741D92D89F");

            entity.ToTable("TeacherLocationInterest", tb => tb.HasTrigger("TG_TeacherLocationInterest_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.AcademicYear).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_AcademicYear");

            entity.HasOne(d => d.Location).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_Course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_Teacher");

            entity.HasOne(d => d.TeacherPreference).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.TeacherPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_TeacherPreference");
        });

        modelBuilder.Entity<TeacherPreference>(entity =>
        {
            entity.HasKey(e => e.TeacherPreferenceId).HasName("PK__TeacherP__1D79322918918BED");

            entity.ToTable("TeacherPreference", tb => tb.HasTrigger("TG_TeacherPreference_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Preference).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TeacherTeacherGroup>(entity =>
        {
            entity.HasKey(e => e.TeacherTeacherGroupId).HasName("PK__Teacher___462932ECE8B1E706");

            entity.ToTable("Teacher_TeacherGroup", tb => tb.HasTrigger("TG_Teacher_TeacherGroup_Update"));

            entity.Property(e => e.TeacherTeacherGroupId).HasColumnName("Teacher_TeacherGroupId");
            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.TeacherGroup).WithMany(p => p.TeacherTeacherGroups)
                .HasForeignKey(d => d.TeacherGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_TeacherGroup_TeacherGroup");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherTeacherGroups)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_TeacherGroup_Teacher");
        });

        modelBuilder.Entity<TeacherType>(entity =>
        {
            entity.HasKey(e => e.TeacherTypeId).HasName("PK__TeacherT__9EF526A704BD8706");

            entity.ToTable("TeacherType", tb => tb.HasTrigger("TG_TeacherType_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).HasDefaultValueSql("('Temporary')");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__Test__8CC33160D8FD52E5");

            entity.ToTable("Test");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5D9B681CE1");

            entity.ToTable("Topic", tb => tb.HasTrigger("TG_Topic_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");

            entity.HasOne(d => d.TopicCategory).WithMany(p => p.Topics)
                .HasForeignKey(d => d.TopicCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Topic_TopicCategory");
        });

        modelBuilder.Entity<TopicCategory>(entity =>
        {
            entity.HasKey(e => e.TopicCategoryId).HasName("PK__TopicCat__ABEF72C47EB15DE7");

            entity.ToTable("TopicCategory", tb => tb.HasTrigger("TG_TopicCategory_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Description).HasMaxLength(512);
        });

        modelBuilder.Entity<Trajectory>(entity =>
        {
            entity.HasKey(e => e.TrajectoryId).HasName("PK__Trajecto__B6EA6AEAE7F8664C");

            entity.ToTable("Trajectory", tb => tb.HasTrigger("TG_Trajectory_Update"));

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
            entity.Property(e => e.Name).HasMaxLength(512);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
