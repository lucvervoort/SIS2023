using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIS.Infrastructure.EFRepository.Models;

namespace SIS.Infrastructure.EFRepository.Context;

public partial class SisDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SisDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SisDbContext(DbContextOptions<SisDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Concept> Concepts { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<CoordinationRole> CoordinationRoles { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseGroup> CourseGroups { get; set; }

    public virtual DbSet<CourseGroupTeacher> CourseGroupTeachers { get; set; }

    public virtual DbSet<CourseGroupTeacherGroup> CourseGroupTeacherGroups { get; set; }

    public virtual DbSet<CourseGroupStudent> CourseGroupStudents { get; set; }

    public virtual DbSet<CourseGroupStudentGroup> CourseGroupStudentGroups { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<InfoType> InfoTypes { get; set; }

    public virtual DbSet<Internship> Internships { get; set; }

    public virtual DbSet<InternshipContact> InternshipContacts { get; set; }

    public virtual DbSet<Ioem> Ioems { get; set; }

    public virtual DbSet<LearningOutcome> LearningOutcomes { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAssignmentPercentageInterest> TeacherAssignmentPercentageInterests { get; set; }

    public virtual DbSet<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; }

    public virtual DbSet<TeacherCourseInterest> TeacherCourseInterests { get; set; }

    public virtual DbSet<TeacherGroup> TeacherGroups { get; set; }

    public virtual DbSet<TeacherInterest> TeacherInterests { get; set; }

    public virtual DbSet<TeacherTeacherGroup> TeacherTeacherGroups { get; set; }

    public virtual DbSet<TeacherLocationInterest> TeacherLocationInterests { get; set; }

    public virtual DbSet<TeacherPreference> TeacherPreferences { get; set; }

    public virtual DbSet<TeacherType> TeacherTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<RegistrationState> RegistrationStates { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomKind> RoomKinds { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<SchedulingTimeslot> SchedulingTimeslots { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<StudentIoem> StudentIoems { get; set; }

    public virtual DbSet<StudentStudentGroup> StudentStudentGroups { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<TopicCategory> TopicCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:ActiveCS"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicYearId).HasName("PK__Academic__C54C7A01112FFF3F");

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
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB7C99A850");

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
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC43A0BE3ED");

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
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598DD61CD268F7");

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
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC76CDF9F3");

            entity.ToTable("Company");

            entity.HasIndex(e => e.Phone, "UQ__Company__5C7E359E5139DBE7").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ__Company__6FAE0782C65FC871").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Company__A9D1053488C67A12").IsUnique();

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
            entity.HasKey(e => e.ConceptId).HasName("PK__Concept__515AA75662559DFD");

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
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259BED85DF17");

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

        modelBuilder.Entity<CoordinationRole>(entity =>
        {
            entity.HasKey(e => e.CoordinationRoleId).HasName("PK__Coordina__19EB71C153985313");

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
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FCD6F9983");

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
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7FCC8487B");

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
            entity.HasKey(e => e.CourseGroupId).HasName("PK__CourseGr__E9E863F09A393DF2");

            entity.ToTable("CourseGroup");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<CourseGroupTeacher>(entity =>
        {
            entity.HasKey(e => e.CourseGroupTeacherId).HasName("PK__CourseGr__7ADEC824241FC74F");

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
            entity.HasKey(e => e.CourseGroupTeacherGroupId).HasName("PK__CourseGr__20E6CB52A0A0553B");

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

        modelBuilder.Entity<CourseGroupStudent>(entity =>
        {
            entity.HasKey(e => e.CourseGroupStudentId).HasName("PK__CourseGr__ACD48B4BCE08A075");

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
            entity.HasKey(e => e.CourseGroupStudentGroupId).HasName("PK__CourseGr__C9DD5CEEB0D8AFC5");

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

        modelBuilder.Entity<CourseType>(entity =>
        {
            entity.HasKey(e => e.CourseTypeId).HasName("PK__CourseTy__817369724E39EC9E");

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
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE380560886EE8");

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
            entity.HasKey(e => e.InfoId).HasName("PK__Info__4DEC9D7A833B02BC");

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
            entity.HasKey(e => e.InfoTypeId).HasName("PK__InfoType__E94AB524D83DBDF7");

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
            entity.HasKey(e => e.InternshipId).HasName("PK__Internsh__01ADE5BBBE3AE470");

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
            entity.HasKey(e => e.Ioemid).HasName("PK__IOEM__AA343AAED94B8C8E");

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
            entity.HasKey(e => e.LearningOutcomeId).HasName("PK__Learning__05E3E259865CAE49");

            entity.ToTable("LearningOutcome");

            entity.Property(e => e.AutoTimeCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_CREATION");
            entity.Property(e => e.AutoTimeUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("AUTO_TIME_UPDATE");
            entity.Property(e => e.AutoUpdateCount).HasColumnName("AUTO_UPDATE_COUNT");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__75D607A28ACD39E7");

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
            entity.Property(e => e.TeacherTypeId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mobile).HasMaxLength(255);
            entity.Property(e => e.RegistrationStateId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.TeacherType).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.TeacherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_TeacherType");

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Person");

            entity.HasOne(d => d.RegistrationState).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.RegistrationStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_RegistrationState");
        });

        modelBuilder.Entity<TeacherAssignmentPercentageInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherAssignmentPercentageInterestId).HasName("PK__TeacherAs__5433DF836B08E20E");

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

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAssignmentPercentageInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherAssignmentPercentageInterest_Teacher");

            entity.HasOne(d => d.Period).WithMany(p => p.TeacherAssignmentPercentageInterests)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherAssignmentPercentageInterest_Period");
        });

        modelBuilder.Entity<TeacherCoordinationRoleInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherCoordinationRoleInterestId).HasName("PK__TeacherCo__A3BC1AA572ABAA09");

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
            entity.HasKey(e => e.TeacherCourseInterestId).HasName("PK__TeacherCo__DD0E8E110AEB4014");

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
            entity.HasKey(e => e.TeacherGroupId).HasName("PK__TeacherGr__688D3759E16BEE4D");

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
            entity.HasKey(e => e.TeacherInterestId).HasName("PK__TeacherIn__EAC3F57D3BD9DC8B");

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

        modelBuilder.Entity<TeacherTeacherGroup>(entity =>
        {
            entity.HasKey(e => e.TeacherTeacherGroupId).HasName("PK__Teacher_L__21D2FF4743F32450");

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

        modelBuilder.Entity<TeacherLocationInterest>(entity =>
        {
            entity.HasKey(e => e.TeacherLocationInterestId).HasName("PK__TeacherLo__860FCA9315512128");

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

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_Teacher");

            entity.HasOne(d => d.TeacherPreference).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.TeacherPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_TeacherPreference");

            entity.HasOne(d => d.Location).WithMany(p => p.TeacherLocationInterests)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherLocationInterest_Course");
        });

        modelBuilder.Entity<TeacherPreference>(entity =>
        {
            entity.HasKey(e => e.TeacherPreferenceId).HasName("PK__TeacherPr__846636AFCD0A8972");

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

        modelBuilder.Entity<TeacherType>(entity =>
        {
            entity.HasKey(e => e.TeacherTypeId).HasName("PK__TeacherTy__89621148F8EE5498");

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

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497997FD72A");

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
            entity.HasKey(e => e.PeriodId).HasName("PK__Period__E521BB164204F580");

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
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB8551E023F2");

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

            entity.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Person_Address");
        });

        modelBuilder.Entity<RegistrationState>(entity =>
        {
            entity.HasKey(e => e.RegistrationStateId).HasName("PK__Registra__7504BB5A8FD958CC");

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
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863939A9F29D11");

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
            entity.HasKey(e => e.RoomKindId).HasName("PK__RoomKind__6B8E0CD01EDA7F4A");

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
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8963198F8EC6F");

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

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B496828D846");

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

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Teacher");

            entity.HasOne(d => d.Room).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Room");

            entity.HasOne(d => d.SchedulingTimeslot).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SchedulingTimeslotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scheduling_Timeslot");
        });

        modelBuilder.Entity<SchedulingTimeslot>(entity =>
        {
            entity.HasKey(e => e.SchedulingTimeslotId).HasName("PK__Scheduli__18163E44EEECDFD7");

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

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B994C954601");

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
            entity.HasKey(e => e.StudentGroupId).HasName("PK__StudentG__DCEA17E425A1C35B");

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
            entity.HasKey(e => e.StudentIoemid).HasName("PK__StudentI__F33128C3217CEFEC");

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
            entity.HasKey(e => e.StudentStudentGroupId).HasName("PK__Student___F2A75069F9445BDA");

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

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5DBA0BD313");

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
            entity.HasKey(e => e.TopicCategoryId).HasName("PK__TopicCat__ABEF72C4F07952C3");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
