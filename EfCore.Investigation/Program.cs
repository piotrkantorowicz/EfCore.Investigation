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

// Init database by following sql:
/*
INSERT INTO "BudgetSharing"."BudgetPermissions"(
    "Id", "BudgetId", "OwnerId")
VALUES ('bd4a81f0-96cc-4337-8161-7a57209e9e64', 'f067106a-850f-455a-96ae-a8b5b3a17710', '5efce86f-664c-4064-80b4-84c0b7a6c2b4');

INSERT INTO "BudgetSharing"."Permission"(
    "BudgetPermissionId", "Id", "ParticipantId", "PermissionType")
VALUES ('bd4a81f0-96cc-4337-8161-7a57209e9e64', 1, '5efce86f-664c-4064-80b4-84c0b7a6c2b4', 1);
*/

// CASE 1: Query with SingleOrDefault - Throws InvalidOperationException with message: Sequence contains more than one element
//var permission = await dbContext.BudgetPermissions.SingleOrDefaultAsync();

// CASE 2: Query with FirstOrDefault - Throws InvalidOperationException with message: Sequence contains no elements
//var permission = await dbContext.BudgetPermissions.FirstOrDefaultAsync();

// CASE 3: Query with ToListAsync - Query has been frozen and looping on BudgetPermission constructor
//var permissions = await dbContext.BudgetPermissions.ToListAsync();

Console.WriteLine("Hello, World!");