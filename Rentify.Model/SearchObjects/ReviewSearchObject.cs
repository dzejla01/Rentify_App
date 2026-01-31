using Rentify.Model.SearchObjects;

namespace Rentify.Model.SearchObjects
{
    public class ReviewSearchObject : BaseSearchObject
    {
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }

        public int? MinStarRate { get; set; }
        public int? MaxStarRate { get; set; }
    }
}
