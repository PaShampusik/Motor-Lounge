using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Services.MongoDB
{
        public interface IMongoDBService
        {
            Task<List<T>> GetAllAsync<T>();
            Task<T> GetByIdAsync<T>(string id);
            Task InsertAsync<T>(T item);
            Task UpdateAsync<T>(string id, T item);
            Task DeleteAsync<T>(string id);
        }
}
