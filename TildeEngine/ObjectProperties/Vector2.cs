using SFML.System;

namespace TildeEngine.ObjectProperties;

public struct Vector2 : IEquatable<Vector2>
{
    public float X { get; set; }
    public float Y { get; set; }

    public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
    
    public Vector2 Distance(Vector2 other)
    {
        var relative = RelativeTo(other);

        return new Vector2(Math.Abs(relative.X), Math.Abs(relative.Y));
    }

    public Vector2 RelativeTo(Vector2 other)
    {
        return new Vector2(other.X - X, other.Y - Y);
    }

    public bool Equals(Vector2 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Vector2 left, Vector2 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2 left, Vector2 right)
    {
        return !left.Equals(right);
    }

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X + right.X, left.Y + right.Y);
    }
    
    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X - right.X, left.Y - right.Y);
    }
    
    public static Vector2 operator *(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X * right.X, left.Y * right.Y);
    }
    
    public static Vector2 operator /(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X / right.X, left.Y / right.Y);
    }
    
    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}