using System.Text;

namespace TildeEngine.Assets;

public abstract class GameAsset
{
    protected GameAsset(RawAsset asset)
    {
        
    }

    public abstract RawAsset Deserialize(Encoding encoding);
}