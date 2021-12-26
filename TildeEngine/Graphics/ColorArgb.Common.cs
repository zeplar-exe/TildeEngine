namespace TildeEngine.Graphics;

public partial struct ColorArgb
{
    public static ColorArgb Red => new(0, 255, 0, 0);
    public static ColorArgb Green => new(0, 0, 255, 0);
    public static ColorArgb Blue => new(0, 0, 0, 255);
    public static ColorArgb White => new(0, 255, 255, 255);
    public static ColorArgb Black => new(0, 0, 0, 0);
}