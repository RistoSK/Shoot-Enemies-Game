
public interface IPoolable
{
    IObjectPool poolableObject { get; set; }

    void PrepareToUse();
    void ReturnToPool();
}
