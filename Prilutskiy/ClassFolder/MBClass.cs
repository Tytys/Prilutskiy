using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prilutskiy.ClassFolder
{
    class MBClass
    {
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ErrorMB(Exception text)
        {
            MessageBox.Show(text.Message, "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool QuestionMB(string text)
        {
            return MessageBoxResult.Yes == 
                MessageBox.Show(text, "Вопрос",  MessageBoxButton.YesNo
                , MessageBoxImage.Question);
        }

        public static void ExitMB()
        {
            if (QuestionMB("Вы действительно хотите выйти?"))
            {
                App.Current.Shutdown();
            }
        }

        public static void InfoMB(string text)
        {
            MessageBox.Show(text, "Информация", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
