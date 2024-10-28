using Project_Prn212.Manager;
using Project_Prn212.Models;
using Project_Prn212.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prn212.Repository.Orders
{
    public class OrderRepository: IOrderRepository
    {
        public IEnumerable<Order> GetOrders() => OrderManager.Instance.GetOrders();
        public Order GetOrderByID(int orderId) => OrderManager.Instance.GetOrderByID(orderId);
        public void InsertOrder(Order order) => OrderManager.Instance.AddNew(order);
        public void UpdateOrder(Order order) => OrderManager.Instance.Update(order);
        public void DeleteOrder(Order order) => OrderManager.Instance.Delete(order);
        public IEnumerable<OrderViewModel> ToViewModels(IEnumerable<Order> list) => OrderManager.Instance.ToViewModels(list);
        public Order GetOrderLINQ(Expression<Func<Order, bool>> predicate) => OrderManager.Instance.GetOrderLINQ(predicate);
        public IEnumerable<Order> GetOrdersLINQ(Expression<Func<Order, bool>> predicate) => OrderManager.Instance.GetOrdersLINQ(predicate);
    }
}
