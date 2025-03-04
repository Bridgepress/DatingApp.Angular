﻿using API.Data;
using API.Entities;
using DatingApp.Domain.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
	public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddIdentityCore<AppUser>(opt =>
			{
				opt.Password.RequireNonAlphanumeric = false;
			})
			   .AddRoles<AppRole>()
			   .AddRoleManager<RoleManager<AppRole>>()
			   .AddEntityFrameworkStores<DataContext>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			   .AddJwtBearer(options =>
			   {
				   options.TokenValidationParameters = new TokenValidationParameters
				   {
					   ValidateIssuerSigningKey = true,
					   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
					   ValidateIssuer = false,
					   ValidateAudience = false,
				   };
				   options.Events = new JwtBearerEvents
				   {
					   OnMessageReceived = context =>
					   {
						   var accessToken = context.Request.Query["access_token"];

						   var path = context.HttpContext.Request.Path;
						   if (!string.IsNullOrEmpty(accessToken) &&
							   path.StartsWithSegments("/hubs"))
						   {
							   context.Token = accessToken;
						   }

						   return Task.CompletedTask;
					   }
				   };
			   });

			services.AddAuthorization(opt =>
			{
				opt.AddPolicy(MyPolicies.RequireAdminRole, policy => policy.RequireRole(MyRoles.Admin));
				opt.AddPolicy(MyPolicies.ModeratePhotoRole, policy => policy.RequireRole(MyRoles.Admin, MyRoles.Moderator));
			});

			return services;
		}
	}
}
