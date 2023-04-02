namespace Real_Estate.Models
{
    public class Appointment
    {
       public int Id { get; set; }
       public int?propertyId { get; set; }
       public Property? Property { get; set; }   
       public int? clientId { get; set; }
       public Client? Clients { get; set; }
       public int?ownerId { get; set; }
       public Owner? Owners { get; set; }
       public int? propertytypesId { get; set; }
       public PropertyTypes? PropertyTypes { get; set; }
       public string? Status { get; set; }
       
    }
}
