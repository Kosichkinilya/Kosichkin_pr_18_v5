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


        DB_Students_18Entities db = DB_Students_18Entities.GetContext();
        private void Button_ok(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surname.Text.Length == 0) errors.AppendLine("Введите Фамилию");
            if (Name.Text.Length == 0) errors.AppendLine("Введите Имя");
            if (Middle_name.Text.Length == 0) errors.AppendLine("Введите Очество ");
            if (Book_number.Text.Length == 0) errors.AppendLine("Введите Номер зачетной книжки");


            if (Hostel.IsChecked.Value == true)
                if (Mathematics.IsChecked.Value == true)
                    if (Economy.IsChecked.Value == true)
                        if (Accounting.IsChecked.Value == true)
                            if (Physical_culture.IsChecked.Value == true)
                                if (English.IsChecked.Value == true)
                                    if (errors.Length > 0)
                                    {
                                        MessageBox.Show(errors.ToString());
                                        //return;

                                    }

            StudentBase p1 = new StudentBase();

            // Инициализация объектов
            p1.Фамилия = Surname.Text;
            p1.Имя = Name.Text;
            p1.Отчество = Middle_name.Text;
            p1.Номер_зачётной_книжки = Book_number.Text;
            p1.Индекс_группы = Convert.ToInt32(Group_index.Text);
            p1.Живёт_ли_студен_в_общежитии = true;
            p1.Математика = true;
            p1.Экономика = true;
            p1.Бух__учёт = true;
            p1.Физ_ра = true;
            p1.Англ__яз = true;

           //разобраться почему все записывается в таблицу как true

            try
            {
                db.StudentBases.Add(p1);
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
