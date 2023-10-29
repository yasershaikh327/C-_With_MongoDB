using Database_Access.Mapper.UIMapper.Model;

namespace API.Mapper.UIMapper.Model
{
    public class Customer
    {
        public string Id { get; set; } 
        public string FirstName {  get; set; }  
        public string LastName {  get; set; }
        public DateTime DOB { get; set; }

    }
}
