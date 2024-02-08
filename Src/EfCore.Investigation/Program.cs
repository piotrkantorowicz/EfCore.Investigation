using EfCore.Investigation.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<BudgetSharingDbContext>();
optionsBuilder.UseNpgsql(connectionString);
var dbContext = new BudgetSharingDbContext(optionsBuilder.Options);
dbContext.Database.Migrate();

// CASE 1: Query with SingleOrDefault - Throws InvalidOperationException with message: Sequence contains more than one element
//var permission = await dbContext.BudgetPermissions.SingleOrDefaultAsync();

// CASE 2: Query with FirstOrDefault - Throws InvalidOperationException with message: Sequence contains no elements
//var permission = await dbContext.BudgetPermissions.FirstOrDefaultAsync();

// CASE 3: Query with ToListAsync - Query has been frozen and looping on BudgetPermission constructor
//var permissions = await dbContext.BudgetPermissions.ToListAsync();

Console.WriteLine("Hello, World!");