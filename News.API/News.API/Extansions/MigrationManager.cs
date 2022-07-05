using Microsoft.EntityFrameworkCore;
using News.DataAccess.Concreate;

namespace News.API.Extansions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var MbContext = scope.ServiceProvider.GetRequiredService<MBContext>())
                {
                    try
                    {
                        MbContext.Database.Migrate();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return host;
        }

    }
}
