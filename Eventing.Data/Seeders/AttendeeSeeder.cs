using Eventing.Data.Entities;
using Eventing.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eventing.Data.Seeders;

public class AttendeeSeeder
{
    public static async Task SeedAsync(DbContext dbContext)
    {
        var attendeesToCreate = new List<Attendee>
        {
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Looking forward to sharing insights during this seminar on technology trends."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "This topic is highly relevant to my work. I will try my best to attend if possible."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Excited to welcome everyone to the annual company meetup in the grand hall."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "This yearly meetup is always inspiring and useful for planning ahead."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "Unfortunately I will be out of town during the meetup, but I’ll review the summary notes later."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "As organizer, I will guide beginners through the AI fundamentals step by step."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "The AI workshop sounds useful for me as I am starting in this field, but depends on schedule."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Excited to attend this seminar and learn more about the latest innovations in technology."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "I am unable to join due to prior commitments, but I am very interested in the materials shared."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "If my project timeline permits, I would love to attend this seminar about technology in 2025."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "The annual meetup is a great opportunity to align with colleagues across departments."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Looking forward to meeting colleagues and learning about achievements in the past year."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "There is a chance I might need to travel that day, but I hope to make it to the company meetup."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Excited to support Bob’s session and encourage more beginners to explore AI concepts."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "AI for Beginners aligns perfectly with my learning journey, and I am eager to attend this session."
            },
// --- Team Building Outdoor Retreat ---
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000021"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "Excited to lead this retreat. The activities will help us bond and grow as a stronger team."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000022"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Team building sessions are always refreshing and valuable for collaboration."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000023"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000024"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unfortunately, I have a scheduling conflict on this day and won’t be able to attend."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000025"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "The retreat sounds great, but my availability depends on a project deadline that week."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000026"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Looking forward to some outdoor activities with colleagues!"
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000027"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000028"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to join the team outdoors. I think this will build stronger trust between us."
            },

// --- Monthly Sales Review ---
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000029"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "As the organizer, I will present the sales performance overview and upcoming targets."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000030"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment =
                    "I am particularly interested in how our sales strategies align with the annual company goals."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000031"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000032"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "If I can wrap up my other meeting early, I’ll definitely attend this review."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000033"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "It will be good to review the regional sales trends and targets together as a team."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000034"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "I won’t be able to attend this review, but I’ll read the minutes carefully afterwards."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000035"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000036"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment =
                    "Sales reviews give me insight into how our overall company direction impacts individual goals."
            },

// --- Cybersecurity Best Practices ---
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000037"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment =
                    "I will be presenting best practices and emerging threats in cybersecurity during this session."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000038"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "This topic is critical for everyone. I will try to join depending on other responsibilities."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000039"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cybersecurity awareness is something I want to keep improving. This session will be helpful."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000040"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unfortunately, I cannot attend this security session, but I hope it is recorded."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000041"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000042"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Security topics are important for all of us, and I want to keep my knowledge updated."
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000043"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("20000000-0000-0000-0000-000000000044"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "I think this session will be very practical and applicable to our daily work routines."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Looking forward to unveiling Orion X with the team and engaging in Q&A."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Might attend depending on schedule, but very excited about the launch."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1).AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-1).AddHours(-3),
                Comment = "Excited to see product demos and learn about the new Orion X line."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Unfortunately I will be traveling during the event and cannot join."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2).AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-2).AddHours(-1),
                Comment = "Product launches are always exciting—happy to participate in this one."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Still checking my calendar, but this product launch looks very interesting."
            },
            // ()s for "Product Launch: Orion X"
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Excited to lead the Orion X launch. Looking forward to presenting demos."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Will join the launch event to oversee proceedings and support the team."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Unfortunately, I have a scheduling conflict but I wish the team success."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to engaging with ()s during the launch activities."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Will be there to ensure security compliance during the event."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "I’ll be attending and helping to showcase the Orion X features."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Ivy
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },

// Attendees for "Remote Work Productivity Tips"
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Hosting this to share proven strategies for boosting remote productivity."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unable to join this session due to prior commitments."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "I’m eager to learn practical ways to maintain work-life balance remotely."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Excited to apply these productivity techniques within my sales team."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "I’ll attend to share wellness-focused productivity hacks for remote employees."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Ivy
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },

