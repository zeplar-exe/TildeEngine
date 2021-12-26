namespace TildeEngine.Graphics;

public struct ColorHsv
{
    private double b_hue;
    public double Hue
    {
        get => b_hue;
        set => b_hue = Math.Clamp(value, 0, 1);
    }

    private double b_saturation;
    public double Saturation
    {
        get => b_hue;
        set => b_saturation = Math.Clamp(value, 0, 1);
    }

    private double b_value;
    public double Value
    {
        get => b_hue;
        set => b_value = Math.Clamp(value, 0, 1);
    }
    
    public ColorHsv(double hue, double saturation, double value)
    {
        b_hue = hue;
        b_saturation = saturation;
        b_value = value;
    }

    public ColorRgb ToRgb()
    {
        throw new NotImplementedException();
    } // Will try to adapt https://www.cs.rit.edu/~ncs/color/t_convert.html
}