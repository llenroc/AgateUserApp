namespace Triplezerooo.XMVVM
{
    public interface IValidator<T>
    {
        string[] IsValid(T value);
    }
}
