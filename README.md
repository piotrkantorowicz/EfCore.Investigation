# EfCore.Investigation

This is simple repository to help investigate potential issue with EntityFramework.Core. 

Getting started:
1. Clone the repository
2. Open the solution in your favorite IDE
3. Change a connection string in appsettings.json to point to your local database
4. Run the sql script from the `sql` folder to populate database with some data
5. Uncomment the code in Program.cs witch the some basic scenarios to investigate (FirstortDefaultAsync, SingleOrDefaultAsync, ToListAsync)