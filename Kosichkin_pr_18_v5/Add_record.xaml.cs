using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;

namespace Kosichkin_pr_18_v5
{
    /// <summary>
    /// Логика взаимодействия для WindowEditAnEntry.xaml
    /// </summary>
    public partial class WindowEditAnEntry : Window
    {
        // Если убрать это то будет огромное белое окно 
        public WindowEditAnEntry()
        {
            InitializeComponent();
            this.Height += 15;
        }

        Accounting_for_wholesale_salesEntities db = Accounting_for_wholesale_salesEntities.GetContext();
        private void Button_ok(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (product_name.Text.Length == 0)
                errors.AppendLine("Введите наименование продукта");
            if (admission_price.Text.Length == 0)
                errors.AppendLine("Введите цену поступления");
            if (Book_nbatch_numberumber.Text.Length == 0)
                errors.AppendLine("Введите номер партии ");
            if (batch_size.Text.Length == 0)
                errors.AppendLine("Введите размер партии");
            if (buyers_firm.Text.Length == 0)
                errors.AppendLine("Введите фирму покупателя");
            if (size_of_the_sold.Text.Length == 0)
                errors.AppendLine("Введите размер проданной партии");
            if (buyers_firm.Text.Length == 0)
                errors.AppendLine("Введите цену продажи");


            //if (admission_date.Value != DateTime)
            //    errors.AppendLine("Выберите дату поступления");

            //if (admission_date.Value != DateTime.MinValue)
            //    errors.AppendLine("Выберите дату продажи");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                //return;

            }
            Sales_table p1 = new Sales_table();


            // Инициализация объектов
            p1.Наименование_товара = product_name.Text;
            p1.Цена_поступления = Convert.ToInt32(admission_price.Text);
            p1.Номер_партии = Convert.ToInt32(Book_nbatch_numberumber.Text);
            p1.Размер_партии = Convert.ToInt32(batch_size.Text);
            p1.Фирма_покупателя = (buyers_firm.Text);
            p1.Размер_проданной_партии = Convert.ToInt32(size_of_the_sold.Text);
            p1.Фирма_покупателя = buyers_firm.Text;
            p1.Цена_продажи = Convert.ToInt32(sale_price.Text);

            p1.Дата_поступления = (DateTime)admission_date.SelectedDate;
            p1.Дата_продажи = (DateTime)date_of_sale.SelectedDate;
          


            try
            {
                db.Sales_table.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
