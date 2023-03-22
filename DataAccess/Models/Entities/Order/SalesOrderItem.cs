using Audit.EntityFramework;
using Mapster;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities
{

    [AuditInclude]
    [Table("order_items")]
    public class SalesOrderItem : OrderItem
    {
        public long? OrderId { get; set; }
        public SalesOrder? Order { get; set; }
    }

}
