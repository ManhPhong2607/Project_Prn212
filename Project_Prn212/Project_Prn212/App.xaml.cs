using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Project_Prn212.Repository.OrderDetails;
using Project_Prn212.Repository.Orders;

namespace Project_Prn212
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddSingleton<ManageOrder>();

            services.AddSingleton(typeof(IOrderDetailRepository), typeof(OrderDetailRepository));
            services.AddSingleton<ManageOrderDetail>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        public void OpenWindow_Order()
        {
            var order = serviceProvider.GetService<ManageOrder>();
            order.Show();
        }

        public void OpenWindow_OrderDetail(int orderId)
        {
            var orderDetail = serviceProvider.GetService<ManageOrderDetail>();
            orderDetail.Show();
            orderDetail.SetOrderDetailList(orderId);
        }
    }

}
