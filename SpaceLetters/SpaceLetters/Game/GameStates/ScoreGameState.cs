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
        public override void initialize()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            
            text = new Text(" ", Game.smaraFont);
            text.Position = new Vec2f(300, 100);
        }

        public override void loadContent()
        {

            StreamReader streamReader = new StreamReader("Content/Data.txt");
            string tmp = streamReader.ReadToEnd();
            streamReader.Close();
            players = new List<string>();
            scores = new List<string>();
            int start = 0;
            int end = 0;
            while(start < tmp.Length-1)
            {
                Console.WriteLine(start + ":" + end);
                end = tmp.IndexOf(",", start);
                players.Add(tmp.Substring(start, end-start));
                start = end+1;
                end = tmp.IndexOf("\r\n", start);
                Console.WriteLine(start + ":" + end);
                scores.Add(tmp.Substring(start, end-start ));
                start =end+2;

            }
        }

        public override EGameStates update(GameTime gameTime)
        {
            


            //if (Game.keyboardInput.isClicked(SFML.Window.Keyboard.Key.Escape))
              //  return EGameStates.MainMenu;

            return EGameStates.Score;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            renderWindow.Draw(backgroundSprite);
            
            
            for (int i = 0; i < players.Count; i++)
            {
                text.Position = new Vec2f(text.Position.X, text.Position.Y + 30);
                text.DisplayedString = players.ElementAt(i);
                renderWindow.Draw(text);
            }
            text.Position = new Vec2f(500, 100);
            for (int i = 0; i < scores.Count; i++)
            {
                text.Position = new Vec2f(text.Position.X, text.Position.Y + 30);
                text.DisplayedString = scores.ElementAt(i);
                renderWindow.Draw(text);
            }
            text.Position = new Vec2f(300, 100);
        }
    }
}
