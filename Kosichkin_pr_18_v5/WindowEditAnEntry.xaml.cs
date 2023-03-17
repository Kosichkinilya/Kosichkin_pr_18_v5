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

namespace Kosichkin_pr_18_v5
{
    /// <summary>
    /// Логика взаимодействия для WindowEditAnEntry.xaml
    /// </summary>
    public partial class WindowEditAnEntry : Window
    {
        
        public WindowEditAnEntry()
        {
            InitializeComponent();
        }

        private void Button_ok(object sender, RoutedEventArgs e)
        {

        }

        private void Button_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
