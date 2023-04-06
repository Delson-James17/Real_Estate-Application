using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.Data
{
    public class REDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RealEstateDbContext>();
                context.Database.EnsureCreated();

                //Clients
                if(!context.Clients.Any()) 
                {
                    context.Clients.AddRange(new List<Client>(){
                        new Client()
                        {
                            Name ="John Doe",
                            ContactNumber = "09123456789",
                            Address = "India",
                            Email = "Johndoe@test.com",
                            URLimage="#"
                        }
                });
                    context.SaveChanges();
                }
                //Owner 
                if (!context.Owners.Any())
                {
                    context.Owners.AddRange(new List<Owner>()
                    {
                        new Owner()
                        {
                            Name ="McDoe",
                            ContactNumber="09123456789",
                            Address="Philippines",
                            Email ="mcdoe@test.com",
                            URLimage = "#",
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.PropertyTypes.Any())
                {
                    context.PropertyTypes.AddRange(new List<PropertyTypes>
                    {
                        new PropertyTypes()
                        {
                            Name="Sale",
                            Description="Sale Description"
                        },
                        new PropertyTypes()
                        {
                            Name="Rent",
                            Description="Per Month"
                        },
                      
                    });
                    context.SaveChanges();
                }
                //Properties
                if (!context.Properties.Any())
                {
                    context.Properties.AddRange(new List<Property>()
                    {
                        new Property()
                        {
                            Name = "Congpound",
                            Description = "Sample Description",
                            Address = "Philippines",
                            UrlImages = "https://cf.bstatic.com/xdata/images/hotel/max1280x900/130486568.jpg?k=57fb350c65182db72d4dd5bdfe3a0aca2a1002af2d114940dba6b578f6f65ff5&o=&hp=1",
                            PriceifSale = 200.00,
                            PriceifRent =20.00,
                            PropertytypesID = 1,
                            ownerID = 1,
                            
                        },
                         new Property()
                        {
                            Name = "Payamansyon",
                            Description = "Sample Description",
                            Address = "Philippines",
                            UrlImages = "https://cf.bstatic.com/xdata/images/hotel/max1280x900/130486573.jpg?k=847a193089fc0eecd7766e98e4760973549bf2af9345266f8e1d390a2460b987&o=&hp=1",
                            PriceifSale = 200.00,
                            PriceifRent =20.00,
                            PropertytypesID = 1,
                            ownerID = 1
                        },
                           new Property()
                        {
                            Name = "Congdo",
                            Description = "Sample Description",
                            Address = "Philippines",
                            UrlImages ="https://cf.bstatic.com/xdata/images/hotel/max1280x900/236280245.jpg?k=2d914b6e79def9a29144d26df9c14b677c425f4255b4899d3cd750eb7f41a86a&o=&hp=1",
                            PriceifSale = 200.00,
                            PriceifRent =20.00,
                            PropertytypesID = 1,
                            ownerID = 1
                        }
                    }); 
                    context.SaveChanges();
                }

            }
           
            }
        }
        }
    

