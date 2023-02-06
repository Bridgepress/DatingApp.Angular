using API.Data;
using API.Helpers;
using API.Interfaces;
using API.SignalR;
using DatingApp.Contracts.Repositories;
using DatingApp.DataAccess.Repositories;
using DatingApp.Domain.Interfaces;
using DatingApp.Domain.Services;
using DatingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MediatR;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<PresenceTracker>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessagesService, MessagesService>();
            services.AddScoped<LogUserActivity>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
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
