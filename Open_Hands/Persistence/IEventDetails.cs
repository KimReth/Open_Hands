using Open_Hands.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open_Hands.Persistence
{
    public interface IEventDetails
    {
        Task<IEnumerable<EventDetails>> GetEvents();
        Task<int> CreateEvent(EventDetails events);
        Task<EventDetails> GetEvent(int id);
        Task UpdateEvent(EventDetails events);
        Task DeleteEvent(EventDetails events);
    }
}
