using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace API.DatingApp.DataAccess.Initializer
{
	public class Seed
	{
		public static async Task SeedUser(IServiceProvider services, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			DataContext context = services.GetRequiredService<DataContext>();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			if (await userManager.Users.AnyAsync())
			{
				return;
			}
			var userData = await File.ReadAllTextAsync("C:\\Users\\sasha\\OneDrive\\Рабочий стол\\DatingApp3\\DatingApp.DataAccess\\Initializer\\UserSeedData.json");
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
			var roles = new List<AppRole>
			{
				new AppRole{Name = "Member"},
				new AppRole{Name = "Admin"},
				new AppRole{Name = "Moderator"},
			};

			foreach (var role in roles)
			{
				await roleManager.CreateAsync(role);
			}

			foreach (var user in users)
			{
				user.Photos.First().IsApproved = true;
				user.UserName = user.UserName.ToLower();
				await userManager.CreateAsync(user, "Pa$$w0rd");
				await userManager.AddToRoleAsync(user, "Member");
			}

			var admin = new AppUser
			{
				UserName = "admin"
			};
			await userManager.CreateAsync(admin, "Pa$$w0rd");
			await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
		}
	}
}
