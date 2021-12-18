using System.Collections.Concurrent;
using System.Text;

namespace TildeEngine.Assets;

public class AssetCache
{
    private string AssetPath { get; }
    private ConcurrentDictionary<string, GameAsset> assets = new();

    public void LoadAsset(string path, AssetType type)
    {
        
    }

    public RawAsset? FetchAsset(string path)
    {
        var rawAssetPath = Path.Join(AssetPath, path);

        if (!File.Exists(rawAssetPath))
            return null;

        return new RawAsset(Encoding.UTF8, File.ReadAllBytes(rawAssetPath));
    }
}