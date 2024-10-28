using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Prn212
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageTables_Click(object sender, RoutedEventArgs e)
        {
            ManagerTables tablesWindow = new ManagerTables();
            tablesWindow.Show();
        }

        private void ManageMenu_Click(object sender, RoutedEventArgs e)
        {
            ManageMenu menuWindow = new ManageMenu();
            menuWindow.Show();
        }

        private void ManageOrder_Click(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            app.OpenWindow_Order();
        }
    }
}