using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using static RiverBooks.Users.UserModuleExtensions;

namespace RiverBooks.Users.UserEndpoints;


internal class Create : Endpoint<CreateUserRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public Create(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();

    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {

        var newUsers = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email
        };

        await _userManager.CreateAsync(newUsers, request.Password);

        await SendOkAsync();
    }
}
