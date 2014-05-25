using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceLetters
{
    class InGame : AGameState
    {
        World world;

        public override void loadContent()
        {
            world.loadContent();   
        }

        public override EGameStates update(GameTime gameTime)
        {
            world.update(gameTime);
            if (world.playerDead)
            {
                List<Entry> entries = new List<Entry>();
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
                streamReader.Close();
                entries.Add(new Entry(world.playerName, world.playerScore));
                entries.Sort();
                //entries.RemoveAt(entries.Count - 1);
                
                
                StreamWriter streamWriter = new StreamWriter("Content/Data.txt");
                for(int i=0;i<entries.Count && i<10;i++){
                    streamWriter.Write(entries.ElementAt(i));
                }
                streamWriter.Close();
                




                return EGameStates.Score;
            }

            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.Escape) || Game.joystickInput.isClicked(JoystickButton.Select))
                return EGameStates.MainMenu;

            return EGameStates.InGame;
            
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            world.draw(gameTime, renderWindow);
        }

        public override void initialize()
        {
            world = new World();
        }

    }
}
