using Real_EstateApi.Models;

namespace Real_EstateApi.Repository.InMemory
{
    public class PropertyInMemoryRepository : IpropertyRepository // Datastore
    {
        // it will hold the data in runtime and allow to perfrom crud operations

        static List<Property> propertyList = new List<Property>();

        static PropertyInMemoryRepository()
        {
            propertyList.Add(new Property(1, "Congdo", "Congpound Description", "Philippines", "#", 200.00, 20.00));
            propertyList.Add(new Property(1, "Congdo", "Congpound Description", "Philippines", "#", 200.00, 20.00));
        }
        public List<Property> GetAllpropertys()
        {
            return propertyList;
        }

        // get any specific property
        public Property GetpropertyById(int Id)
        {
            return propertyList.FirstOrDefault(x => x.Id == Id);
        }

        // add property into the list
        public Property Addproperty(Property newproperty)
        {
            newproperty.Id = propertyList.Max(x => x.Id)+1; // max id of your list
            propertyList.Add(newproperty);
            return newproperty;
        }

        // update property in the list
        public Property Updateproperty(int propertyId, Property newproperty)
        {
            var oldproperty = propertyList.Find(x => x.Id == propertyId);
            if (oldproperty == null)
                return null;
            propertyList.Remove(oldproperty) ;
            propertyList.Add(newproperty);
            return newproperty;
        }

        // delete 
        public Property Deleteproperty(int propertyId)
        {
            var oldproperty = propertyList.Find(x => x.Id == propertyId);
            if (oldproperty == null)
                return null;
            propertyList.Remove(oldproperty);
            return oldproperty;
        }
    }
}
