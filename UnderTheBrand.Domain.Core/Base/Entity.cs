using PommaLabs.Thrower;

namespace UnderTheBrand.Domain.Core.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class Entity 
    {
        protected Entity() { }

        protected Entity(string id)
        {
            Raise.ArgumentNullException.IfIsNull(id, nameof(id));
            Id = id;
        }

        /// <summary>
        /// Индификатор
        /// </summary>
        public string Id { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(other.Id))
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id).GetHashCode();
        }
    }
}