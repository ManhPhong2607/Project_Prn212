using Project_Prn212.Manager;
using Project_Prn212.Models;
using Project_Prn212.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prn212.Repository.OrderDetails
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailByID(int orderDetailId) => OrderDetailManager.Instance.GetOrderDetailByID(orderDetailId);
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailManager.Instance.GetOrderDetails();
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int orderID) => OrderDetailManager.Instance.GetOrderDetailsByOrderID(orderID);
        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailManager.Instance.AddNew(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailManager.Instance.Update(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailManager.Instance.Delete(orderDetail);
        public IEnumerable<OrderDetailViewModel> ToViewModels(IEnumerable<OrderDetail> list) => OrderDetailManager.Instance.ToViewModels(list);
        public OrderDetail GetOrderDetailLINQ(Expression<Func<OrderDetail, bool>> predicate) => OrderDetailManager.Instance.GetOrderDetailLINQ(predicate);
        public IEnumerable<OrderDetail> GetOrderDetailsLINQ(Expression<Func<OrderDetail, bool>> predicate) => OrderDetailManager.Instance.GetOrderDetailsLINQ(predicate);
    }
}

