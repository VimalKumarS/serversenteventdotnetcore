using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace WebApplication1
{
    internal class RedisNotificationsService : INotificationsService //NotificationsServiceBase
    {
        #region Fields
        

        private const string NOTIFICATIONS_CHANNEL = "NOTIFICATIONS";
        private INotificationsServerSentEventsService _notificationsServerSentEventsService;

        private ConnectionMultiplexer _redis;
        #endregion

        #region Constructor
        public RedisNotificationsService(INotificationsServerSentEventsService notificationsServerSentEventsService, IConfiguration configuration)
           // : base(notificationsServerSentEventsService)
        {
            _notificationsServerSentEventsService = notificationsServerSentEventsService;
            _redis = ConnectionMultiplexer.Connect("localhost");

            ISubscriber subscriber = _redis.GetSubscriber();
            subscriber.Subscribe(NOTIFICATIONS_CHANNEL, async (channel, message) => { await SendSseEventAsync(message); });
            
        }
        #endregion

        #region Methods
        public Task SendNotificationAsync(string notification)
        {
            ISubscriber subscriber = _redis.GetSubscriber();

            return subscriber.PublishAsync(NOTIFICATIONS_CHANNEL, notification);
        }
        #endregion

        protected Task SendSseEventAsync(string notification)
        {
            return _notificationsServerSentEventsService.SendEventAsync(new ServerSentEvent
            {
                Data = new List<string>(notification.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
            });
        }
    }
}
