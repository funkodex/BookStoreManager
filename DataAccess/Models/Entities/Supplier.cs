namespace DataAccess.Models.Entities
{
    public class Supplier : IEntity<long>
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<PurchaseOrder> Purchases { get; set; }
        public List<SupplierPayment> Payments { get; set; }
        public List<ProductSupplier> SupplierProducts { get; set; }

        public decimal DebtOwed { get; set; }
        public decimal DebtPayed { get; set; }
    }

    public class SupplierDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal DebtOwed { get; set; }
        public decimal DebtPayed { get; set; }
    }


}
