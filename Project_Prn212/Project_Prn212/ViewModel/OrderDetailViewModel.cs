using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prn212.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? MenuId { get; set; }
        public string? MenuName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
