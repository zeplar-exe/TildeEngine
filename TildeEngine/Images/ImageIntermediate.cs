using System.Drawing;

namespace TildeEngine.Images;

public partial class ImageIntermediate
{
    public Color[] ColorMap;

    public ImageIntermediate(Color[] colorMap)
    {
        ColorMap = colorMap;
    }
}