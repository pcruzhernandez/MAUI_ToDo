using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using TodoREST.Services;
using TodoREST.Views;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm;

namespace TodoREST.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        readonly ILoginRepository loginRepository = new LoginService();

        [ICommand]
        public async void Login()
        {
            if (!string.IsNullOrWhiteSpace(this._userName) && !string.IsNullOrWhiteSpace(Password))
            {

                List<UserInfo> userInfo = await loginRepository.Login(this._userName, this._password);

                if(Preferences.ContainsKey(nameof(UserInfo))) 
                { 
                    Preferences.Remove(nameof(UserInfo));
                }

                if (userInfo.Count == 0) 
                {
                    await Application.Current.MainPage.DisplayAlert("Attention", "The data entered is incorrect.", "Ok");
                }
                else
                { 
                    string userDetails = JsonConvert.SerializeObject(userInfo);
                    Preferences.Set(nameof(UserInfo), userDetails);
                    //UserInfo = userInfo;

                    await Shell.Current.GoToAsync($"//{nameof(TodoListPage)}");
                    //App.Current.MainPage = new NavigationPage(new TodoListPage());
                }
            }

        }
    }
}
