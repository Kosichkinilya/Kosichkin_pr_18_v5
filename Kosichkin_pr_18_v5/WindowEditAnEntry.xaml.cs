using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        
        public WindowEditAnEntry()
        {
            InitializeComponent();
            this.Height += 50;
        }

        private void Button_ok(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surname.Text.Length == 0) errors.AppendLine("Введите Фамилию");
            if (Name.Text.Length == 0) errors.AppendLine("Введите Имя");
            if (Middle_name.Text.Length == 0) errors.AppendLine("Введите Очество ");
            if (Book_number.Text.Length == 0) errors.AppendLine("Введите Номер зачетной книжки");
            if (Group_index.Text.Length == 0) errors.AppendLine("Введите Индекс группы");
            if (habitation.Text.Length == 0)
                errors.AppendLine("Укажите место важего проживания");
            if (Mathematics.Text.Length == 0)
                errors.AppendLine("Укажите хотите ли вы изучать данную дисциплину");
            if (Economy.Text.Length == 0)
                errors.AppendLine("Укажите хотите ли вы изучать данную дисциплину");
            if (accounting_service.Text.Length == 0)
                errors.AppendLine("Укажите хотите ли вы изучать данную дисциплину");
            if (Physical_culture.Text.Length == 0)
                errors.AppendLine("Укажите хотите ли вы изучать данную дисциплину");
            if (English.Text.Length == 0)
                errors.AppendLine("Укажите хотите ли вы изучать данную дисциплину");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                //return;

            }

            Table_1 p1 = new Table_1();
            //Table_1 заменить на StudentBase 

            p1.Фамилия = Surname.Text;
            p1.Имя = Name.Text;
            p1.Очество = Middle_name.Text;
            p1.Номер_зачетной_книжки = Convert.ToInt32(Book_number.Text);
            p1.Живет_ли_студент_в_общежитии = habitation.Text;
            p1.Индекс_группы = Convert.ToInt32(Group_index.Text);
            p1.Математика = Mathematics.Text;
            p1.Экономика = Economy.Text;
            p1.Бухгалтерский_учет = accounting_service.Text;
            p1.Физкультура = Physical_culture.Text;
            p1.Английский_язык = English.Text;

            try
            {
                db.Table_1.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
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
