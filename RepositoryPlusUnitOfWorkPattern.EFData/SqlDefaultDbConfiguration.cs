using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPlusUnitOfWorkPattern.EFData
{
    //set up a default configuration so that you don't have to include EF in every single project.
    class SqlDefaultDbConfiguration : DbConfiguration
    {
        public SqlDefaultDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);


            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}
