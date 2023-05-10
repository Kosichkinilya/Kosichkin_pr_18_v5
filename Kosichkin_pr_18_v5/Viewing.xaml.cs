using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Kosichkin_pr_18_v5
{
    /// <summary>
    /// Логика взаимодействия для Viewing.xaml
    /// </summary>
    public partial class Viewing : Window
    {
        public Viewing()
        {
            InitializeComponent();
            Height += 25;
        }
        Accounting_for_wholesale_salesEntities db = Accounting_for_wholesale_salesEntities.GetContext();
        Sales_table p1;
        private void Button_ok(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Sales_table.Find(Data.Код);
            product_name.Text = p1.Наименование_товара;
            admission_price.Text = p1.Цена_поступления.ToString();
            Book_nbatch_numberumber.Text = p1.Номер_партии.ToString();
            batch_size.Text = p1.Номер_партии.ToString();
            buyers_firm.Text = p1.Фирма_покупателя;

            size_of_the_sold.Text = p1.Размер_проданной_партии.ToString();
            sale_price.Text = p1.Цена_продажи.ToString();
            admission_date.SelectedDate = p1.Дата_поступления;
            date_of_sale.SelectedDate = p1.Дата_продажи;
        }
    }
}

