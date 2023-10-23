﻿using System;
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
            entity.HasKey(e => e.AcademicYearId).HasName("PK__Academic__C54C7A0157188A87");

            entity.ToTable("AcademicYear");

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
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB5E9364C9");

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
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC4A692480B");

            entity.ToTable("Building");

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
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598DD600295A9B");

            entity.ToTable("Campus");

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
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC4F1AD937");

            entity.ToTable("Company");

            entity.HasIndex(e => e.Phone, "UQ__Company__5C7E359E1AA940BB").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ__Company__6FAE078292D21510").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Company__A9D105342BDB4DCA").IsUnique();

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
            entity.HasKey(e => e.ConceptId).HasName("PK__Concept__515AA756EF74298B");

            entity.ToTable("Concept");

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
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259BDF3D887B");

            entity.ToTable("Contact");

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
            entity.HasKey(e => e.ControlLevelId).HasName("PK__ControlL__5CDF013AA7D4C75B");

            entity.ToTable("ControlLevel");

            entity.HasIndex(e => e.Name, "UQ__ControlL__737584F6BEBFF6AA").IsUnique();

            entity.HasIndex(e => e.Abbreviation, "UQ__ControlL__9C41170EF590C82B").IsUnique();

            entity.Property(e => e.Abbreviation).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<CoordinationRole>(entity =>
        {
            entity.HasKey(e => e.CoordinationRoleId).HasName("PK__Coordina__19EB71C1F0DEC996");

            entity.ToTable("CoordinationRole");

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
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FB6D3508B");

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
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A71AA7A70C");

            entity.ToTable("Course");

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
            entity.HasKey(e => e.CourseGroupId).HasName("PK__CourseGr__E9E863F07F6ADFD9");

            entity.ToTable("CourseGroup");

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
            entity.HasKey(e => e.CourseGroupStudentId).HasName("PK__CourseGr__ACD48B4BB5A6FFA2");

            entity.ToTable("CourseGroup_Student");

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
            entity.HasKey(e => e.CourseGroupStudentGroupId).HasName("PK__CourseGr__C9DD5CEEB856583D");

            entity.ToTable("CourseGroup_StudentGroup");

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
            entity.HasKey(e => e.CourseGroupTeacherId).HasName("PK__CourseGr__7894AB1A12CBCF65");

            entity.ToTable("CourseGroup_Teacher");

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
            entity.HasKey(e => e.CourseGroupTeacherGroupId).HasName("PK__CourseGr__CBD360048A449185");

            entity.ToTable("CourseGroup_TeacherGroup");

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
            entity.HasKey(e => e.CourseTrajectoryId).HasName("PK__CourseTr__319C14EFB84617BD");

            entity.ToTable("CourseTrajectory");

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
            entity.HasKey(e => e.CourseTypeId).HasName("PK__CourseTy__8173697216DBD006");

            entity.ToTable("CourseType");

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
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE380515176863");

            entity.ToTable("Education");

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
            entity.HasKey(e => e.InfoId).HasName("PK__Info__4DEC9D7ACEA15BBA");

            entity.ToTable("Info");

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
            entity.HasKey(e => e.InfoTypeId).HasName("PK__InfoType__E94AB52458F05E24");

            entity.ToTable("InfoType");

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
            entity.HasKey(e => e.InternshipId).HasName("PK__Internsh__01ADE5BBD647DA87");

            entity.ToTable("Internship");

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
                .ToTable("Internship_Contact");

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
            entity.HasKey(e => e.Ioemid).HasName("PK__IOEM__AA343AAE988CFA06");

            entity.ToTable("IOEM");

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
            entity.HasKey(e => e.LearningOutcomeId).HasName("PK__Learning__05E3E259BD14B854");

            entity.ToTable("LearningOutcome");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6ABEA74EE").IsUnique();

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
            entity.HasKey(e => e.LearningOutcomeTypeId).HasName("PK__Learning__45AB9042C5597178");

            entity.ToTable("LearningOutcomeType");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F68A7EBE3B").IsUnique();

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
            entity.HasKey(e => e.LearningTargetId).HasName("PK__Learning__0DD376A9E129E6A4");

            entity.ToTable("LearningTarget");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6E9E99A15").IsUnique();

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
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA49798B896F1");

            entity.ToTable("Location");

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
            entity.HasKey(e => e.PeriodId).HasName("PK__Period__E521BB16C43C2337");

            entity.ToTable("Period");

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
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB857101B608");

            entity.ToTable("Person");

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
            entity.HasKey(e => e.PresenceId).HasName("PK__Presence__4980E863D8174AFE");

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
            entity.HasKey(e => e.PresenceStateId).HasName("PK__Presence__41336BB830135F17");

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
            entity.HasKey(e => e.RegistrationStateId).HasName("PK__Registra__7504BB5AB6E67273");

            entity.ToTable("RegistrationState");

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
            entity.HasKey(e => e.RoomId).HasName("PK__Room__3286393918185080");

            entity.ToTable("Room");

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
            entity.HasKey(e => e.RoomKindId).HasName("PK__RoomKind__6B8E0CD09D5DD858");

            entity.ToTable("RoomKind");

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
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC896312B8F65B4");

            entity.ToTable("RoomType");

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
            entity.HasKey(e => e.RubricId).HasName("PK__Rubric__8F6D0781651E2575");

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
            entity.HasKey(e => e.RubricColumnId).HasName("PK__RubricCo__2F7329F0C538772F");

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
            entity.HasKey(e => e.RubricInstanceId).HasName("PK__RubricIn__261E36A3953DE3ED");

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

        modelBuilder.Entity<RubricRow>(entity =>
        {
            entity.HasKey(e => e.RubricRowId).HasName("PK__RubricRo__A7062D356E407246");

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
            entity.HasKey(e => e.RubricRowHeaderId).HasName("PK__RubricRo__BDC4FFB924E6FE56");

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
            entity.HasKey(e => e.RubricRubricColumnId).HasName("PK__Rubric_R__A1AE87209F9C7245");

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
            entity.HasKey(e => e.RubricRubricRowId).HasName("PK__Rubric_R__248037BF3F2A4247");

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
            entity.HasKey(e => e.RubricRubricRowHeaderId).HasName("PK__Rubric_R__92D939160AD9D686");

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
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B491B6EBFF0");

            entity.ToTable("Schedule");

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
            entity.HasKey(e => e.SchedulingTimeslotId).HasName("PK__Scheduli__18163E447AC79AB1");

            entity.ToTable("SchedulingTimeslot");

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
            entity.HasKey(e => e.ScoreId).HasName("PK__Score__7DD229D1556EF398");

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
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B997DB60FAC");

            entity.ToTable("Student");

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
            entity.HasKey(e => e.StudentGroupId).HasName("PK__StudentG__DCEA17E4A66BB66C");

            entity.ToTable("StudentGroup");

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
            entity.HasKey(e => e.StudentIoemid).HasName("PK__StudentI__F33128C31D7DB7D0");

            entity.ToTable("StudentIOEM");

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
            entity.HasKey(e => e.StudentStudentGroupId).HasName("PK__Student___F2A75069E1F8EC14");

            entity.ToTable("Student_StudentGroup");

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
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF2596495A54140");

            entity.ToTable("Teacher");

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
            entity.HasKey(e => e.TeacherAssignmentPercentageInterestId).HasName("PK__TeacherA__6E1EBD68E498A4AC");

            entity.ToTable("TeacherAssignmentPercentageInterest");

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
            entity.HasKey(e => e.TeacherCoordinationRoleInterestId).HasName("PK__TeacherC__7C49B4768906D018");

            entity.ToTable("TeacherCoordinationRoleInterest");

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
            entity.HasKey(e => e.TeacherCourseInterestId).HasName("PK__TeacherC__126AF633717A737B");

            entity.ToTable("TeacherCourseInterest");

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
            entity.HasKey(e => e.TeacherGroupId).HasName("PK__TeacherG__1776241860AB382D");

            entity.ToTable("TeacherGroup");

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
            entity.HasKey(e => e.TeacherInterestId).HasName("PK__TeacherI__F7A67321CA1E0C74");

            entity.ToTable("TeacherInterest");

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
            entity.HasKey(e => e.TeacherLocationInterestId).HasName("PK__TeacherL__9D8ACF74E9233E26");

            entity.ToTable("TeacherLocationInterest");

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
            entity.HasKey(e => e.TeacherPreferenceId).HasName("PK__TeacherP__1D79322938FEB289");

            entity.ToTable("TeacherPreference");

            entity.Property(e => e.TeacherPreferenceId).ValueGeneratedNever();
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
            entity.HasKey(e => e.TeacherTeacherGroupId).HasName("PK__Teacher___462932EC29F9E9E0");

            entity.ToTable("Teacher_TeacherGroup");

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
            entity.HasKey(e => e.TeacherTypeId).HasName("PK__TeacherT__9EF526A75A97C46C");

            entity.ToTable("TeacherType");

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
            entity.HasKey(e => e.TestId).HasName("PK__Test__8CC33160A973486E");

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
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5DA66C48F8");

            entity.ToTable("Topic");

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
            entity.HasKey(e => e.TopicCategoryId).HasName("PK__TopicCat__ABEF72C43B5523BD");

            entity.ToTable("TopicCategory");

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
            entity.HasKey(e => e.TrajectoryId).HasName("PK__Trajecto__B6EA6AEA2BCE64D3");

            entity.ToTable("Trajectory");

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