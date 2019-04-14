using System.Threading.Tasks;

namespace WebApplication1
{
    public interface INotificationsService
    {
        Task SendNotificationAsync(string notification);
    }
}
