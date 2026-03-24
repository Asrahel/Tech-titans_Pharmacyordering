using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Data
{
    public static class DbSeeder
    {
        public static void SeedAdmin(AppDbContext context)
        {
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                context.Users.Add(new User
                {
                    Name = "Main Admin",
                    Email = "admin@pharmacy.com",
                    Password = "Admin@123",
                    Role = "Admin"
                });

                context.SaveChanges();
            }
        }
    }
}