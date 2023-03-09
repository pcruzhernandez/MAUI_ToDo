using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST.Services
{
    internal interface ILoginRepository
    {
        Task<List<UserInfo>> Login(string username, string password);
    }
}
