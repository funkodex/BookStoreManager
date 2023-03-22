using System.ComponentModel.DataAnnotations.Schema;
using Audit.EntityFramework;
using Mapster;

namespace DataAccess.Models.Entities
{

    [Table("orders")]
    public class SalesOrder : Order
    {
        public int? OrderNumber { get; set; }
        public List<SalesOrderItem> Items { get; set; } = new();

        public long? CustomerId { get; set; }
        public Customer? Customer { get; set; }


        public Payment? Payment { get; set; }

    }


}
