using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities
{
    public class PurchaseOrder : Order
    {
        public List<PurchaseOrderItem> Items { get; set; } = new();
        public long? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }


}
