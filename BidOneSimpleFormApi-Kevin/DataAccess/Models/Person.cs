namespace BidOneSimpleFormApi_Kevin.DataAccess.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
