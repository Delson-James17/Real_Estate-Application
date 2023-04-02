using Real_EstateApi.Models;

namespace Real_EstateApi.Repository
{
    public interface IpropertyRepository // contract 
    {
        List<Property> GetAllpropertys();

        // get any specific property
        Property GetpropertyById(int Id);

        // add property into the list
        Property Addproperty(Property newproperty);

        // update property in the list
        Property Updateproperty(int propertyId, Property newproperty);

        // delete 
        Property Deleteproperty(int propertyId);
    }
}
