using WorktimeLogger.Data;
using WorktimeLogger.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();

    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        var roleExist = await roleManager.RoleExistsAsync(role);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    if (!context.Users.Any())
    {
        var user1 = new User
        {
            UserName = "admin",
            Email = "admin@example.com",
            FullName = "Admin User"
        };
        var result = await userManager.CreateAsync(user1, "Aaa111@");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user1, "Admin");
        }

        var user2 = new User
        {
            UserName = "user",
            Email = "user@example.com",
            FullName = "Regular User"
        };
        result = await userManager.CreateAsync(user2, "Aaa111@");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "User");
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
