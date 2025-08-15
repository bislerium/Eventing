using Eventing.Data.Entities;
using Eventing.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eventing.Data.Seeders;

public static class EventSeeder
{
    public static async Task SeedAsync(DbContext dbContext)
    {
        var eventsToCreate = new List<Event>
        {
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                Title = "Tech Trends 2025",
                Description =
                    "An in-depth seminar discussing the latest technology trends and innovations shaping 2025.",
                StartTime = DateTime.UtcNow.AddDays(3).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(3).AddHours(12),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/techtrends",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002") // Alice
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                Title = "Annual Company Meetup",
                Description =
                    "Our yearly gathering for all departments to review milestones and set goals for the upcoming year.",
                StartTime = DateTime.UtcNow.AddDays(7).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(7).AddHours(17),
                LocationType = LocationType.Physical,
                Location = "Grand Hall, Downtown Conference Center",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                Title = "AI for Beginners",
                Description = "A workshop introducing artificial intelligence concepts for newcomers.",
                StartTime = DateTime.UtcNow.AddDays(5).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(5).AddHours(16),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/aibeginners",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                Title = "Team Building Outdoor Retreat",
                Description = "Fun activities and team-building exercises to strengthen collaboration.",
                StartTime = DateTime.UtcNow.AddDays(14).AddHours(8),
                EndTime = DateTime.UtcNow.AddDays(14).AddHours(18),
                LocationType = LocationType.Physical,
                Location = "Riverside Adventure Park",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                Title = "Monthly Sales Review",
                Description = "A monthly review of sales targets and performance across regions.",
                StartTime = DateTime.UtcNow.AddDays(2).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(2).AddHours(11),
                LocationType = LocationType.Virtual,
                Location = "https://teams.example.com/salesreview",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                Title = "Cybersecurity Best Practices",
                Description = "A security awareness session covering best practices and the latest threats.",
                StartTime = DateTime.UtcNow.AddDays(10).AddHours(15),
                EndTime = DateTime.UtcNow.AddDays(10).AddHours(17),
                LocationType = LocationType.Virtual,
                Location = "https://webinar.example.com/security",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                Title = "Product Launch: Orion X",
                Description = "The official launch of our new product line, Orion X, with demos and Q&A.",
                StartTime = DateTime.UtcNow.AddDays(6).AddHours(11),
                EndTime = DateTime.UtcNow.AddDays(6).AddHours(13),
                LocationType = LocationType.Physical,
                Location = "Innovation Hall, Tech Park",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                Title = "Remote Work Productivity Tips",
                Description = "Learn effective strategies to boost productivity while working remotely.",
                StartTime = DateTime.UtcNow.AddDays(4).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(4).AddHours(12),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/productivity",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                Title = "Health and Wellness Fair",
                Description = "Join us for a day of wellness talks, health checkups, and fitness activities.",
                StartTime = DateTime.UtcNow.AddDays(12).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(12).AddHours(15),
                LocationType = LocationType.Physical,
                Location = "City Sports Complex",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                Title = "Intro to Cloud Computing",
                Description = "A hands-on session exploring cloud computing basics with AWS and Azure demos.",
                StartTime = DateTime.UtcNow.AddDays(8).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(8).AddHours(17),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/cloudintro",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                Title = "Sustainability in Business",
                Description =
                    "A panel discussion on how businesses can adopt sustainable practices without sacrificing growth.",
                StartTime = DateTime.UtcNow.AddDays(15).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(15).AddHours(12),
                LocationType = LocationType.Physical,
                Location = "Green Earth Conference Hall",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                Title = "Mastering Time Management",
                Description = "Practical strategies for improving efficiency and work-life balance.",
                StartTime = DateTime.UtcNow.AddDays(9).AddHours(13),
                EndTime = DateTime.UtcNow.AddDays(9).AddHours(15),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/timemanagement",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                Title = "Data Science Bootcamp",
                Description =
                    "An intensive introduction to data analysis, visualization, and machine learning tools.",
                StartTime = DateTime.UtcNow.AddDays(20).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(20).AddHours(17),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/datasciencebootcamp",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                Title = "Photography for Beginners",
                Description = "A hands-on photography workshop covering camera basics and composition techniques.",
                StartTime = DateTime.UtcNow.AddDays(18).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(18).AddHours(14),
                LocationType = LocationType.Physical,
                Location = "City Art Center - Studio B",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                Title = "Blockchain in Finance",
                Description = "Exploring the impact of blockchain on the global financial system.",
                StartTime = DateTime.UtcNow.AddDays(22).AddHours(11),
                EndTime = DateTime.UtcNow.AddDays(22).AddHours(13),
                LocationType = LocationType.Virtual,
                Location = "https://teams.example.com/blockchainfinance",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                Title = "Marathon Preparation Workshop",
                Description = "Training tips, nutrition plans, and injury pr()ion for marathon runners.",
                StartTime = DateTime.UtcNow.AddDays(17).AddHours(8),
                EndTime = DateTime.UtcNow.AddDays(17).AddHours(10),
                LocationType = LocationType.Physical,
                Location = "City Stadium - Training Room",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                Title = "Public Speaking Masterclass",
                Description = "Learn to speak confidently in front of any audience with practical exercises.",
                StartTime = DateTime.UtcNow.AddDays(16).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(16).AddHours(17),
                LocationType = LocationType.Virtual,
                Location = "https://webinar.example.com/publicspeaking",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                Title = "Local Farmers’ Market Tour",
                Description =
                    "Discover fresh produce, meet local farmers, and learn about sustainable agriculture.",
                StartTime = DateTime.UtcNow.AddDays(13).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(13).AddHours(11),
                LocationType = LocationType.Physical,
                Location = "Main Street Farmers' Market",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                Title = "Coding for Kids",
                Description = "An introductory coding workshop designed for children aged 8–12.",
                StartTime = DateTime.UtcNow.AddDays(11).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(11).AddHours(12),
                LocationType = LocationType.Physical,
                Location = "Community Learning Center - Room 3",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                Title = "Advanced Excel Tips & Tricks",
                Description = "Boost your productivity with advanced Excel features and automation tools.",
                StartTime = DateTime.UtcNow.AddDays(21).AddHours(15),
                EndTime = DateTime.UtcNow.AddDays(21).AddHours(17),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/advancedexcel",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                Title = "Leadership Essentials",
                Description = "Develop the core skills needed to lead teams effectively in any environment.",
                StartTime = DateTime.UtcNow.AddDays(25).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(25).AddHours(12),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/leadershipessentials",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
            },

            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                Title = "Creative Writing Workshop",
                Description = "Unlock your creativity with fun exercises and writing prompts.",
                StartTime = DateTime.UtcNow.AddDays(23).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(23).AddHours(17),
                LocationType = LocationType.Physical,
                Location = "Library Community Room",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                Title = "Cloud Security Fundamentals",
                Description = "An overview of security principles for cloud infrastructure and applications.",
                StartTime = DateTime.UtcNow.AddDays(28).AddHours(11),
                EndTime = DateTime.UtcNow.AddDays(28).AddHours(13),
                LocationType = LocationType.Virtual,
                Location = "https://teams.example.com/cloudsecurity",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                Title = "Yoga and Mindfulness",
                Description = "Start your day with guided yoga and mindfulness meditation.",
                StartTime = DateTime.UtcNow.AddDays(19).AddHours(7),
                EndTime = DateTime.UtcNow.AddDays(19).AddHours(8),
                LocationType = LocationType.Physical,
                Location = "Wellness Center - Room 1",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                Title = "Digital Marketing Strategies",
                Description = "Learn how to grow your brand with modern digital marketing tactics.",
                StartTime = DateTime.UtcNow.AddDays(24).AddHours(13),
                EndTime = DateTime.UtcNow.AddDays(24).AddHours(15),
                LocationType = LocationType.Virtual,
                Location = "https://webinar.example.com/digitalmarketing",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                Title = "Charity Fundraiser Gala",
                Description = "An elegant evening to raise funds for local community projects.",
                StartTime = DateTime.UtcNow.AddDays(30).AddHours(18),
                EndTime = DateTime.UtcNow.AddDays(30).AddHours(22),
                LocationType = LocationType.Physical,
                Location = "Grand Ballroom, City Hotel",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                Title = "Beginner's Guide to Investing",
                Description = "Financial basics and tips for new investors.",
                StartTime = DateTime.UtcNow.AddDays(27).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(27).AddHours(12),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/investing101",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000028"),
                Title = "Advanced Excel Techniques",
                Description = "Take your Excel skills to the next level with macros and pivot tables.",
                StartTime = DateTime.UtcNow.AddDays(29).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(29).AddHours(16),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/advancedexcel",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000029"),
                Title = "Cooking Class: Italian Cuisine",
                Description = "Learn to cook authentic Italian dishes with Chef Maria.",
                StartTime = DateTime.UtcNow.AddDays(26).AddHours(17),
                EndTime = DateTime.UtcNow.AddDays(26).AddHours(20),
                LocationType = LocationType.Physical,
                Location = "Culinary Arts Kitchen",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                Title = "Environmental Awareness Campaign",
                Description = "Join us to discuss ways to reduce our carbon footprint and protect the environment.",
                StartTime = DateTime.UtcNow.AddDays(31).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(31).AddHours(11),
                LocationType = LocationType.Physical,
                Location = "Community Center Auditorium",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                Title = "Startup Pitch Night",
                Description = "Entrepreneurs present their ideas to potential investors and mentors.",
                StartTime = DateTime.UtcNow.AddDays(32).AddHours(18),
                EndTime = DateTime.UtcNow.AddDays(32).AddHours(21),
                LocationType = LocationType.Physical,
                Location = "Innovation Hub Auditorium",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                Title = "Creative Coding Workshop",
                Description = "Explore creative coding techniques with hands-on projects.",
                StartTime = DateTime.UtcNow.AddDays(33).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(33).AddHours(13),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/creativecoding",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                Title = "Mental Health Awareness",
                Description = "A session promoting mental health resources and support.",
                StartTime = DateTime.UtcNow.AddDays(34).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(34).AddHours(16),
                LocationType = LocationType.Physical,
                Location = "Wellness Center Conference Room",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000034"),
                Title = "Intro to Robotics",
                Description = "Basics of robotics programming and hardware for beginners.",
                StartTime = DateTime.UtcNow.AddDays(35).AddHours(9),
                EndTime = DateTime.UtcNow.AddDays(35).AddHours(12),
                LocationType = LocationType.Virtual,
                Location = "https://zoom.example.com/roboticsintro",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000035"),
                Title = "Gardening Club Meetup",
                Description = "Monthly meetup for gardening enthusiasts to share tips and plants.",
                StartTime = DateTime.UtcNow.AddDays(36).AddHours(15),
                EndTime = DateTime.UtcNow.AddDays(36).AddHours(17),
                LocationType = LocationType.Physical,
                Location = "Community Garden Center",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000036"),
                Title = "Effective Negotiation Skills",
                Description = "Techniques and strategies for successful negotiations in business.",
                StartTime = DateTime.UtcNow.AddDays(37).AddHours(13),
                EndTime = DateTime.UtcNow.AddDays(37).AddHours(16),
                LocationType = LocationType.Virtual,
                Location = "https://webinar.example.com/negotiationskills",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000037"),
                Title = "Volunteer Training Session",
                Description = "Training new volunteers for community outreach programs.",
                StartTime = DateTime.UtcNow.AddDays(38).AddHours(10),
                EndTime = DateTime.UtcNow.AddDays(38).AddHours(12),
                LocationType = LocationType.Physical,
                Location = "Nonprofit HQ - Training Room",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000038"),
                Title = "Photography Exhibition Opening",
                Description = "Opening night for a local photographers’ exhibition.",
                StartTime = DateTime.UtcNow.AddDays(39).AddHours(19),
                EndTime = DateTime.UtcNow.AddDays(39).AddHours(21),
                LocationType = LocationType.Physical,
                Location = "City Art Gallery",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000039"),
                Title = "Beginner Spanish Course",
                Description = "Learn the basics of Spanish in this introductory language course.",
                StartTime = DateTime.UtcNow.AddDays(40).AddHours(16),
                EndTime = DateTime.UtcNow.AddDays(40).AddHours(18),
                LocationType = LocationType.Virtual,
                Location = "https://meet.example.com/spanishcourse",
                ShowAttendees = false,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
            },
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000040"),
                Title = "Climate Change Action Planning",
                Description = "Community meeting to plan local actions addressing climate change.",
                StartTime = DateTime.UtcNow.AddDays(41).AddHours(14),
                EndTime = DateTime.UtcNow.AddDays(41).AddHours(17),
                LocationType = LocationType.Physical,
                Location = "Town Hall Meeting Room",
                ShowAttendees = true,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
            }
        };

        // Get existing event IDs to avoid duplicates
        var existingEventIds = await dbContext.Set<Event>()
            .Where(e => eventsToCreate.Select(ev => ev.Id).Contains(e.Id))
            .Select(e => e.Id)
            .ToListAsync();

        var newEvents = eventsToCreate.ExceptBy(existingEventIds, x => x.Id).ToArray();

        if (newEvents.Length > 0)
        {
            await dbContext.Set<Event>().AddRangeAsync(newEvents);
            await dbContext.SaveChangesAsync();
        }
    }
}