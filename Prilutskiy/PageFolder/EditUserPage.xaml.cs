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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prilutskiy.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = new User();
        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user.UserId = user.UserId;
            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = DBEntities.GetContext().User
                    .FirstOrDefault(u=>u.UserId==user.UserId);
                user.UserName = LoginTb.Text;
                user.UserPassword = PasswordTb.Text;
                user.RoleId = Int32.Parse(
                    RoleCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListUserPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
