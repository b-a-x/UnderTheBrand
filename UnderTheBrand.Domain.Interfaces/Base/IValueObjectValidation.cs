namespace UnderTheBrand.Domain.Interfaces.Base
{
    public interface IValueObjectValidation<in T>
    {
        bool IsValid(T value);
    }
}
