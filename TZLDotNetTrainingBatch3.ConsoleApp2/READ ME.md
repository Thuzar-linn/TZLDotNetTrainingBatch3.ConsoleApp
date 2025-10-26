using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    class READ_ME
    { dotnet tool install --global dotnet-ef
        //
    // To scaffold the existing database, run the following command in the Package Manager Console:
        //
     dotnet ef dbcontext scaffold "Server=.;Database=Batch3MiniPOS;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o EFAppDbContextModels -c EFAppDbContext -f
    }
}
