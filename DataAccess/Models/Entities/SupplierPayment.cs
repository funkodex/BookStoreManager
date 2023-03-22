using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities
{
    [Table("supplier_payments")]
    public class SupplierPayment : IEntity<long>
    {
        public long? Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}

