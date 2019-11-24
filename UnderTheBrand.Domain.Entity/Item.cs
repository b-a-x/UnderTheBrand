using System;

namespace UnderTheBrand.Domain.Entity
{
    public class Item : Core.Base.EntityObject
    {
        public Item() : base(Guid.NewGuid().ToString())
        {
        }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}