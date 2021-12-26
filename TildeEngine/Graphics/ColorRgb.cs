namespace TildeEngine.Graphics;

public partial struct ColorRgb
{
    public ColorRgb(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public ColorHsv ToHsv()
    {
        var hsv = new ColorHsv();

        float min = Math.Min(R, Math.Min(G, B));
        var max = Math.Max(R, Math.Max(G, B));
        
        hsv.Value = max;		
        
        var delta = max - min;

        if (max != 0)
        {
            hsv.Saturation = delta / max;
        }
        else
        {
            hsv.Saturation = 0;
            hsv.Hue = -1;
            
            return hsv;
        }
        
        if(R == max)
            hsv.Hue = (G - B) / delta;		// between yellow & magenta
        else if( G == max )
            hsv.Hue = 2 + (B - R) / delta;	// between cyan & yellow
        else
            hsv.Hue = 4 + (R - G) / delta;	// between magenta & cyan
        
        hsv.Hue *= 60;				// degrees
        
        if(hsv.Hue < 0)
            hsv.Hue += 360;

        return hsv;
    } // Adapted from https://www.cs.rit.edu/~ncs/color/t_convert.html

    public ColorArgb ToArgb(int alpha)
    {
        return new ColorArgb(alpha, R, G, B);
    }
}