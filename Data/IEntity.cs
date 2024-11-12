namespace Sol.Data;

public interface IEntity<out TKey>
{
    public TKey Id { get; }
}