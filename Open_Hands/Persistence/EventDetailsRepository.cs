using Open_Hands.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Open_Hands.Persistence
{
    public class EventDetailsRepository : IEventDetails
    {
        private SQLiteAsyncConnection _connection;

        public EventDetailsRepository()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<EventDetails>();
        }
        public async Task<int> CreateEvent(EventDetails events)
        {
            if (events.EventName == null || events.City == null || events.State == null || events.Street == null || events.Zip == null || events.ContactFirstName == null || events.ContactLastName == null || events.ContactPhoneNum == null)
            {
                var x = 0;
                return x;
            }
            else
            {
                var x = await _connection.InsertAsync(events);
                return x;
            }
        }

        public async Task DeleteEvent(EventDetails events)
        {
            await _connection.DeleteAsync(events);
        }

        public async Task<EventDetails> GetEvent(int id)
        {
            return await _connection.FindAsync<EventDetails>(id);
        }

        public async Task<IEnumerable<EventDetails>> GetEvents()
        {
            IEnumerable<EventDetails> LOED = new List<EventDetails>();
            try
            {
                LOED = await _connection.Table<EventDetails>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LOED;
        }

        public async Task UpdateEvent(EventDetails events)
        {
            await _connection.UpdateAsync(events);
        }
    }
}
