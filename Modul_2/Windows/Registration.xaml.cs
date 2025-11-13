using Azure.Core;
using Modul_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modul_2
{
    public partial class Registration : Window
    {
        private readonly Database _context;
        public User addedUser { get; set; } = new User();
        public Registration()
        {
            InitializeComponent();
            _context = new Database();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text != null && Password.Text != null &&
                    Fio.Text != null)
                {
                    string login = _context.Users.FirstOrDefault(q => q.Login == Login.Text)?.Login;
                    if (login != null)
                    {
                        MessageBox.Show("Логин занят");
                    }
                    else
                    {
                        var role = _context.Roles.FirstOrDefault(q => q.Role1 == "Авторизированный клиент");
                        if (role == null)
                        {
                            MessageBox.Show("Role 'Авторизированный клиент' not find");
                            return;
                        }

                        addedUser = new User
                        {
                            IdRole = role.Id,
                            Fio = Fio.Text,
                            Login = Login.Text,
                            Pass = Password.Text
                        };

                        DialogResult = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalide data");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\nInner exception: " + ex.InnerException.Message;
                }
                MessageBox.Show($"Load error in Reg window: {errorMessage}");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
