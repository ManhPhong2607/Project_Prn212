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

namespace Project_Prn212
{
    /// <summary>
    /// Interaction logic for ManagerTables.xaml
    /// </summary>
    public partial class ManagerTables : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        public ManagerTables()
        {
            InitializeComponent();
            LoadTables();

        }

        private void LoadTables()
        {
            dgTables.ItemsSource = context.Tables.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
