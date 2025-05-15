using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyFavToDoApp.Services;
using MyFavToDoApp.ViewModel;

namespace MyFavToDoApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userName = UserName.Text;
            var password = Password.Password;

            if(!(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)))
            {
                var authRequest = new 
                {
                    UserName = userName,
                    Password = password
                };

                var response = ApiService.Http.PostAsJsonAsync("api/login", authRequest).Result;
                if(response.IsSuccessStatusCode)
                {
                    ToDoViewModel.AuthStatus.IsAuthenticated = true;
                    ToDoViewModel.AuthStatus.Token =  JsonSerializer.Deserialize<JwtToken>(response.Content.ReadAsStringAsync().Result).Token;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

        }
        
        private class JwtToken
        {
            public string Token { get; set; }
        }
    }
}
