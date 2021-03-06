﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace SpaceLetters
{
    class MainMenu : AGameState
    {
        private Vec2f toIngame, toCredits, toExit, toHighscore;
        private const int button_width = 200, button_height = 50;
        private int button_x, button_y_distance;
        private Sprite sprite_ingame, sprite_ingame_over, sprite_exit, sprite_exit_over, sprite_highscore, sprite_highscore_over, sprite_credits, sprite_credits_over, backgroundSprite, sprite_rocket;
        private bool inGameButton, creditsButton, exitButton, highscore;

        private Texture logoGame = new Texture("Content/gameTitle.png");
        private Sprite gameSprite;

        private List<Entity> entities = new List<Entity>();

        private Vec2f playerPos = new Vec2f((float)Game.WINDOWSIZE.X * 0.75f, (float)Game.WINDOWSIZE.Y / 2);

        private Player player;

        private Sprite nameBar;

        public override void initialize()
        {
            player = new Player(playerPos, 0, 100, 50, new Vec2f(0, 0), Team.Num, "PLayer");
            for (int i = 0; i < 5; i++)
                player.upgrade(UpgradeType.AddCannon, null);
        }

        public override void loadContent()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));

            gameSprite = new Sprite(logoGame);

            button_x = (int)((Game.WINDOWSIZE.X - button_width) / 2 - Game.WINDOWSIZE.X / 3);
            button_y_distance = (int)((Game.WINDOWSIZE.Y - 200) / 5);

            toIngame = new Vec2f(button_x, button_y_distance);
            toCredits = new Vec2f(button_x, button_height + 2 * button_y_distance);
            toHighscore = new Vec2f(button_x, 2 * button_height + 3 * button_y_distance);
            toExit = new Vec2f(button_x, 3 * button_height + 4 * button_y_distance);

            sprite_ingame = new Sprite(new Texture("Content/main_menu/main_menu_ingame.png"));
            sprite_ingame_over = new Sprite(new Texture("Content/main_menu/main_menu_ingame_over.png"));
            sprite_exit = new Sprite(new Texture("Content/main_menu/main_menu_exit.png"));
            sprite_exit_over = new Sprite(new Texture("Content/main_menu/main_menu_exit_over.png"));
            sprite_credits = new Sprite(new Texture("Content/main_menu/main_menu_credits.png"));
            sprite_credits_over = new Sprite(new Texture("Content/main_menu/main_menu_credits_over.png"));
            sprite_highscore = new Sprite(new Texture("Content/main_menu/main_menu_highscore.png"));
            sprite_highscore_over = new Sprite(new Texture("Content/main_menu/main_menu_highscore_over.png"));
            nameBar = new Sprite(new Texture("Content/main_menu/main_menu_name_bar.png"));
            sprite_ingame.Position = sprite_ingame_over.Position = toIngame;
            sprite_exit.Position = sprite_exit_over.Position = toExit;
            sprite_credits.Position = sprite_credits_over.Position = toCredits;
            sprite_highscore.Position = sprite_highscore_over.Position = toHighscore;

            player.loadContent();
        }

        public override EGameStates update(GameTime gameTime)
        {
            Vec2f mousepos = Game.mouseInput.getMousePos();

            inGameButton = false;
            creditsButton = false;
            exitButton = false;
            highscore = false;

            if (button_x <= mousepos.X && mousepos.X <= button_x + button_width)
            {
                if (button_y_distance <= mousepos.Y && mousepos.Y <= button_y_distance + button_height)
                {
                    inGameButton = true;
                    if (Game.mouseInput.leftClicked() || Game.joystickInput.isClicked(JoystickButton.A))
                    {
                        gameTime.Stop();
                        gameTime.Start();
                        return EGameStates.InGame;
                    }
                }
                else if (button_y_distance * 2 + button_height <= mousepos.Y && mousepos.Y <= button_y_distance * 2 + button_height * 2)
                {
                    creditsButton = true;
                    if (Game.mouseInput.leftClicked() || Game.joystickInput.isClicked(JoystickButton.A))
                        return EGameStates.Credits;
                }
                else if (button_y_distance * 3 + button_height * 2 <= mousepos.Y && mousepos.Y <= button_y_distance * 3 + button_height * 3)
                {
                    highscore = true;
                    if (Game.mouseInput.leftClicked() || Game.joystickInput.isClicked(JoystickButton.A))
                        return EGameStates.Score;
                }
                else if (button_y_distance * 4 + button_height * 3 <= mousepos.Y && mousepos.Y <= button_y_distance * 4 + button_height * 4)
                {
                    exitButton = true;
                    if (Game.mouseInput.leftClicked() || Game.joystickInput.isClicked(JoystickButton.A))
                        return EGameStates.Exit;
                }
            }

            player.update(gameTime);
            player.Position = playerPos;
            entities.AddRange(player.spawnNewEnemy());

            for (int i = entities.Count - 1; i >= 0; --i)
            {
                entities[i].update(gameTime);

                if (entities.ElementAt(i).ToDelete)
                {

                    entities[i].onDeath();
                    entities.RemoveAt(i);
                }
            }


            List<Keyboard.Key> pressedKeys = Game.keyboardInput.allClickedKeys();
            if (pressedKeys.Count != 0)
            {
                if (pressedKeys[0] != Keyboard.Key.Escape && pressedKeys[0] != Keyboard.Key.Back)
                    Game.playerName += keyToChar(pressedKeys[0], Game.keyboardInput.isPressed(Keyboard.Key.RShift) || Game.keyboardInput.isPressed(Keyboard.Key.LShift));
            }
            if (Game.keyboardInput.isClicked(Keyboard.Key.Back) && Game.playerName.Length > 0)
            {
                Game.playerName = Game.playerName.Substring(0, Game.playerName.Length - 1);
            }



            if (Game.keyboardInput.isClicked(Keyboard.Key.Escape))
                return EGameStates.Exit;

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {


            renderWindow.Draw(backgroundSprite);


            foreach (Entity entity in entities)
            {
                entity.draw(gameTime, renderWindow);

            }

            player.draw(gameTime, renderWindow);
            if (inGameButton)
                renderWindow.Draw(sprite_ingame_over);
            else
                renderWindow.Draw(sprite_ingame);
            if (creditsButton)
                renderWindow.Draw(sprite_credits_over);
            else
                renderWindow.Draw(sprite_credits);
            if (exitButton)
                renderWindow.Draw(sprite_exit_over);
            else
                renderWindow.Draw(sprite_exit);
            if (highscore)
                renderWindow.Draw(sprite_highscore);
            else
                renderWindow.Draw(sprite_highscore_over);

            nameBar.Position = new Vec2f(450, 3 * button_height + 4 * button_y_distance);
            renderWindow.Draw(nameBar);
            Text playerName = new Text("name: "+Game.playerName, Game.smaraFont);
            playerName.Scale = new Vector2f(0.5f, 0.5f);
            playerName.Position = new Vec2f(450+10, 3 * button_height + 4 * button_y_distance +15);

            gameSprite.Position = new Vector2f(300,  20);
            gameSprite.Scale = new Vec2f(0.7f, 0.7f);

            renderWindow.Draw(playerName);
            renderWindow.Draw(gameSprite);
        }

        char keyToChar(Keyboard.Key key, bool shift)
        {
            int keyCode = (int)key;
            if (keyCode <= (int)Keyboard.Key.Num9 && keyCode >= (int)Keyboard.Key.Num0)
            {
                return (char)('0' + (keyCode - (int)Keyboard.Key.Num0));
            }
            if (keyCode <= (int)Keyboard.Key.Numpad9 && keyCode >= (int)Keyboard.Key.Numpad0)
            {
                return (char)('0' + (keyCode - (int)Keyboard.Key.Numpad0));
            }
            if (keyCode <= (int)Keyboard.Key.Z && keyCode >= (int)Keyboard.Key.A)
            {
                char c = (char)('a' + (keyCode - (int)Keyboard.Key.A));
                if (shift)
                {
                    c = (char)(c + ('A' - 'a'));
                }
                return c;
            }

            return '\0';
        }
    }
}
