using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar Migrações
            var connectionString = "server=localhost;userid=root;password='';database=dbWebApi";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionsBuilder.UseMySql (connectionString);
            return new MyContext (optionsBuilder.Options);
        }
    }
}