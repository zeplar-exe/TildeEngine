using System.Collections.Concurrent;
using System.Text;

namespace TildeEngine.Assets;

public class AssetCache
{
    private string AssetPath { get; }
    private ConcurrentDictionary<string, RawAsset> raws = new();

    public void LoadAsset(string relativePath)
    {
        var filePath = Path.Join(AssetPath, relativePath);
        
        if (!File.Exists(filePath))
            return;

        var raw = new RawAsset(Encoding.UTF8, File.ReadAllBytes(filePath));

        raws.AddOrUpdate(Guid.NewGuid().ToString().ToUpper(), s => raw, (_, _) => raw);
    }

    public TAsset? FetchAsset<TAsset>(string path, Func<RawAsset, TAsset> creator) where TAsset : GameAsset
    {
        var rawAssetPath = Path.Join(AssetPath, path);

        if (!File.Exists(rawAssetPath))
            return null;

        var raw = new RawAsset(Encoding.UTF8, File.ReadAllBytes(rawAssetPath));

        return creator.Invoke(raw);
    }
}