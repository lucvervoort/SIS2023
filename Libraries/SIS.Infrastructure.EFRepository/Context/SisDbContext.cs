using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Infrastructure.EFRepository.Models;
using System.Linq.Expressions;

namespace SIS.Infrastructure.EFRepository.Context;

public partial class SisDbContext : GenSisDbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

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

        // SOFT DELETE

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // 1. Get or add the IsDeleted property if necessary
            var property = entityType.FindProperty("IsDeleted") ?? entityType.AddProperty("IsDeleted", typeof(bool));

            // 2. Create the query filter
            var parameter = Expression.Parameter(entityType.ClrType);

            var propertyMethodInfo = typeof(EF)?.GetMethod("Property")?.MakeGenericMethod(typeof(bool));
            if (propertyMethodInfo != null)
            {
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));


                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }

    public DbSet<TeacherNameDTO> TeacherNameDTO { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var runningMode = _configuration[key: "Mode"];
        // See manually set attribute/value in appsettings.json:
        if (!string.IsNullOrEmpty(runningMode) && runningMode.ToUpper().Equals("DEVELOPMENT"))
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
        }
        var activeConnectionString = _configuration[key: "ActiveConnectionString"];
        if (!string.IsNullOrEmpty(activeConnectionString))
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:" + activeConnectionString]);
        }
    }
}