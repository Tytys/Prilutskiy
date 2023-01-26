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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            ListUserDG.ItemsSource = DBEntities.GetContext().User
                .ToList().OrderBy(u => u.UserName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберете пользователя " +
                    "для редактирования");
            }
            else
            {
                NavigationService.Navigate(new 
                    EditUserPage(ListUserDG.SelectedItem as User));
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
