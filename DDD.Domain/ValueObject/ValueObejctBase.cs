namespace DDD.Domain.ValueObject
{
    public abstract class ValueObejctBase
    {

        protected abstract bool EqualsCore(T other);
    }
}