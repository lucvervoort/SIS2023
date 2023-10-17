using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Infrastructure.EFRepository.Models;

namespace SIS.Infrastructure.EFRepository.Context;

public partial class SisDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    // TODO LVET: inherit from this class to be able to regenerate code
    public SisDbContext(IConfiguration configuration)
    {
       _configuration = configuration;
    }

    public SisDbContext(DbContextOptions<SisDbContext> options, ILogger<SisDbContext> logger, IConfiguration configuration)
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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:ActiveCS"] /*"Data Source=localhost,3025;Initial Catalog=SIS_DVLP;Persist Security Info=True;User ID=sis;TrustServerCertificate=True;Password=ZwarteRidder007"*/);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicYearId).HasName("PK__Academic__C54C7A01A7828BCF");

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
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB0A3C6752");

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
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC4F2736BB9");

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
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598DD6503D992C");

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
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC4EE27DBD");

            entity.ToTable("Company");

            entity.HasIndex(e => e.Phone, "UQ__Company__5C7E359E1EFD3A5A").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ__Company__6FAE0782F1202C23").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Company__A9D10534415D0534").IsUnique();

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
            entity.HasKey(e => e.ConceptId).HasName("PK__Concept__515AA756F8A33E9D");

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
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259B7F73495D");

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
            entity.HasKey(e => e.ControlLevelId).HasName("PK__ControlL__5CDF013ADE012873");

            entity.ToTable("ControlLevel");

            entity.HasIndex(e => e.Name, "UQ__ControlL__737584F63D9C9FA6").IsUnique();

            entity.HasIndex(e => e.Abbreviation, "UQ__ControlL__9C41170E4C2AD42A").IsUnique();

            entity.Property(e => e.Abbreviation).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(125);
        });

        modelBuilder.Entity<CoordinationRole>(entity =>
        {
            entity.HasKey(e => e.CoordinationRoleId).HasName("PK__Coordina__19EB71C1660CA97F");

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
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609F043A357E");

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
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7F296C1BB");

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
            entity.HasKey(e => e.CourseGroupId).HasName("PK__CourseGr__E9E863F0F2440A67");

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
            entity.HasKey(e => e.CourseGroupStudentId).HasName("PK__CourseGr__ACD48B4BC54A479F");

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
            entity.HasKey(e => e.CourseGroupStudentGroupId).HasName("PK__CourseGr__C9DD5CEE24294D58");

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
            entity.HasKey(e => e.CourseGroupTeacherId).HasName("PK__CourseGr__7894AB1A19AEDD9A");

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
            entity.HasKey(e => e.CourseGroupTeacherGroupId).HasName("PK__CourseGr__CBD3600483B03EF3");

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
            entity.HasKey(e => e.CourseTrajectoryId).HasName("PK__CourseTr__319C14EF748B97DB");

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
            entity.HasKey(e => e.CourseTypeId).HasName("PK__CourseTy__81736972296ACD5F");

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
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE38055533CF83");

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
            entity.HasKey(e => e.InfoId).HasName("PK__Info__4DEC9D7A4FD4B042");

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
            entity.HasKey(e => e.InfoTypeId).HasName("PK__InfoType__E94AB52431BE968A");

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
            entity.HasKey(e => e.InternshipId).HasName("PK__Internsh__01ADE5BB50F8BE44");

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
            entity.HasKey(e => e.Ioemid).HasName("PK__IOEM__AA343AAE5969F6E1");

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
            entity.HasKey(e => e.LearningOutcomeId).HasName("PK__Learning__05E3E259A6C1BB2D");

            entity.ToTable("LearningOutcome");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F62769CD8D").IsUnique();

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
            entity.HasKey(e => e.LearningOutcomeTypeId).HasName("PK__Learning__45AB9042E33C724A");

            entity.ToTable("LearningOutcomeType");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F685E09814").IsUnique();

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
            entity.HasKey(e => e.LearningTargetId).HasName("PK__Learning__0DD376A9A9805EB3");

            entity.ToTable("LearningTarget");

            entity.HasIndex(e => e.Name, "UQ__Learning__737584F6C62CE9D5").IsUnique();

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
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4975315DF06");

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
            entity.HasKey(e => e.PeriodId).HasName("PK__Period__E521BB16C5097570");

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
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB85EE334AE7");

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
            entity.HasKey(e => e.PresenceId).HasName("PK__Presence__4980E86346B5A491");

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
            entity.HasKey(e => e.PresenceStateId).HasName("PK__Presence__41336BB887483A81");

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
            entity.HasKey(e => e.RegistrationStateId).HasName("PK__Registra__7504BB5A6DA6B2DE");

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
            entity.HasKey(e => e.RoomId).HasName("PK__Room__3286393970967D8E");

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
            entity.HasKey(e => e.RoomKindId).HasName("PK__RoomKind__6B8E0CD03208713C");

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
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8963172368CD3");

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
            entity.HasKey(e => e.RubricId).HasName("PK__Rubric__8F6D07815F4AECBD");

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
            entity.HasKey(e => e.RubricColumnId).HasName("PK__RubricCo__2F7329F0F9523862");

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
            entity.HasKey(e => e.RubricInstanceId).HasName("PK__RubricIn__261E36A36DCE4068");

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
            entity.HasKey(e => e.RubricInstanceScoreId).HasName("PK__RubricIn__46406879303D549F");

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
            entity.HasKey(e => e.RubricRowId).HasName("PK__RubricRo__A7062D35BABC2F6A");

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
            entity.HasKey(e => e.RubricRowHeaderId).HasName("PK__RubricRo__BDC4FFB90C24DE2E");

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
            entity.HasKey(e => e.RubricRubricColumnId).HasName("PK__Rubric_R__A1AE8720BAD9AB20");

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
            entity.HasKey(e => e.RubricRubricRowId).HasName("PK__Rubric_R__248037BFFA655A87");

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
            entity.HasKey(e => e.RubricRubricRowHeaderId).HasName("PK__Rubric_R__92D939166C1FD674");

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
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B491A25BD22");

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
            entity.HasKey(e => e.SchedulingTimeslotId).HasName("PK__Scheduli__18163E44AA8266F1");

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
            entity.HasKey(e => e.ScoreId).HasName("PK__Score__7DD229D1439D7838");

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
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99294C8AB8");

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
            entity.HasKey(e => e.StudentGroupId).HasName("PK__StudentG__DCEA17E4BC03E303");

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
            entity.HasKey(e => e.StudentIoemid).HasName("PK__StudentI__F33128C3C679381B");

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
            entity.HasKey(e => e.StudentStudentGroupId).HasName("PK__Student___F2A75069F4787607");

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
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF25964B0005226");

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
            entity.HasKey(e => e.TeacherAssignmentPercentageInterestId).HasName("PK__TeacherA__6E1EBD685E43991C");

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
            entity.HasKey(e => e.TeacherCoordinationRoleInterestId).HasName("PK__TeacherC__7C49B476B1267665");

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
            entity.HasKey(e => e.TeacherCourseInterestId).HasName("PK__TeacherC__126AF633918FA021");

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
            entity.HasKey(e => e.TeacherGroupId).HasName("PK__TeacherG__177624189A9808E8");

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
            entity.HasKey(e => e.TeacherInterestId).HasName("PK__TeacherI__F7A673212EBD563D");

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
            entity.HasKey(e => e.TeacherLocationInterestId).HasName("PK__TeacherL__9D8ACF74C878CF04");

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
            entity.HasKey(e => e.TeacherPreferenceId).HasName("PK__TeacherP__1D793229F7B26E32");

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
            entity.HasKey(e => e.TeacherTeacherGroupId).HasName("PK__Teacher___462932EC47FAE504");

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
            entity.HasKey(e => e.TeacherTypeId).HasName("PK__TeacherT__9EF526A7CCBC1DD0");

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
            entity.HasKey(e => e.TestId).HasName("PK__Test__8CC331600C352C89");

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
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5D9B211155");

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
            entity.HasKey(e => e.TopicCategoryId).HasName("PK__TopicCat__ABEF72C4C913A5EA");

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
            entity.HasKey(e => e.TrajectoryId).HasName("PK__Trajecto__B6EA6AEA03B1F955");

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
