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
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<OrderViewModel> ToViewModels(IEnumerable<Order> list);
        Order GetOrderLINQ(Expression<Func<Order, bool>> predicate);
        IEnumerable<Order> GetOrdersLINQ(Expression<Func<Order, bool>> predicate);
    }
}
