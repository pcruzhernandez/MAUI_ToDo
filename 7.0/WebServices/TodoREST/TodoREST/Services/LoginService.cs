using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST.Services
{
    public class LoginService : ILoginRepository
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<UserInfo> Users { get; private set; }
        public async Task<List<UserInfo>> Login(string username, string password)
        {
            try
            {
                Users = new List<UserInfo>();
                _client = new HttpClient();
                var userInfo = new UserInfo();
                Uri uri = new Uri(string.Format("https://nightlast.es/wsusers.asmx/GetAllUsersJSON?Username=" + username.ToString()+"&Password="+password, string.Empty));
                try
                {
                    HttpResponseMessage response = await _client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Users = JsonSerializer.Deserialize<List<UserInfo>>(content, _serializerOptions);
                        return Users;

                        //userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
                        //return await Task.FromResult(userInfo);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
    }
}
