using APollPoll.Data.Constants;
using APollPoll.Services.Accounts.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Accounts.Service
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        public AccountService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(LearningGymData.LgAPIUrl);
        }

        public async Task<LoginResponse> GetLoginResponseAsync(LoginRequest request)
        {
            var lgResponse = await _client.PostAsync("auth/login", GetStringContent(request));

            return await lgResponse.Content.ReadAsAsync<LoginResponse>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = new List<User>();
            using (var connection = new NpgsqlConnection(LearningGymData.LgConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM public.user", connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (await reader.ReadAsync())
                    {
                        users.Add(GetUserData(reader));
                    }

                    connection.Close();
                }
            }
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id) => await GetUserByQueryAsync($"id='{id}'");

        public async Task<User> GetUserByEmailAsync(string email) => await GetUserByQueryAsync($"email='{email}'");

        private async Task<User> GetUserByQueryAsync(string whereCondition)
        {
            User user = null;
            using (var connection = new NpgsqlConnection(LearningGymData.LgConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM public.user WHERE {whereCondition}", connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (await reader.ReadAsync())
                    {
                        user = GetUserData(reader);
                    }

                    connection.Close();
                }
            }
            return user;
        }

        private StringContent GetStringContent(object model) =>
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

        private User GetUserData(NpgsqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader[0],
                Role = reader[1] as string,
                FirstName = reader[2] as string,
                LastName = reader[3] as string,
                Email = reader[4] as string
            };
        }
    }
}
