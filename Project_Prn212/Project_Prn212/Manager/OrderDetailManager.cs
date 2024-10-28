using Project_Prn212.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Prn212.ViewModel;
using System.Linq.Expressions;

namespace Project_Prn212.Manager
{
    public class OrderDetailManager
    {
        private static OrderDetailManager instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailManager() { }
        public static OrderDetailManager Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new OrderDetailManager();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orderDetails = ProjectDb.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orderDetails;
        }

        public OrderDetail GetOrderDetailLINQ(Expression<Func<OrderDetail, bool>> predicate)
        {
            OrderDetail orderDetail = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orderDetail = ProjectDb.OrderDetails.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return orderDetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsLINQ(Expression<Func<OrderDetail, bool>> predicate)
        {
            List<OrderDetail> orderDetails = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orderDetails = ProjectDb.OrderDetails.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return orderDetails;
        }

        public IEnumerable<OrderDetailViewModel> ToViewModels(IEnumerable<OrderDetail> list)
        {
            List<OrderDetailViewModel> ouput = new List<OrderDetailViewModel>();
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                foreach(var item in list)
                {
                    var viewModel = new OrderDetailViewModel
                    {
                        Id = item.Id,
                        OrderId = item.OrderId,
                        MenuId = item.MenuId,
                        MenuName = item.Menu == null ? string.Empty : item.Menu.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                    };
                    ouput.Add(viewModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ouput;
        }

        public OrderDetail GetOrderDetailByID(int OrderDetailId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orderDetail = ProjectDb.OrderDetails.SingleOrDefault(detail => detail.Id == OrderDetailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderID(int orderID)
        {
            List<OrderDetail> orderDetails;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orderDetails = ProjectDb.OrderDetails.Where(detail => detail.OrderId == orderID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail temp = GetOrderDetailByID(orderDetail.Id);
                if(temp == null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.OrderDetails.Add(orderDetail);
                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Detail already exist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail temp = GetOrderDetailByID(orderDetail.Id);
                if (temp != null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Detail does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail temp = GetOrderDetailByID(orderDetail.Id);
                if (temp != null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.OrderDetails.Remove(orderDetail);
                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order Detail does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
