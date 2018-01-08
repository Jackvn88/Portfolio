using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ShuPortfolio.Models
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            CategoriesDbContext context = app.ApplicationServices
                .GetRequiredService<CategoriesDbContext>();
            context.Database.Migrate();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Furniture design",
                        Image = "1.jpg",
                        Works = new List<Work>()
                        {
                            new Work() {Name = "1", DataCreated = DateTime.Now, Description = "Art", Image = "1.jpg"},
                            new Work() {Name = "2", DataCreated = DateTime.Now, Description = "Art", Image = "2.jpg"},
                            new Work() {Name = "3", DataCreated = DateTime.Now, Description = "Art", Image = "3.jpg"},
                        }
                    },
                    new Category
                    {
                        Name = "Graphic art",
                        Image = "2.jpg",
                        Works = new List<Work>()
                        {
                            new Work() {Name = "1", DataCreated = DateTime.Now, Description = "Art", Image = "1.jpg"},
                            new Work() {Name = "2", DataCreated = DateTime.Now, Description = "Art", Image = "2.jpg"},
                            new Work() {Name = "3", DataCreated = DateTime.Now, Description = "Art", Image = "3.jpg"},
                        }
                    },
                    new Category
                    {
                        Name = "Photo",
                        Image = "3.jpg",
                        Works = new List<Work>()
                        {
                            new Work() {Name = "1", DataCreated = DateTime.Now, Description = "Art", Image = "1.jpg"},
                            new Work() {Name = "2", DataCreated = DateTime.Now, Description = "Art", Image = "2.jpg"},
                            new Work() {Name = "3", DataCreated = DateTime.Now, Description = "Art", Image = "3.jpg"},
                        }
                    }
                );
                 await context.SaveChangesAsync();
            }
        }
    }
}
