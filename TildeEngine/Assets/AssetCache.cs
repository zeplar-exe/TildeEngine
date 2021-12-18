using System.Collections.Concurrent;
using System.Text;

namespace TildeEngine.Assets;

public class AssetCache
{
    private string AssetPath { get; set; }
    private ConcurrentDictionary<string, RawAsset> raws = new();

    public AssetCache(string assetPath)
    {
        AssetPath = assetPath;
    }

    public void UpdateAssetPath(string path) => AssetPath = path;

    public void LoadAsset(string relativePath)
    {
        var filePath = Path.Join(AssetPath, relativePath);
        
        if (!File.Exists(filePath))
            return;

        var raw = new RawAsset(Encoding.UTF8, File.ReadAllBytes(filePath));

        raws.AddOrUpdate(Guid.NewGuid().ToString().ToUpper(), s => raw, (_, _) => raw);
    }

    public void UnloadAsset(Guid guid)
    {
        raws.TryRemove(guid.ToString(), out _);
    }
    
    public TAsset? FetchAsset<TAsset>(Guid guid, Func<RawAsset, TAsset> creator) where TAsset : GameAsset
    {
        return raws.TryGetValue(guid.ToString(), out var raw) ? creator.Invoke(raw) : null;
    }
}