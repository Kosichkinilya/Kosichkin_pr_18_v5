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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private Accounting_for_wholesale_salesEntities _db = Accounting_for_wholesale_salesEntities.GetContext();
        UserData p1 = new UserData();

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text)) return;
            if (string.IsNullOrEmpty(txtPassword.Password)) return;

            var user = _db.UserDatas.Where(p => p.Login == txtLogin.Text).FirstOrDefault();
            if (user == null)
            {
                message.Text = "Пользователя с таким логином не существует";
                return;
            }

            if (user.Password != txtPassword.Password)
            {
                message.Text = "Пароль не верен";
                return;
            }

            MainWindow window = new MainWindow(user);
            this.Close();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

