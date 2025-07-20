using Eventing.ApiService.Data.Entities;
using Eventing.ApiService.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Data.Seeders;

public static class EventSeeder
{
    public static async Task SeedAsync(DbContext dbContext, CancellationToken cancellationToken)
    {
        // var eventsToSeed = new List<Event>
        // {
        //     new Event
        //     {
        //         Id = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
        //         Title = "Tech Innovators Conference 2025",
        //         Description = "A multi-day conference featuring talks from leading tech innovators.",
        //         StartTime = new DateTime(2025, 9, 10, 9, 0, 0, DateTimeKind.Utc),
        //         EndTime = new DateTime(2025, 9, 12, 17, 0, 0, DateTimeKind.Utc),
        //         LocationType = LocationType.Physical,
        //         Location = "Grand Convention Center, New York",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddMonths(-3)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e2222222-2222-2222-2222-222222222222"),
        //         Title = "Monthly Marketing Meetup",
        //         Description = "Networking event for marketing professionals to share latest trends.",
        //         StartTime = DateTime.UtcNow.AddDays(7).AddHours(18),
        //         EndTime = DateTime.UtcNow.AddDays(7).AddHours(20),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://meet.google.com/abc-defg-hij",
        //         CreatedBy = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-40)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e3333333-3333-3333-3333-333333333333"),
        //         Title = "AI Ethics Webinar",
        //         Description = "Online seminar discussing ethical considerations in AI development.",
        //         StartTime = DateTime.UtcNow.AddDays(15).AddHours(15),
        //         EndTime = DateTime.UtcNow.AddDays(15).AddHours(17),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://zoom.us/j/123-4567-890",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddMonths(-1)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e4444444-4444-4444-4444-444444444444"),
        //         Title = "Startup Pitch Night",
        //         Description = "Local startups pitch their ideas to potential investors.",
        //         StartTime = DateTime.UtcNow.AddDays(30).AddHours(19),
        //         EndTime = DateTime.UtcNow.AddDays(30).AddHours(22),
        //         LocationType = LocationType.Physical,
        //         Location = "Innovation Hub Auditorium",
        //         CreatedBy = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-60)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e5555555-5555-5555-5555-555555555555"),
        //         Title = "Cloud Computing Workshop",
        //         Description = "Learn the fundamentals of cloud computing.",
        //         StartTime = DateTime.UtcNow.AddDays(10).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(10).AddHours(16),
        //         LocationType = LocationType.Physical,
        //         Location = "City Library Hall",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-10)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e6666666-6666-6666-6666-666666666666"),
        //         Title = "Design Thinking Bootcamp",
        //         Description = "Intensive workshop on design thinking principles.",
        //         StartTime = DateTime.UtcNow.AddDays(13).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(13).AddHours(16),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://meet.google.com/xyz-abcd-efg",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-5)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e7777777-7777-7777-7777-777777777777"),
        //         Title = "Cybersecurity Essentials",
        //         Description = "Seminar on best practices for cybersecurity.",
        //         StartTime = DateTime.UtcNow.AddDays(16).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(16).AddHours(16),
        //         LocationType = LocationType.Physical,
        //         Location = "Tech Park Conference Room",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-20)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e8888888-8888-8888-8888-888888888888"),
        //         Title = "Product Management Roundtable",
        //         Description = "Discussion forum for product managers.",
        //         StartTime = DateTime.UtcNow.AddDays(19).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(19).AddHours(16),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://zoom.us/j/987-6543-210",
        //         CreatedBy = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-15)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e9999999-9999-9999-9999-999999999999"),
        //         Title = "Data Science Seminar",
        //         Description = "Explore the latest trends in data science.",
        //         StartTime = DateTime.UtcNow.AddDays(22).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(22).AddHours(16),
        //         LocationType = LocationType.Physical,
        //         Location = "Co-working Space",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-25)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1010101-1010-1010-1010-101010101010"),
        //         Title = "Mobile App Dev Sprint",
        //         Description = "Sprint for mobile app developers.",
        //         StartTime = DateTime.UtcNow.AddDays(25).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(25).AddHours(16),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://meet.google.com/lmn-opqr-stu",
        //         CreatedBy = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-30)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1111112-1111-1111-1111-111111111112"),
        //         Title = "Blockchain Introduction",
        //         Description = "Introductory session on blockchain technology.",
        //         StartTime = DateTime.UtcNow.AddDays(28).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(28).AddHours(16),
        //         LocationType = LocationType.Physical,
        //         Location = "Main Auditorium",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-35)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1212121-2121-2121-2121-212121212121"),
        //         Title = "UX/UI Design Meetup",
        //         Description = "Meetup for UX and UI designers.",
        //         StartTime = DateTime.UtcNow.AddDays(31).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(31).AddHours(16),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://zoom.us/j/456-7890-123",
        //         CreatedBy = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-40)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1313131-3131-3131-3131-313131313131"),
        //         Title = "Agile Methodology Training",
        //         Description = "Training session on Agile practices.",
        //         StartTime = DateTime.UtcNow.AddDays(34).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(34).AddHours(16),
        //         LocationType = LocationType.Physical,
        //         Location = "City Library Hall",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-45)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1414141-4141-4141-4141-414141414141"),
        //         Title = "Digital Marketing Webinar",
        //         Description = "Webinar on digital marketing strategies.",
        //         StartTime = DateTime.UtcNow.AddDays(37).AddHours(14),
        //         EndTime = DateTime.UtcNow.AddDays(37).AddHours(16),
        //         LocationType = LocationType.Virtual,
        //         Location = "https://meet.google.com/vwx-yzab-cde",
        //         CreatedBy = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-50)
        //     },
        //     new Event
        //     {
        //         Id = Guid.Parse("e1515151-5151-5151-5151-515151515151"),
        //         Title = "Community Hackathon",
        //         Description = "Local community hackathon event.",
        //         StartTime = DateTime.UtcNow.AddDays(40).AddHours(9),
        //         EndTime = DateTime.UtcNow.AddDays(40).AddHours(21),
        //         LocationType = LocationType.Physical,
        //         Location = "Innovation Hub Auditorium",
        //         CreatedBy = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        //         CreatedAt = DateTime.UtcNow.AddDays(-55)
        //     }
        // };
        //
        // // Get existing event IDs to avoid duplicates
        // var existingEventIds = await dbContext.Set<Event>()
        //     .Where(e => eventsToSeed.Select(ev => ev.Id).Contains(e.Id))
        //     .Select(e => e.Id)
        //     .ToListAsync(cancellationToken);
        //
        // var newEvents = eventsToSeed.ExceptBy(existingEventIds, x => x.Id).ToArray();
        //
        // if (newEvents.Length > 0)
        // {
        //     await dbContext.Set<Event>().AddRangeAsync(newEvents, cancellationToken);
        //     await dbContext.SaveChangesAsync(cancellationToken);
        // }

    }
}