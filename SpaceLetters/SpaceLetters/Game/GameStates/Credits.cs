using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SFML.Graphics;

namespace SpaceLetters
{
    class Credits : AGameState
    {

        private Text text;
        private Text tuan;
        private Text gerd;
        private Text yorick;
        private Texture logo;
        private Sprite logoSprite;
        private Sprite logo2Name;
        private Sprite backgroundSprite;
        private Texture logoGame = new Texture("Content/gameTitle.png");
        private Sprite gameSprite;

        public override void initialize()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            
            text = new Text(" ", Game.smaraFont);
            text.Position = new Vec2f(200, 60);

            tuan = new Text("tuan pham minh", Game.smaraFont);
            gerd = new Text("gerd schmidt", Game.smaraFont);
            yorick = new Text("yorick netzer", Game.smaraFont);

            logo = new Texture("Content/logo.png");
            logoSprite = new Sprite(logo);
            logo2Name = new Sprite(new Texture("Content/logName.png"));
            logo2Name.Scale = new Vec2f(0.15f,0.15f);

            gerd.Position = new Vec2f(60, 125);
            tuan.Position = new Vec2f(60, 185);
            yorick.Position = new Vec2f(60, 245);
            logo2Name.Position = new Vec2f(60, 350);
            logoSprite.Position = new Vec2f(137, 90);


            gameSprite = new Sprite(logoGame);
            gameSprite.Position = new Vec2f(47, 0);
            gameSprite.Scale = new Vec2f(0.7f, 0.7f);

           
        }

        public override void loadContent()
        {
            
        }

        public override EGameStates update(GameTime gameTime)
        {



            if (Game.keyboardInput.isClicked(SFML.Window.Keyboard.Key.Escape) || Game.joystickInput.isClicked(JoystickButton.Select))
                return EGameStates.MainMenu;

            return EGameStates.Credits;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            renderWindow.Draw(backgroundSprite);

            renderWindow.Draw(gerd);
            renderWindow.Draw(tuan);
            renderWindow.Draw(yorick);
            renderWindow.Draw(logoSprite);
            renderWindow.Draw(logo2Name);
            renderWindow.Draw(gameSprite);

        }
    }
}
