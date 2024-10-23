using Project_Prn212.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_Prn212
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Login lg = new Login();
            //lg.Name = txtUsername.Text;
            //lg.Password = txtPassword.Password;
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            
        }
    }

        private bool AuthenticateUser(object username, object password)
        {
            using (var dbContext = new ProjectPrn212Context())
            {
                var user = dbContext.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user != null;
            }
        }
    }
}
