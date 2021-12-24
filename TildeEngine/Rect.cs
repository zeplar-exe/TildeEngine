namespace TildeEngine;

public readonly struct Rect
{
    public Vector2 BottomLeft { get; }
    public Vector2 Size { get; }

    public Vector2 BottomRight => BottomLeft + new Vector2(Size.X, 0);
    public Vector2 TopLeft => BottomLeft + new Vector2(0, Size.Y);
    public Vector2 TopRight => BottomLeft + Size;

    public Rect(Vector2 bottomLeft, Vector2 size)
    {
        BottomLeft = bottomLeft;
        Size = size;
    }
}