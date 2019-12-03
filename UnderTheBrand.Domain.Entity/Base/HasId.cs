using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Entity.Base
{
    public class HasId : HasIdBase<string>
    {
        //TODO: попробовать вынести в базовый класс
        public override bool Equals(object obj)
        {
            var other = obj as HasId;
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(other.Id))
                return false;

            return Id == other.Id;
        }

        //TODO: попробовать вынести в базовый класс
        public static bool operator ==(HasId a, HasId b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        //TODO: попробовать вынести в базовый класс
        public static bool operator !=(HasId a, HasId b)
        {
            return !(a == b);
        }

        //TODO: попробовать вынести в базовый класс
        public override int GetHashCode()
        {
            return (GetType() + Id).GetHashCode();
        }
    }
}
