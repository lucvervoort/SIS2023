using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Infrastructure.EFRepository.Models;
using System.Linq.Expressions;

namespace SIS.Infrastructure.EFRepository.Context;

public partial class SisDbContext : GenSisDbContext
{
    private readonly IConfiguration _configuration; // _ betekent local member
    private readonly ILoggerFactory _loggerFactory;

    // DI in Generic Host geeft de objecten door die de configuratie en de logging op zich nemen
    // en die standaard binnen Generic Host reeds ingevuld door Microsoft
    public SisDbContext(IConfiguration configuration, ILoggerFactory loggerFactory)
        : base()
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    public SisDbContext(DbContextOptions<GenSisDbContext> options, IConfiguration configuration, ILoggerFactory loggerFactory)
        : base(options)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // For RAW SQL queries...
        modelBuilder.Entity<TeacherNameDTO>().HasNoKey();

        /*
        // SOFT DELETE -- Reflection implementation
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // 1. Get or add the IsDeleted property if necessary
            var property = entityType.FindProperty("IsDeleted") ?? entityType.AddProperty("IsDeleted", typeof(bool));

            // 2. Create the query filter
            var parameter = Expression.Parameter(entityType.ClrType);

            // REFLECTION - voor supergevorderden - code die code schrijft en "bijplakt" terwijl je app draait
            var propertyMethodInfo = typeof(EF)?.GetMethod("Property")?.MakeGenericMethod(typeof(bool));
            if (propertyMethodInfo != null)
            {
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));
                var lambda = Expression.Lambda(compareExpression, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
        */
    }

    // SOFT DELETE - simple; if cascading deletes are required, more coding is needed, see e.g. https://github.com/JonPSmith/EfCore.SoftDeleteServices
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaveChanges();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        OnBeforeSaveChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnBeforeSaveChanges()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties()
            .Any(x => x.Name == "IsDeleted"))
            .ToList();

        foreach (var entity in entities)
        {
            entity.State = EntityState.Unchanged;
            entity.CurrentValues["IsDeleted"] = true;
        }
    }

    public DbSet<TeacherNameDTO> TeacherNameDTO { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // We roepen bewust base, de parent class, NIET op zodat enkel deze code actief is
        var runningMode = _configuration[key: "Mode"];
        // See manually set attribute/value in appsettings.json:
        if (!string.IsNullOrEmpty(runningMode) && runningMode.ToUpper().Equals("DEVELOPMENT"))
        {
            // We log extensively for EF when in Development mode
            optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
        }
        var activeConnectionString = _configuration[key: "ActiveConnectionString"];
        if (!string.IsNullOrEmpty(activeConnectionString))
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:" + activeConnectionString]);
        }
    }
}

// Alternative: https://github.com/JonPSmith/EfCore.SoftDeleteServices/tree/master/SoftDeleteServices/Concrete/Internal
