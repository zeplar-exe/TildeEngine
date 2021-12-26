namespace TildeEngine.Graphics.Color;

public partial struct ColorArgb
{
    public int Alpha { get; set; }
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }
    
    public ColorArgb(int alpha, int r, int g, int b)
    {
        Alpha = alpha;
        R = r;
        G = g;
        B = b;
    }

    public ColorRgb ToRgb(ColorRgb backgroundColor)
    {
        return new ColorRgb(
            (1 - Alpha) * backgroundColor.R + Alpha * R,
            (1 - Alpha) * backgroundColor.G + Alpha * G,
            (1 - Alpha) * backgroundColor.B + Alpha * B);
    } // Courtesy of https://stackoverflow.com/a/2049362/16324801

    public override string ToString()
    {
        return $"{Alpha}, {R}, {G}, {B}";
    }
}