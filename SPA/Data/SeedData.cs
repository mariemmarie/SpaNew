using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA.Data
{
    public class SeedData
    {
        public static async Task InitAsync(IServiceProvider services)
        {
          using (var db = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>(), null))
            {
                if (db.Consultants.Any())
                {
                    return;
                }
                var consultants = GetConsultants();

                    await db.AddRangeAsync(consultants);
                    await db.SaveChangesAsync();
            };
        }

        private static List<Consultant> GetConsultants()
        {
            var consultants = new List<Consultant>();

            for (int i = 0; i < 30; i++)
            {
            var fake = new Faker("fr");
                var consultant = new Consultant
                {
                    FirstName = fake.Person.FirstName,
                    LastName = fake.Person.LastName,
                    Email = fake.Internet.Email()

                };
                consultants.Add(consultant);
            }
            return consultants;
        }
    }
}
