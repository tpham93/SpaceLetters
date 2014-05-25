using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SFML.Graphics;

namespace SpaceLetters
{
    class ScoreGameState : AGameState
    {
        private RectangleShape r_quit_bg;
        private FloatRect r_quit,mouse;
        private Text text;
        private Sprite backgroundSprite;
        private List<String> scores, players;
        private List<Entry> entries;
        public override void initialize()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            
            text = new Text(" ", Game.smaraFont);
            text.Position = new Vec2f(200, 60);
        }

        public override void loadContent()
        {

            StreamReader streamReader = new StreamReader("Content/Data.txt");
            String tmp = streamReader.ReadToEnd();
            streamReader.Close();
            entries = new List<Entry>();

            string[] separator = { "\r\n", "\n" };
            String[] s = tmp.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Length; i++)
            {
                entries.Add(new Entry(s[i]));
            }
        }

        public override EGameStates update(GameTime gameTime)
        {



            if (Game.keyboardInput.isClicked(SFML.Window.Keyboard.Key.Escape) || Game.joystickInput.isClicked(JoystickButton.Select))
                return EGameStates.MainMenu;

            return EGameStates.Score;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            renderWindow.Draw(backgroundSprite);
            
            
            for (int i = 0; i < entries.Count; i++)
            {
                text.Position = new Vec2f(text.Position.X, text.Position.Y + 30);
                text.DisplayedString = entries.ElementAt(i).Name;
                renderWindow.Draw(text);
            }
            text.Position = new Vec2f(600, 60);
            for (int i = 0; i < entries.Count; i++)
            {
                text.Position = new Vec2f(text.Position.X, text.Position.Y + 30);
                text.DisplayedString = ""+entries.ElementAt(i).Score;
                renderWindow.Draw(text);
            }
            text.Position = new Vec2f(200, 60);
        }
    }
}
