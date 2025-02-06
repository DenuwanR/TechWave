Scaffold-DbContext Command

Use Scaffold-DbContext to create a model based on your existing database. The following parameters can be specified with Scaffold-DbContext in Package Manager Console:

Scaffold-DbContext [-Connection] [-Provider] [-OutputDir] [-Context] [-Schemas>] [-Tables>] 
                    [-DataAnnotations] [-Force] [-Project] [-StartupProject] [<CommonParameters>]

https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx


Reverse Engineering
https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli

Scaffold-DbContext "Data Source=LAPTOP-F81GNF66;Initial Catalog=ECOSYSTEMn;User ID=ecom;Password=1111;Encrypt=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EntityModel -Force
