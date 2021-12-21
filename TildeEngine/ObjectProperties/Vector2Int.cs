namespace TildeEngine.ObjectProperties;

public struct Vector2Int : IEquatable<Vector2Int>
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    
    public Vector2Int(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector2Int Distance(Vector2Int other)
    {
        var relative = RelativeTo(other);

        return new Vector2Int(Math.Abs(relative.X), Math.Abs(relative.Y));
    }

    public Vector2Int RelativeTo(Vector2Int other)
    {
        return new Vector2Int(other.X - X, other.Y - Y);
    }

    public bool Equals(Vector2Int other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2Int other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Vector2Int left, Vector2Int right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2Int left, Vector2Int right)
    {
        return !left.Equals(right);
    }

    public static Vector2Int operator +(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(left.X + right.X, left.Y + right.Y);
    }
    
    public static Vector2Int operator -(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(left.X - right.X, left.Y - right.Y);
    }
    
    public static Vector2Int operator *(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(left.X * right.X, left.Y * right.Y);
    }
    
    public static Vector2Int operator /(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(left.X / right.X, left.Y / right.Y);
    }
    
    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}