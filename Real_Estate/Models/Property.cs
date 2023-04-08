using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string UrlImages { get; set; }
        public Double PriceifSale { get; set; }
        public Double PriceifRent { get; set; }
        //relationships 
        [ForeignKey("PropertytypesId")]
        public int? PropertytypesID { get; set; }
        public PropertyTypes? Propertytypes { get; set; }
        

        public int? ownerID { get; set; }
        public Owner? owner { get; set; }

    }
}
