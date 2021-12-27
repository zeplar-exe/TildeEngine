namespace TildeEngine.EntityManagement;

public class EntityPool<TEntity> where TEntity : class
{
    public List<TEntity?> Alive { get; private set; }
    public List<TEntity?> Dead { get; private set; }

    public EntityPool(int initialCapacity = 1000)
    {
        Alive = new List<TEntity?>(initialCapacity);
        Dead = new List<TEntity?>(initialCapacity);
    }

    public void RunUpdate(Func<TEntity?, Task> updater, EntityUpdateType type)
    {
        if (type is EntityUpdateType.Alive or EntityUpdateType.AliveAndDead)
        {
            foreach (var entity in Alive)
            {
                updater.Invoke(entity);
            }
        }
        
        if (type is EntityUpdateType.Dead or EntityUpdateType.AliveAndDead)
        {
            foreach (var entity in Dead)
            {
                updater.Invoke(entity);
            }
        }
    }

    public async Task RunAsynchronousUpdate(Func<TEntity?, Task> updater, EntityUpdateType type)
    {
        await Task.Run(async delegate
        {
            if (type is EntityUpdateType.Alive or EntityUpdateType.AliveAndDead)
            {
                foreach (var entity in Alive)
                {
                    await updater.Invoke(entity);
                }
            }
        });

        await Task.Run(async delegate
        {
            if (type is EntityUpdateType.Dead or EntityUpdateType.AliveAndDead)
            {
                foreach (var entity in Dead)
                {
                    await updater.Invoke(entity);
                }
            }
        });
    }

    public void Revive(TEntity entity)
    {
        var index = Dead.IndexOf(entity);

        if (index == -1)
            throw new InvalidOperationException("The given entity is not dead.");
        
        Dead.Add(entity);
        Alive[index] = null;
    }

    public void Kill(TEntity entity)
    {
        var index = Alive.IndexOf(entity);
        
        if (index == -1)
            throw new InvalidOperationException("The given entity is not alive.");
        
        Alive.Add(entity);
        Dead[index] = null;
    }

    public void Clean()
    {
        Alive = Alive.Where(a => a != null).ToList();
        Dead = Dead.Where(d => d != null).ToList();
    }
}

public enum EntityUpdateType
{
    None,
    Alive,
    Dead,
    AliveAndDead
}