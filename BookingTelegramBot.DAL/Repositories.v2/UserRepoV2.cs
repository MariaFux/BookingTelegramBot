using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces.v2;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories.v2
{
    public class UserRepoV2 : IUserRepo
    {
        string connectionString = null;

        public UserRepoV2(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConstr");
        }        

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = await conn.QueryAsync<User>("SELECT * FROM Users");
                return query.ToList();
            }                
        }

        public async Task<User> FindByTelegramIdAsync(int telegramId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Users WHERE TelegramId = @telegramId";
                var result = await conn.QueryAsync<User>(query, new { telegramId });
                return result.FirstOrDefault();
            }
        }

        public void Insert(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Users (TelegramId) VALUES(@TelegramId)";
                conn.Execute(query, user);
            }
        }

        public void Update(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "UPDATE Users SET TelegramId = @TelegramId WHERE Id = @Id";
                conn.Execute(query, user);
            }
        }
    }
}
