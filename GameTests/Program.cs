using TildeEngine;
using TildeEngine.Game;
using TildeEngine.Game.World.Common;
using TildeEngine.Graphics;
using TildeEngine.Graphics.Color;
using TildeEngine.Scenes;
using TildeEngine.UI;
using TildeEngine.UI.Common;

using var app = new GameApp();

app.Window.Scene = new Scene(new StaticCamera());
app.Window.Scene.AddDrawable(new ColoredTile(new Vector2(0, 0), ColorArgb.Blue));
app.Window.Scene.AddDrawable(new ColoredTile(new Vector2(50, 50), ColorArgb.Blue));
// app.Window.Scene.AddDrawable(new UIFrame(new Vector2(-100, -100))
// {
//     new Rectangle(new Vector2(-100, -100), new Vector2(50, 50))
// });

app.Start(CloseHandler.Kill);