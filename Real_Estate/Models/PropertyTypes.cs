using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class PropertyTypes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<Property>? Properties { get; set; }
    }
}
