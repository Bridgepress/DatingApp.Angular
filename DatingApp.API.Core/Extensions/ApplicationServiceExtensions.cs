using API.Data;
using API.Helpers;
using API.Interfaces;
using DatingApp.Contracts.Repositories;
using DatingApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			
			services.AddScoped<LogUserActivity>();

			var assembly = typeof(ApplicationServiceExtensions).Assembly;
			services.AddMediatR(assembly);
			services.AddSignalR();
			services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("AZURE_SQL_CONNECTION"));
			});

			return services;
		}
	}
}
