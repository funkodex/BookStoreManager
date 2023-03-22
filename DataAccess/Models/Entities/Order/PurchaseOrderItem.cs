using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities
{
    [Table("purchase_items")]
    public class PurchaseOrderItem : OrderItem
    {

        public long? PurchaseId { get; set; }
        public PurchaseOrder? Purchase { get; set; }
    }


}
