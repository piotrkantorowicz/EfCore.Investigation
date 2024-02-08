# EfCore.Investigation

This is simple repository to help investigate potential issue with EntityFramework.Core. 

Getting started:
1. Clone the repository
2. Open the solution in your favorite IDE
3. Change a connection string in appsettings.json to point to your local database
4. Run the Init.sql script from the `Scripts` folder to populate database with some data
5. Uncomment the code in Program.cs witch the following basic scenarios to investigate (SingleOrDefaultAsync, FirstortDefaultAsync, ToListAsync)

```
// CASE 1: Query with SingleOrDefaultAsync - Throws InvalidOperationException with message: Sequence contains more than one element
//var permission = await dbContext.BudgetPermissions.SingleOrDefaultAsync();

// CASE 2: Query with FirstortDefaultAsync - Throws InvalidOperationException with message: Sequence contains no elements
//var permission = await dbContext.BudgetPermissions.FirstOrDefaultAsync();

// CASE 3: Query with ToListAsync - Query has been frozen and looping on BudgetPermission constructor
//var permissions = await dbContext.BudgetPermissions.ToListAsync();
```