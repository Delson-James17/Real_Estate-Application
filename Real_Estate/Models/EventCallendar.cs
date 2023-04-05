namespace Real_Estate.Models
{
    public class EventCallendar
    {
       public int EvenrID { get; set; } 
       public string Subject { get; set; }
       public string Name { get; set; }
        public int? propertyId { get; set; }
        public Property? Property { get; set; }
        public string ClientName { get; set; }
        public int? ownerId { get; set; }
        public Owner? Owners { get; set; }
        public int? propertytypesId { get; set; }
        public PropertyTypes? PropertyTypes { get; set; }
        public DateTime Start {get;set; }
        public DateTime End { get;set; }
        public string ThemeColor { get; set; }
        public string IsFullDay { get; set; }
    }
}
