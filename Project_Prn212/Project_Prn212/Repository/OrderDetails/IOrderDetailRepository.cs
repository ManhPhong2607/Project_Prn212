using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Project_Prn212.Models;
using Project_Prn212.ViewModel;

namespace Project_Prn212.Repository.OrderDetails
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int orderID);
        OrderDetail GetOrderDetailByID(int orderDetailId);
        void InsertOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetailViewModel> ToViewModels(IEnumerable<OrderDetail> list);
        OrderDetail GetOrderDetailLINQ(Expression<Func<OrderDetail, bool>> predicate);
        IEnumerable<OrderDetail> GetOrderDetailsLINQ(Expression<Func<OrderDetail, bool>> predicate);
    }
}
