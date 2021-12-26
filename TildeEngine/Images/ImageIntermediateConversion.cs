using TildeEngine.Graphics.Color;

namespace TildeEngine.Images;

public partial class ImageIntermediate
{
    public byte[] ToPng()
    {
        throw new NotImplementedException();
    }

    public byte[] ToJpg()
    {
        throw new NotImplementedException();
    }

    public byte[] ToBmp()
    {
        throw new NotImplementedException();
    }

    public static ImageIntermediate FromPng(byte[] bytes)
    {
        using var reader = new BinaryReader(new MemoryStream(bytes));

        var magic = reader.ReadBytes(8);

        if (!magic.SequenceEqual(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 }))
            return new ImageIntermediate(Array.Empty<ColorArgb>()); // TODO: Red question mark upon invalid files
        
        var chunks = new List<byte[]>();

        while (reader.BaseStream.Position != reader.BaseStream.Length)
        {
            var length = reader.ReadInt32();
            var type = reader.ReadInt32();
            var chunk = reader.ReadBytes(length);
            var redundancyCheck = reader.ReadInt32();
            
            chunks.Add(chunk);
        } // http://www.libpng.org/pub/png/spec/1.2/PNG-Structure.html
        
        // Something something

        throw new NotImplementedException();
    }

    public static ImageIntermediate FromJpg()
    {
        throw new NotImplementedException();
    }

    public static ImageIntermediate FromBmp()
    {
        throw new NotImplementedException();
    }
}