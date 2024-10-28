using Project_Prn212.Models;
using Project_Prn212.Repository.Orders;
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
    /// Interaction logic for ManageOrder.xaml
    /// </summary>
    public partial class ManageOrder : Window
    {
        App app = (App)App.Current;
        IOrderRepository orderRepository;
        public ManageOrder(IOrderRepository repository)
        {
            InitializeComponent();
            orderRepository = repository;
            LoadOrderList();
        }

        private Order GetOrderObject()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    CustomerId = int.Parse(txtCustomerId.Text),
                    TableId = int.Parse(txtTableId.Text),
                    OrderDate = DateTime.Parse(dpOrderDate.Text),
                    Total = decimal.Parse(txtTotal.Text),
                    Status = txtStatus.Text,
                    AccountId = int.Parse(txtAccountId.Text),
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order");
            }
            return order;
        }

        private int GetOrderId()
        {
            return int.Parse(txtOrderId.Text);
        }

        public void LoadOrderList()
        {
            var temp = orderRepository.GetOrders();
            lvOrders.ItemsSource = orderRepository.ToViewModels(temp);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order List");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                orderRepository.InsertOrder(order);
                LoadOrderList();
                MessageBox.Show("Order Added Successfully", "Add Order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                orderRepository.UpdateOrder(order);
                LoadOrderList();
                MessageBox.Show("Order Updated Successfully", "Update Order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Order");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                orderRepository.UpdateOrder(order);
                LoadOrderList();
                MessageBox.Show("Order Deleted Successfully", "Delete Order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Order");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Visibility = Visibility.Hidden;

        private void lvOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = GetOrderId();
            app.OpenWindow_OrderDetail(temp);
        }
    }
}
