using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    public abstract class HasIdBase : IHasId<string>
    {
        public string Id { get; set; }
        object IHasId.Id => Id;

        public override bool Equals(object obj)
        {
            var other = obj as HasIdBase;
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(other.Id))
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(HasIdBase a, HasIdBase b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(HasIdBase a, HasIdBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id).GetHashCode();
        }
    }
}