// Attendees for "Health and Wellness Fair"
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000021"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Excited to host the wellness fair and bring health resources to everyone."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000022"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000023"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to participating in wellness activities and fitness sessions."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000024"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unfortunately I cannot join, but I appreciate the focus on health awareness."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000025"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "I’ll be attending to facilitate some outdoor health challenges."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000026"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000027"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Ensuring safety and compliance during the fair, while also joining activities."
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000028"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000029"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000030"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Ivy
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Joining the fair to promote healthy eating habits and share wellness resources."
            },
            // Event: Intro to Cloud Computing
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Looking forward to introducing attendees to cloud computing basics with hands-on demos."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-5),
                UpdatedAt = DateTime.UtcNow.AddHours(-5),
                Comment = "Might join depending on my schedule, but eager to learn cloud basics."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-6),
                UpdatedAt = DateTime.UtcNow.AddHours(-6),
                Comment = "Excited to attend and follow the AWS and Azure demos."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-4),
                UpdatedAt = DateTime.UtcNow.AddHours(-4),
                Comment = "I am traveling on that day and cannot join, but wishing success for the session."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Looking forward to learning cloud techniques and applying them to projects."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Will try to attend, scheduling may conflict but interested in cloud demos."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                Comment = "Excited to participate and learn cloud computing hands-on."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },

// Event: Sustainability in Business
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting the panel to share sustainable practices that still drive growth."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to the discussion and learning practical sustainability methods."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Will try to attend depending on schedule, interested in sustainability."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unable to attend due to prior commitments but interested in the outcomes."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Happy to attend and contribute insights on sustainable business practices."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Will attend if free, the topic of sustainability is very relevant."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to participating and networking with other ()s."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },

// Event: Mastering Time Management
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000021"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this session to teach practical strategies for time management."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000022"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000023"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn actionable tips to improve my daily productivity."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000024"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on other commitments, very interested in time management."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000025"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cannot attend due to schedule conflict, but wishing success for the session."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000026"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to applying time management strategies in daily work."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000027"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000028"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Will try to attend, very keen to improve productivity and efficiency."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000029"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to gain practical insights on managing time effectively."
            },
            new()
            {
                Id = Guid.Parse("31000000-0000-0000-0000-000000000030"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            // Event: Data Science Bootcamp
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this bootcamp to introduce ()s to practical data science tools and techniques."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment =
                    "Looking forward to the bootcamp to gain hands-on experience with data analysis and visualization."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-6),
                UpdatedAt = DateTime.UtcNow.AddHours(-6),
                Comment = "Might attend depending on other commitments but interested in learning ML basics."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-5),
                UpdatedAt = DateTime.UtcNow.AddHours(-5),
                Comment = "Unable to attend due to schedule conflicts but wishing the ()s a successful bootcamp."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-4),
                UpdatedAt = DateTime.UtcNow.AddHours(-4),
                Comment = "Excited to join and learn practical machine learning techniques for data projects."
            },

// Event: Photography for Beginners
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this workshop to guide beginners through camera basics and composition techniques."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Will attend if free, eager to improve photography skills."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Looking forward to this hands-on workshop to practice photography techniques."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                Comment = "Cannot attend due to prior commitments but hoping to join next session."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to join and learn photography fundamentals and creative tips."
            },

// Event: Blockchain in Finance
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to explain blockchain's impact on the financial system."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to exploring blockchain applications in finance."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on schedule but very interested in blockchain topics."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cannot attend this time but eager to learn from session notes."
            },
            new()
            {
                Id = Guid.Parse("32000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and understand the practical applications of blockchain in finance."
            },
            // Event: Marathon Preparation Workshop
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment =
                    "Hosting this workshop to guide participants on marathon training, nutrition, and injury prevention."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Looking forward to learning training and nutrition strategies for marathon preparation."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Might attend depending on schedule, interested in injury prevention tips."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                Comment = "Cannot attend this workshop due to other commitments but wishing participants success."
            },

