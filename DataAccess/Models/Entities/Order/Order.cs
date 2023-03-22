namespace DataAccess.Models.Entities
{
    public class Order : IEntity<long>
    {
        public long? Id { get; set; }
        public DateTime IssuedDate { get; set; }

        public decimal Total { get; set; }
    }

}
