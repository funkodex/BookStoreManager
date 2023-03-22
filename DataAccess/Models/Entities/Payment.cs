using DataAccess.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Entities
{

    public class Payment : IEntity<long>
    {
        public long? Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TenderedAmount { get; set; }
        public decimal DueAmount { get; set; }
        public decimal? DiscountAmount { get; set; }

        public long OrderId { get; set; }

        public SalesOrder Order { get; set; }

    }
}



namespace DataAccess.Models.Dtos
{
    public class PaymentDto
    {
        public long? Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TenderedAmount { get; set; }
        public decimal DueAmount { get; set; }
        public decimal? DiscountAmount { get; set; }

        public long OrderId { get; set; }
    }
}

