using TildeEngine.Graphics.Color;

namespace TildeEngine.Images;

public partial class ImageIntermediate
{
    public ColorArgb[] ColorMap;

    public ImageIntermediate(ColorArgb[] colorMap)
    {
        ColorMap = colorMap;
    }
}