using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;
using Microsoft.AspNetCore.Http;

namespace WebApplication1
{
    internal class NotificationsServerSentEventsService : ServerSentEventsService, INotificationsServerSentEventsService
    {
        public NotificationsServerSentEventsService()
        {
            ChangeReconnectIntervalAsync(5000);
        }

        public override Task OnConnectAsync(HttpRequest request, IServerSentEventsClient client)
        {
            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Andras")
                , new Claim(ClaimTypes.Country, "Sweden")
                , new Claim(ClaimTypes.Gender, "M")
                , new Claim(ClaimTypes.Surname, "Nemes")
                , new Claim(ClaimTypes.Email, "hello@me.com")
                , new Claim(ClaimTypes.Role, "IT")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection);
            client.User.AddIdentity(claimsIdentity);
            return base.OnConnectAsync(request, client);
        }

        public override Task OnDisconnectAsync(HttpRequest request, IServerSentEventsClient client)
        {
            return base.OnDisconnectAsync(request, client);
        }

    }
}
