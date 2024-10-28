using Project_Prn212.Models;
using Project_Prn212.Repository.OrderDetails;
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
    /// Interaction logic for ManageOrderDetail.xaml
    /// </summary>
    public partial class ManageOrderDetail : Window
    {
        IEnumerable<OrderDetail> list = null;
        IOrderDetailRepository orderDetailRepository;

        public ManageOrderDetail(IOrderDetailRepository repository)
        {
            InitializeComponent();
            orderDetailRepository = repository;
        }

        public void SetOrderDetailList(int orderId)
        {
            list = orderDetailRepository.GetOrderDetailsByOrderID(orderId);
        }

        private OrderDetail GetOrderDetailObject()
        {
            OrderDetail orderDetail = null;
            try
            {
                orderDetail = new OrderDetail
                {
                    Id = int.Parse(txtId.Text),
                    OrderId = int.Parse(txtOrderId.Text),
                    MenuId = int.Parse(txtMenuId.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = decimal.Parse(txtPrice.Text),
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order Detail");
            }
            return orderDetail;
        }

        public void LoadOrderDetailList()
        {
            lvOrderDetails.ItemsSource = orderDetailRepository.ToViewModels(list);
        }

        public void LoadOrderDetailList(int orderId)
        {
            SetOrderDetailList(orderId);
            lvOrderDetails.ItemsSource = orderDetailRepository.ToViewModels(list);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderDetailList();
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
                OrderDetail orderDetail = GetOrderDetailObject();
                orderDetailRepository.InsertOrderDetail(orderDetail);
                LoadOrderDetailList();
                MessageBox.Show("Order Detail Added Successfully", "Add Order Detail");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order Detail");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailObject();
                orderDetailRepository.UpdateOrderDetail(orderDetail);
                LoadOrderDetailList();
                MessageBox.Show("Order Detail Updated Successfully", "Update Order Detail");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Order Detail");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailObject();
                orderDetailRepository.DeleteOrderDetail(orderDetail);
                LoadOrderDetailList();
                MessageBox.Show("Order Detail Deleted Successfully", "Delete Order Detail");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Order Detail");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Visibility = Visibility.Hidden;
    }
}
