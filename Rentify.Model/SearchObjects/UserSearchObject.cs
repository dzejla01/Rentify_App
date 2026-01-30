// Rentify.Model/SearchObjects/UserSearchObject.cs
namespace Rentify.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? NameFTS { get; set; } 
        public bool? IsActive { get; set; }
        public bool? IsVlasnik { get; set; }
    }
}
