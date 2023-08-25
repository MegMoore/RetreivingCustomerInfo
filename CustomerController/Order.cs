using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerController
{
    public class Order
    {
        public static string? SqlGetAll { get; internal set; }
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    

        public override string ToString()
        {
            return ($"{Id} {CustomerId} {Date} {Description}");
        }

        public static string SqlGetAllOrders = "Select * From Orders;";
        public static string SqlById = "Select * from orders where id = @Id;";
    }
}
