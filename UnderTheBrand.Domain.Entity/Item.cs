namespace UnderTheBrand.Domain.Entity
{
    public class Item : Core.Base.EntityObject
    {
        public Item() { }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}