// Event: Public Speaking Masterclass
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment =
                    "Hosting this masterclass to help attendees improve public speaking skills with practical exercises."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-4),
                UpdatedAt = DateTime.UtcNow.AddHours(-4),
                Comment = "Excited to gain confidence in speaking and learn practical public speaking techniques."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Might attend if free, eager to improve public speaking confidence."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Cannot attend this session but looking forward to future workshops."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                Comment = "Looking forward to practical exercises that will help me speak confidently."
            },

// Event: Local Farmers’ Market Tour
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this market tour to showcase local produce and sustainable farming practices."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to visit the market and learn about local farming practices and fresh produce."
            },
            new()
            {
                Id = Guid.Parse("33000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on schedule, interested in sustainable agriculture."
            },
            // Event: Coding for Kids
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this workshop to introduce children to coding in a fun and engaging way."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Might attend to see the workshop structure and learning approach for kids."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Excited to attend and see how coding concepts are presented to children."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                Comment = "Cannot attend, but interested in seeing session materials later."
            },

// Event: Advanced Excel Tips & Tricks
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to help participants master advanced Excel features and automation."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-4),
                UpdatedAt = DateTime.UtcNow.AddHours(-4),
                Comment = "Looking forward to improving Excel skills for work efficiency."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Might attend depending on availability, interested in Excel automation tips."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Cannot attend but will review session materials afterwards."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn new Excel automation features to increase productivity."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend, interested in Excel automation tricks for work."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to Excel tips that will help automate repetitive tasks."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Unable to attend but interested in session notes."
            },

// Event: Leadership Essentials
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to teach core leadership skills for managing teams effectively."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Pending
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend to enhance leadership skills depending on schedule."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning practical leadership techniques to manage teams effectively."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and strengthen leadership capabilities."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if schedule allows, interested in leadership strategies."
            },
            new()
            {
                Id = Guid.Parse("34000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate and improve leadership skills for team management."
            },
            // Event: Creative Writing Workshop
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this workshop to encourage participants to explore their creative writing potential."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddHours(-3),
                UpdatedAt = DateTime.UtcNow.AddHours(-3),
                Comment = "Excited to join and practice creative writing exercises."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                Comment = "Might attend depending on schedule, interested in writing prompts."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning new writing techniques."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cannot attend but interested in session materials."
            },

// Event: Cloud Security Fundamentals
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to explain cloud security fundamentals clearly to all participants."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to join and learn cloud security principles."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend, interested in cloud security best practices."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to deepen knowledge on securing cloud infrastructure."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning security principles applicable to cloud applications."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on availability, interested in cloud security topics."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to join and learn best practices for cloud security."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cannot attend but interested in recorded session later."
            },

// Event: Yoga and Mindfulness
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to encourage mindfulness and physical well-being for all participants."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate and start the day with yoga."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on morning schedule."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to mindfulness and yoga session."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to join early morning yoga and mindfulness activities."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on other commitments."
            },
            new()
            {
                Id = Guid.Parse("35000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000024"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to starting the day with yoga and mindfulness."
            },
// Event: Digital Marketing Strategies
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this session to share practical digital marketing strategies for everyone."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn new tactics to grow my brand online."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on other commitments, interested in marketing strategies."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to practical tips for digital campaigns."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000025"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Declined,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Cannot attend, but interested in receiving the session recording."
            },

// Event: Charity Fundraiser Gala
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "Hosting this gala to support community projects and raise awareness."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and contribute to the fundraiser."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to supporting local community projects."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if schedule permits, interested in charity events."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000026"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and help raise funds for community projects."
            },

// Event: Beginner's Guide to Investing
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this session to guide new investors with practical financial basics."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn beginner investment strategies."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if available, interested in financial basics."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning investment tips for beginners."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to understand financial basics and investing tips."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on availability, interested in investment basics."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to beginner investing insights."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and gain basic investing knowledge."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000019"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if schedule permits, interested in investing basics."
            },
            new()
            {
                Id = Guid.Parse("36000000-0000-0000-0000-000000000020"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000027"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to beginner investment tips and guidance."
            },
// Event: Advanced Excel Techniques
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000028"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this advanced Excel session to share productivity tips and macros."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000028"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning pivot tables and Excel automation."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000028"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on schedule, interested in Excel techniques."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000028"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to improve Excel skills with practical examples."
            },

