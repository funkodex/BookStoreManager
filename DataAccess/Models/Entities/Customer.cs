using System.ComponentModel.DataAnnotations.Schema;
using Mapster;
using PhoneNumbers;

namespace DataAccess.Models.Entities
{

    public class Customer : IEntity<long>
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<SalesOrder> Orders { get; set; } = new();

    }

    public class CustomerDto
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<long> OrderIds { get; set; } = new();

    }


}
