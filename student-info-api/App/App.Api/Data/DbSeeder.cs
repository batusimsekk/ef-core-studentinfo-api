using App.Api.Data.Entities;
using Bogus;

namespace App.Api.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            int numberCounter = 1000;

            var faker = new Faker<StudentEntity>("tr")
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Number, f => (numberCounter++)) // benzersiz numara
                .RuleFor(s => s.Class, f => f.PickRandom(new[] { "9-A", "9-B", "10-A", "10-B" }));

            var students = faker.Generate(20);
            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
