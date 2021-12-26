namespace TildeEngine.Graphics.Color;

public partial struct ColorRgb
{
    public static ColorRgb Red => new(255, 0, 0);
    public static ColorRgb Green => new(0, 255, 0);
    public static ColorRgb Blue => new(0, 0, 255);
    public static ColorRgb White => new(255, 255, 255);
    public static ColorRgb Black => new(0, 0, 0);
}