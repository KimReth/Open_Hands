﻿using Open_Hands.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
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
            var x = await _connection.InsertAsync(events);
            return x;
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
            var y = await _connection.Table<EventDetails>().ToListAsync();
            return y;
        }

        public async Task UpdateEvent(EventDetails events)
        {
            await _connection.UpdateAsync(events);
        }
    }
}
