using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Kosichkin_pr_18_v5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        //Кнопки на основной форме
        private void Add_an_entry(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_an_entry(object sender, RoutedEventArgs e)
        {
            //открывает дополнительное окно
            WindowEditAnEntry f = new WindowEditAnEntry();
            f.ShowDialog();
           // dataGrid1.Focus();
        }

        private void Delete_an_entry(object sender, RoutedEventArgs e)
        {

        }

        private void Close_the_program(object sender, RoutedEventArgs e)
        {
            Close();
        }


        StudentBase dataGrid1 = StudentBase.GetContext();
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            //dataGrid1.StudentBase.Load();
            //dataGrid1.ItemsSource = dataGrid1.Student.Local.ToBindingList();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
