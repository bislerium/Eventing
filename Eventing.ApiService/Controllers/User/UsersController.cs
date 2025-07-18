using System.ComponentModel;
using Eventing.ApiService.Controllers.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Eventing.ApiService.Controllers.User;

[ApiConventionType(typeof(DefaultApiConventions))]
public sealed class UsersController : ApiBaseController
{
    private static readonly List<Data.Entities.User> Users =
    [
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Alice", Email = "alice@example.com",
            Address = "123 Main St"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Bob", Email = "bob@example.com",
            Address = "456 Oak Ave"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Charlie", Email = "charlie@example.com",
            Address = "789 Pine Rd"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "David", Email = "david@example.com",
            Address = "321 Birch St"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Eve", Email = "eve@example.com",
            Address = "654 Cedar Blvd"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Frank", Email = "frank@example.com",
            Address = "987 Spruce Ct"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Grace", Email = "grace@example.com",
            Address = "147 Elm Ln"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Hannah", Email = "hannah@example.com",
            Address = "258 Maple St"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Isaac", Email = "isaac@example.com",
            Address = "369 Aspen Dr"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Jack", Email = "jack@example.com",
            Address = "741 Redwood Rd"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Karen", Email = "karen@example.com",
            Address = "852 Walnut Ave"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Leo", Email = "leo@example.com",
            Address = "963 Chestnut Blvd"
        },
    ];

    [HttpGet]
    [EndpointName("GetAllUsers")]
    [EndpointSummary("Get all users")]
    [EndpointDescription("Returns a list of all users.")]
    public IEnumerable<UserResponse> GetAll() => Users.Select(UserResponse.From);

    [HttpGet("{id:guid}")]
    [EndpointName("GetUserById")]
    [EndpointSummary("Get user by ID")]
    [EndpointDescription("Returns a single user by their unique identifier.")]
    public ActionResult<UserResponse> GetById([FromRoute, Description("The ID of the user to retrieve")] Guid id)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user == null) return NotFound();

        return Ok(UserResponse.From(user));
    }

    [HttpPost]
    [EndpointName("CreateUser")]
    [EndpointSummary("Create a new user")]
    [EndpointDescription("Creates a user and returns the location of the newly created resource.")]
    public IActionResult Create([FromBody, Description("The user details to create")] CreateUserRequestDto dto)
    {
        var user = new Data.Entities.User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
        };

        Users.Add(user);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, null);
    }

    [HttpPut("{id:guid}")]
    [EndpointName("UpdateUser")]
    [EndpointSummary("Update user")]
    [EndpointDescription("Updates the details of an existing user.")]
    public IActionResult Update(
        [FromRoute, Description("The ID of the user to update")]
        Guid id,
        [FromBody, Description("The updated user data")]
        UpdateUserRequestDto dto)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user == null) return NotFound();

        user.Name = dto.Name;
        user.Email = dto.Email;
        user.Address = dto.Address;

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [EndpointName("DeleteUser")]
    [EndpointSummary("Delete user")]
    [EndpointDescription("Removes a user by their unique identifier.")]
    public IActionResult Delete([FromRoute, Description("The ID of the user to delete")] Guid id)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user == null) return NotFound();

        Users.Remove(user);

        return Ok();
    }
}