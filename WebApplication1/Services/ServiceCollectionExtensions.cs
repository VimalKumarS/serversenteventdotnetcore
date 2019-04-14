using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    internal static class ServiceCollectionExtensions
    {
        #region Fields
        private const string NOTIFICATIONS_SERVICE_TYPE_CONFIGURATION_KEY = "NotificationsService";
        private const string NOTIFICATIONS_SERVICE_TYPE_LOCAL = "Local";
        private const string NOTIFICATIONS_SERVICE_TYPE_REDIS = "Redis";
        #endregion

        #region Methods
        public static IServiceCollection AddNotificationsService(this IServiceCollection services, IConfiguration configuration)
        { 
                services.AddSingleton<INotificationsService, RedisNotificationsService>();          


            return services;
        }
        #endregion
    }
}
