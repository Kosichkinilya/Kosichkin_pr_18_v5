using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kosichkin_pr_18_v5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 55;
        }

        private void Add_an_entry(object sender, RoutedEventArgs e)
        {
            // открывает форму добавления студента
            WindowEditAnEntry f = new WindowEditAnEntry();
            f.ShowDialog();
            dataGrid1.Focus();
        }
        // Добавление записи
        private void Add_record(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Sales_table row = (Sales_table)dataGrid1.Items[indexRow];
                Data.Код = row.Код;
                WindowEditAnEntry f = new WindowEditAnEntry();
                f.ShowDialog();
                dataGrid1.Items.Refresh();
                dataGrid1.Focus();
            }

        }
        // Редактирование записи
        private void Redactirovat(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Sales_table row = (Sales_table)dataGrid1.Items[indexRow];
                Data.Код = row.Код;
                Edit_record f = new Edit_record();
                f.ShowDialog();
                dataGrid1.Items.Refresh();
                dataGrid1.Focus();
            }
        }
        //Удаление студента из списка
        private void Delete_an_entry(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Sales_table row = (Sales_table)dataGrid1.SelectedItems[0];
                    db.Sales_table.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        //Закрытие окна
        private void Close_the_program(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //Инфо
        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I LOVE THE PROGRAMMING 💕");
        }

        Accounting_for_wholesale_salesEntities db = Accounting_for_wholesale_salesEntities.GetContext();

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            //загружаем таблицу из БД
            db.Sales_table.Load();
            //загружаем таблицу в дата грид с отслеживанием изменения контекста 
            dataGrid1.ItemsSource = db.Sales_table.Local.ToBindingList();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid1.Items.Count; i++)
            {
                var row = (Sales_table)dataGrid1.Items[i];
                string findContent = row.Код;
                try
                {
                    if (findContent != null && findContent.Contains(txtFind.Text))
                    {
                        object item = dataGrid1.Items[i];
                        dataGrid1.SelectedItem = item;
                        dataGrid1.ScrollIntoView(item);
                        dataGrid1.Focus();
                        break;
                    }
                }
                catch { }
            }
        }
        List<Sales_table> _sales_table;

        private void Button_edit(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                //Получаем ключ текущей записи 
                Sales_table row = (Sales_table)dataGrid1.Items[indexRow];
                Data.Код = row.Код;
                //Открываем форму Редактировать 
                Edit_record f = new Edit_record();
                f.ShowDialog();
                // Обновляем таблицу 
                dataGrid1.Items.Refresh();
                dataGrid1.Focus();
            }

            //private void FilterButton(object sender, RoutedEventArgs e)
            //{
            //    _sales_table = db._sales_table.ToList();
            //    var filtered = _sales_table.Where(_teammember => _teammember.Наименование_товара.Contains(txtFilter.Text));
            //    dataGrid1.ItemsSource = filtered;
            //}


        }
    }
}
