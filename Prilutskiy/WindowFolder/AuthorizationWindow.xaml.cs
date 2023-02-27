using Prilutskiy.ClassFolder;
using Prilutskiy.DataFolder;
using Prilutskiy.WindowFolder.AdminFolder;
using Prilutskiy.WindowFolder.StaffFolder;
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

namespace Prilutskiy.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPsb.Focus();
            }
            else
            {
                try
                {
                    var user=DBEntities.GetContext().
                        User.FirstOrDefault(u=>u.UserName==LoginTb.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Введен не верный логин");
                        LoginTb.Focus();
                        return;
                    }
                    if (user.UserPassword!=PasswordPsb.Password)
                    {
                        MBClass.ErrorMB("Введен не верный пароль");
                        PasswordPsb.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.RoleId)
                        {
                            case 1:
                                new MainWindow().Show();
                                Close();
                                break;
                            case 2:
                                new ReaderListWindow().Show();
                                Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
        }
    }
}
