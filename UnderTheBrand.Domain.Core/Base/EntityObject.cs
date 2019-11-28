namespace UnderTheBrand.Domain.Core.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class EntityObject 
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        public string Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as EntityObject;
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(other.Id))
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(EntityObject a, EntityObject b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityObject a, EntityObject b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id).GetHashCode();
        }
    }
}