// Event: Cooking Class: Italian Cuisine
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000029"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this cooking class to teach authentic Italian dishes."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000029"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn Italian cooking from Chef Maria."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000029"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to hands-on cooking experience and Italian recipes."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000029"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if I finish other tasks, interested in Italian cuisine."
            },

// Event: Environmental Awareness Campaign
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "Hosting this campaign to promote environmental awareness in our community."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to participating and contributing to environmental initiatives."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn about reducing carbon footprint and protecting the environment."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on my schedule, interested in environmental topics."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to taking actionable steps for environmental protection."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate and promote environmental awareness."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if available, interested in environmental campaigns."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning ways to reduce carbon footprint."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate and contribute to environmental discussions."
            },
            new()
            {
                Id = Guid.Parse("37000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000030"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on other commitments, interested in environmental topics."
            },
// Event: Startup Pitch Night
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting this pitch night to support local entrepreneurs."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to seeing the startup ideas presented."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and provide feedback to participants."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on schedule, interested in startups."
            },

// Event: Creative Coding Workshop
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this coding workshop to explore creative coding techniques."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate in hands-on coding projects."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning creative coding techniques."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might join if schedule allows, interested in creative coding."
            },

// Event: Mental Health Awareness
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                Comment = "Hosting this session to promote mental health awareness."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning about mental health resources."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to participate and support mental health initiatives."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on other commitments, interested in mental health topics."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000013"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to supporting mental health awareness and resources."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000014"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to attend and learn about mental health support."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000015"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if schedule allows, interested in supporting mental health."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000016"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to joining and raising awareness for mental health."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000017"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn and support mental health initiatives."
            },
            new()
            {
                Id = Guid.Parse("38000000-0000-0000-0000-000000000018"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend if time permits, interested in mental health topics."
            },
// Event: Intro to Robotics
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000034"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this session to introduce robotics basics."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000034"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning the basics of robotics."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000034"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might join if time permits, interested in robotics."
            },

// Event: Gardening Club Meetup
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000035"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting monthly meetup for gardening enthusiasts."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000035"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to share gardening tips and learn from others."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000035"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to exchanging gardening ideas."
            },

// Event: Effective Negotiation Skills
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000036"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000007"), // Frank (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this session to teach effective negotiation strategies."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000036"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to learning negotiation skills."
            },
            new()
            {
                Id = Guid.Parse("39000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000036"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might join depending on schedule."
            },
// Event: Volunteer Training Session
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000037"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000008"), // Grace (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Hosting training session for new volunteers."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000037"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Bob
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to help with volunteer training."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000037"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might attend depending on schedule."
            },

// Event: Photography Exhibition Opening
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000038"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000009"), // Henry (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting exhibition opening for local photographers."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000038"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to the photography exhibition."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000038"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000006"), // Eve
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might join if available, excited about photography."
            },

// Event: Beginner Spanish Course
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000039"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000010"), // Irene (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                Comment = "Hosting this introductory Spanish course."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000008"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000039"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Excited to learn basic Spanish."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000009"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000039"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000005"), // David
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might join depending on my schedule."
            },

// Event: Climate Change Action Planning
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000010"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000040"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Admin (Organizer)
                IsOrganizer = true,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Comment = "Organizing community meeting for climate action."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000011"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000040"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000004"), // Carol
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Accepted,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Looking forward to contributing to climate action planning."
            },
            new()
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000012"),
                EventId = Guid.Parse("10000000-0000-0000-0000-000000000040"),
                ResponderId = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Alice
                IsOrganizer = false,
                RsvpResponse = RsvpResponse.Maybe,
                RespondedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Comment = "Might participate depending on schedule."
            }
        };

        // Get existing event IDs to avoid duplicates
        var existingEventIds = await dbContext.Set<Attendee>()
            .Where(e => attendeesToCreate.Select(ev => ev.Id).Contains(e.Id))
            .Select(e => e.Id)
            .ToListAsync();

        var newAttendees = attendeesToCreate.ExceptBy(existingEventIds, x => x.Id).ToArray();

        if (newAttendees.Length > 0)
        {
            await dbContext.Set<Attendee>().AddRangeAsync(newAttendees);
            await dbContext.SaveChangesAsync();
        }
    }
}