using Prilutskiy.ClassFolder;
using Prilutskiy.DataFolder;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string cif = "1234567890";
            string znak = "!@#$%^&*()";
            string buk = "qwertyuiopasdfghjklzxcvbnm";
            string ZaglBuk = "QWERTYUIOPPASDFGHJKLZXCVBNM";

            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введеите логин");
                LoginTb.Focus();
            }
            else if (DBEntities.GetContext()
                .User.FirstOrDefault(u
                =>u.UserName==LoginTb.Text)
                != null)
            {
                MBClass.ErrorMB("Такой логин уже существует");
                LoginTb.Focus();
            }
            else if(string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPsb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordDoubleTb.Text))
            {
                MBClass.ErrorMB("Повторите пароль");
                PasswordDoubleTb.Focus();
            }
            else if(PasswordPsb.Password.
                IndexOfAny(znak.ToCharArray()) < 0)
            {
                MBClass.ErrorMB("В пароле должно содержаться " +
                    "!@#$%^&*()");
                PasswordPsb.Focus();
            }
            else if(PasswordPsb.Password.
                IndexOfAny(buk.ToCharArray()) < 0)
            {
                MBClass.ErrorMB("В пароле должна содержаться " +
                   "строчная буква");
                PasswordPsb.Focus();
            }
            else if (PasswordPsb.Password.
                IndexOfAny(ZaglBuk.ToCharArray()) < 0)
            {
                MBClass.ErrorMB("В пароле должна содержаться " +
                   "заглавная буква");
                PasswordPsb.Focus();
            }
            else if (PasswordPsb.Password.
                IndexOfAny(cif.ToCharArray()) < 0)
            {
                MBClass.ErrorMB("В пароле должна содержаться " +
                   "цифра");
                PasswordPsb.Focus();
            }
            else if (PasswordPsb.Password != PasswordDoubleTb.Text)
            {
                MBClass.ErrorMB("Пароли должны совпадать");
                PasswordPsb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        UserName = LoginTb.Text,
                        UserPassword = PasswordPsb.Password,
                        RoleId=2
                    });
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь успешно зарегестрирован");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }
    }
}
