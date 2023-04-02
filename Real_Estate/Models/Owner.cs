using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string URLimage { get; set; }
        public List<Property>? Properties { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
