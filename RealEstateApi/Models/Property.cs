using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Real_EstateApi.Models
{
    public class Property // resource, Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string UrlImages { get; set; }
        public Double PriceifSale { get; set; }
        public Double PriceifRent { get; set; }

        public Property()
        {
            
        }
        public Property(int id, string name, string description, string address, string urlImages, double priceifSale, double priceifRent)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            UrlImages = urlImages;
            PriceifSale = priceifSale;
            PriceifRent = priceifRent;
        }
    }
}
