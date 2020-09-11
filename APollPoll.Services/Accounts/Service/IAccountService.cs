using APollPoll.Services.Accounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Accounts.Service
{
    public interface IAccountService
    {
        Task<LoginResponse> GetLoginResponseAsync(LoginRequest request);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
    }
}
