namespace TestingWebAPI.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var movieDomainScope = host.Services.CreateScope())
                {
                    var services = movieDomainScope.ServiceProvider;
                    var context = services.GetRequiredService<MovieContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
            }
        }
    }
}
