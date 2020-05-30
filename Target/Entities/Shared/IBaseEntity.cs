namespace LaDanse.Target.Entities.Shared
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}