namespace TildeEngine.Graphics;

public interface IDrawableContainer<TDrawable> : IEnumerable<TDrawable> where TDrawable : IDrawable
{
    public IEnumerable<TDrawable> Drawables { get; }
}