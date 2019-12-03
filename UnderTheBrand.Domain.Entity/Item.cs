namespace UnderTheBrand.Domain.Entity
{
    public class Item : Base.Entity
    {
        public Item() { }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}