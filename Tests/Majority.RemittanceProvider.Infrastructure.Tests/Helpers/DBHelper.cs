using System;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.UnitTests.RepositoryTests
{
    public class DBHelper
    {
        public static RemittanceProviderContext GetRemittanceProviderContext()
        {
            var options = new DbContextOptionsBuilder<RemittanceProviderContext>()
.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
.Options;
            return new RemittanceProviderContext(options, null);
        }
    }
}