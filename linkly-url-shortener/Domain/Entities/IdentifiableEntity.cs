namespace linkly_url_shortener.Domain.Entities;
public abstract class IdentifiableEntity<T>
{
    public T? Id { get; set; }
    public T? GetId() => Id;
}
