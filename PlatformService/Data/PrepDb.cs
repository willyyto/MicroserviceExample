using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine(">> Seeding Data.");
                context.AddRange(
                    new Platform() {Name="Dotnet", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernets", Publisher="Cloud Native", Cost="Free"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine(">> We already have data.");
            }
        }
    }
}