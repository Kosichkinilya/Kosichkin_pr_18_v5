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
            this.Height += 25;
        }
        //Кнопки на основной форме
        private void Add_an_entry(object sender, RoutedEventArgs e)
        {
           // открывает форму добавления студента
            WindowEditAnEntry f = new WindowEditAnEntry();
            f.ShowDialog();
            dataGrid1.Focus();


            //WindowEditAnEntry f = new WindowEditAnEntry();
            //f.ShowDialog();
            //dataGrid1.ItemsSource = null;
            //dataGrid1.ItemsSource = db.Table_1.ToList();
            //dataGrid1.Focus();
        }

        private void Edit_an_entry(object sender, RoutedEventArgs e)
        {
           
        }

        // Удаление студента из списка
        private void Delete_an_entry(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    StudentBase row = (StudentBase)dataGrid1.SelectedItems[0];
                    db.StudentBases.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void Close_the_program(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Имя лучшего разработчика вся РУСИ");
        }

        DB_Students_18Entities db = DB_Students_18Entities.GetContext();


        private void Window_loaded(object sender, RoutedEventArgs e) 
        {
            //загружаем таблицу из БД
            db.StudentBases.Load();
            //загружаем таблицу в дата грид с отслеживанием изменения контекста 
            dataGrid1.ItemsSource = db.StudentBases.Local.ToBindingList();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
