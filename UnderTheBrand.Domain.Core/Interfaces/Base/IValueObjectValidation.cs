namespace UnderTheBrand.Domain.Core.Interfaces.Base
{
    public interface IValueObjectValidation<in T>
    {
        bool IsValid(T value);
    }
}
