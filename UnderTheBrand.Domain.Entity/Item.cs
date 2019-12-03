using UnderTheBrand.Domain.Entity.Base;

namespace UnderTheBrand.Domain.Entity
{
    public class Item : HasId
    {
        public Item() { }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}