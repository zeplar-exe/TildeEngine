using System.Text;

namespace TildeEngine.Assets;

public class TextAsset : GameAsset
{
    private string RawText { get; }
    
    public TextAsset(RawAsset asset) : base(asset)
    {
        RawText = asset.ToString();
    }
    
    public override RawAsset Deserialize(Encoding encoding)
    {
        return new RawAsset(encoding, encoding.GetBytes(RawText));
    }

    public override string ToString()
    {
        return RawText;
    }
}