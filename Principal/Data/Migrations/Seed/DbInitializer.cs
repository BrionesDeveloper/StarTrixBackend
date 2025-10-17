using Microsoft.EntityFrameworkCore;
using NewSystem.Domain.Products;

namespace NewSystem.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(NewSystemContext context, CancellationToken ct = default)
        {
            // Usa migraciones (no EnsureCreated) para no romper cuando cambie el modelo
            await context.Database.MigrateAsync(ct);

            // Evita resembrar si ya hay datos
            if (await context.Products.AnyAsync(ct)) return;

            var products = new List<Product>
            {
                Product.Create("334742",   54, false, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/334742_2024_05_21_18_19_10_760.jpg", "Brake Pad A", "334742",   2, 2),
                Product.Create("370150",   67, false, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/370150.JPG",                               "Brake Pad B", "370150",   3, 1),
                Product.Create("3453PS",   19, false, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/3453PS_2024_11_20_09_36_20_210.jpg",       "Brake Pad C", "3453PS",   2, 3),
                Product.Create("370157",   67, false, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/370157.JPG",                               "Brake Pad D", "370157",   1, 3),
                Product.Create("405",       6,  true, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/405.JPG",                                  "Mixed Brake", "405",      3, 3),
                Product.Create("3220APSB", 19, false, "https://ctfhgmakia.cloudimg.io/https://api.powerstar.mx/Content/ProductoImagen/3220APSB_2025_05_12_12_41_28_617.jpg",     "Brake Pad E", "3220APSB", 2, 1),
            };

            await context.Products.AddRangeAsync(products, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
