using System.Text;

namespace TildeEngine.Assets;

public class RawAsset
{
    public Encoding Encoding { get; }
    public byte[] Bytes { get; }
    
    public RawAsset(Encoding encoding, byte[] bytes)
    {
        Encoding = encoding;
        Bytes = bytes;
    }

    public override string ToString()
    {
        return Encoding.GetString(Bytes);
    }
}