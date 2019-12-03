namespace UnderTheBrand.Domain.Entity
{
    public class Item : Core.Base.HasIdBase
    {
        public Item() { }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}