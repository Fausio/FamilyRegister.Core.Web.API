using Data.AppDBContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public static class Seed
    {

        private static FamilyRegisterDbContext db = new FamilyRegisterDbContext(new DbContextOptions<FamilyRegisterDbContext>());

        public static async Task Run()
        {
            await SeedFamilies();
        }

        private static async Task SeedFamilies()
        {

            if (db.Families.Count() <= 0)
            {
                var families = new List<Family>();

                for (int i = 0; i < 100; i++)
                {
                    if (i == 0)
                    {
                        i = 0;
                    }

                    families.Add(new Family()
                    {
                        name = $"familia {i}",
                        money = i * 456,
                        members = i

                    });
                }

                await db.Families.AddRangeAsync(families);
                await db.SaveChangesAsync();
            }





        }
    }
}
