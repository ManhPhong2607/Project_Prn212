using Microsoft.EntityFrameworkCore;
using Project_Prn212.Models;
using Project_Prn212.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prn212.Manager
{
    public class OrderManager
    {
        private static OrderManager instance = null;
        private static readonly object instanceLock = new object();
        private OrderManager() { }
        public static OrderManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManager();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orders = ProjectDb.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orders;
        }

        public Order GetOrderLINQ(Expression<Func<Order, bool>> predicate)
        {
            Order order = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                order = ProjectDb.Orders.Where(predicate).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return order;
        }

        public IEnumerable<Order> GetOrdersLINQ(Expression<Func<Order, bool>> predicate)
        {
            List<Order> orders = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                orders = ProjectDb.Orders.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return orders;
        }

        public IEnumerable<OrderViewModel> ToViewModels(IEnumerable<Order> list)
        {
            List<OrderViewModel> ouput = new List<OrderViewModel>();
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                foreach (var item in list)
                {
                    var viewModel = new OrderViewModel
                    {
                        OrderId = item.OrderId,
                        CustomerId = item.CustomerId,
                        CustomerName = item.Customer == null? string.Empty : item.Customer.Name,
                        Status = item.Status,
                        TableId = item.TableId,
                        TableName = item.Table == null ? string.Empty : item.Table.Name,
                        OrderDate = item.OrderDate,
                        Total = item.Total,
                        AccountId = item.AccountId,
                        UserName = item.Account == null ? string.Empty : item.Account.Username
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

        public Order GetOrderByID(int OrderId)
        {
            Order order = null;
            try
            {
                var ProjectDb = new ProjectPrn212Context();
                order = ProjectDb.Orders.SingleOrDefault(o => o.OrderId == OrderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddNew(Order order)
        {
            try
            {
                Order temp = GetOrderByID(order.OrderId);
                if (temp == null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.Orders.Add(order);
                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order temp = GetOrderByID(order.OrderId);
                if (temp != null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.Entry<Order>(order).State = EntityState.Modified;
                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Order order)
        {
            try
            {
                Order temp = GetOrderByID(order.OrderId);
                if (temp != null)
                {
                    var ProjectDb = new ProjectPrn212Context();
                    ProjectDb.Orders.Remove(order);
                    ProjectDb.OrderDetails.RemoveRange(order.OrderDetails);

                    ProjectDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
