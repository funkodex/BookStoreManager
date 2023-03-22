namespace DataAccess.Models.Entities;

public class Employee : IEntity<long>
{
    public long? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PrimaryPhonenmber { get; set; }
    public string? SecondaryPhonenmber { get; set; }
    public List<EmployeeShift> Shifts { get; set; }

    public string? AccountId { get; set; }
    public AppUser? Account { get; set; }
}

public class EmployeeShift : IEntity<long>
{
    public long? Id { get; set; }
    public DateTime date { get; set; }

    public Employee Employee { get; set; }

    public List<EmployeeShiftEntry> Entries { get; set; }
}

public class EmployeeShiftEntry : IEntity<long>
{
    public long? Id { get; set; }
    TimeOnly enter;
    TimeOnly exit;
    string? note;
}

public class EmployeeDto 
{
    public long? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PrimaryPhonenmber { get; set; }
    public string? SecondaryPhonenmber { get; set; }

    public long? AccountId { get; set; }
}