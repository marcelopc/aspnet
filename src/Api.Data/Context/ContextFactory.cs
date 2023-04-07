using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    internal class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=api;Uid=root;Pwd=Windows@10";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var serverVersion = new MySqlServerVersion(new Version(8,0,32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
