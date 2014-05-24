﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;


namespace SpaceLetters
{
    class World
    {
        List<Entity> entities = new List<Entity>();
        List<PSpawner> particleSpawner;

        private Random rand;
        private Player player;
        private Spawner spawner;

        private float spawnTimeSmaragd;
        private float runSpawnTimeSmaragd;

        Sprite backgroundSprite;

        Sprite[] upgradeButtons;
        Sprite buttonBar;


        private static Music sound = new Music("Content/Sounds/exp.wav");

        public bool playerDead
        {
            get { return player.ToDelete; }
        }

        public World()
        {

            rand = new Random();
            particleSpawner = new List<PSpawner>();
            spawnTimeSmaragd = 3000;
            sound.Loop = false;
            sound.Volume = 15f;
        }

        public void loadContent()
        {
            upgradeButtons = new Sprite[5];
            upgradeButtons[0] = new Sprite(new Texture("Content/InGame/Buttons/cannon.png"));
            upgradeButtons[1] = new Sprite(new Texture("Content/InGame/Buttons/atk.png"));
            upgradeButtons[2] = new Sprite(new Texture("Content/InGame/Buttons/cooldown.png"));
            upgradeButtons[3] = new Sprite(new Texture("Content/InGame/Buttons/health.png"));
            upgradeButtons[4] = new Sprite(new Texture("Content/InGame/Buttons/drone.png"));
            buttonBar = new Sprite(new Texture("Content/InGame/Buttons/buttonBar.png"));
            buttonBar.Position = new Vec2f(0.0f, Game.WINDOWSIZE.Y - buttonBar.Texture.Size.Y);
            float buttonSize = upgradeButtons[0].Texture.Size.X;
            Vec2f buttonOffset = new Vec2f(10, -17);
            for (int i = 0; i < 5; ++i)
            {
                upgradeButtons[i].Position = new Vec2f(i * buttonSize, Game.WINDOWSIZE.Y - buttonSize) + buttonOffset;
            }

            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            Texture playerTexture = new Texture("Content/InGame/player.png");
            player = new Player(new Vec2f(Game.WINDOWSIZE.X / 2, Game.WINDOWSIZE.Y / 2), 0, 100, Math.Max(playerTexture.Size.X, playerTexture.Size.X) / 2, new Vec2f(0, 0), Team.Good, "Player - Horst");
            spawner = new Spawner(0.01f, player);
            entities.Add(player);
            entities.Add(new Drone(player.Position, 0, 10, new Vec2f(0, 0), player));
            entities.Add(new Drone(player.Position, 0, 10, new Vec2f(0, 0), player));


            foreach (Entity ent in entities)
                ent.loadContent();

        }

        public void update(GameTime gameTime)
        {
            List<Entity> tmp = new List<Entity>();
            for (int i = entities.Count - 1; i >= 0; --i)
            {
                entities.ElementAt(i).update(gameTime);
                Projectiles p = entities[i].shoot();
                if (p != null)
                {
                    tmp.Add(p);
                }
                for (int j = i + 1; j < entities.Count; ++j)
                {
                    Team teamI = entities[i].Team;
                    Team teamJ = entities[j].Team;

                    if (teamI == Team.Neutral || teamI != teamJ)
                    {
                        bool collides = entities[i].collide(entities[j]);
                        if (collides)
                        {
                            entities[i].Hp -= entities[j].Damage;
                            entities[j].Hp -= entities[i].Damage;
                        }
                    }
                }
                // Spezialbehandlung für einige klassen
                EntityType type = entities.ElementAt(i).getEntityType();
                switch (type)
                {
                    case EntityType.EnemyBreeder:
                        Breeder bre = (Breeder)entities.ElementAt(i);
                        if (bre.ReadyToSpawn)
                        {
                            float alpha = (float)rand.NextDouble() * 360;
                            Breeder bre2 = new Breeder(bre.Position + (new Vec2f((float)(20 * Math.Cos(alpha)), (float)(20 * Math.Sin(alpha)))), 0, new Vec2f(0, 0), "Breeder", player);
                            tmp.Add(bre2);
                            bre.ReadyToSpawn = false;
                        }

                        break;
                    case EntityType.Drone:
                        Drone drone = (Drone)entities.ElementAt(i);
                        if (drone.noTarget)
                        {
                            Smaragd smaragd = null;
                            foreach (Entity ent in entities)
                            {
                                if (ent.getEntityType() == EntityType.Letter)
                                {
                                    Smaragd sam = (Smaragd)ent;
                                    if ((smaragd == null) || (sam.Drone == null && (player.Position - sam.Position).length() < (player.Position - smaragd.Position).length()))
                                    {
                                        smaragd = sam;
                                        ent.canExplode = false;
                                    }
                                }
                            }
                            drone.setTarget(smaragd);


                        }

                        break;

                    default:
                        break;
                }

                if (entities.ElementAt(i).ToDelete)
                {
                    if (entities[i].canExplode)
                    {
                        particleSpawner.Add(new PSpawner(entities[i].Position, 500));
                        sound.Play();
                    }
                    entities[i].onDeath();
                    entities.RemoveAt(i);
                }
            }
            entities.AddRange(tmp);

            entities.AddRange(player.spawnNewEnemy());

            runSpawnTimeSmaragd += (float)gameTime.ElapsedTime.TotalMilliseconds;

            if (runSpawnTimeSmaragd > spawnTimeSmaragd)
            {
                runSpawnTimeSmaragd = 0;
                spawnSmaragd();

            }

            Entity spawnedEntity = spawner.spawn();
            if (spawnedEntity != null)
            {
                entities.Add(spawnedEntity);
            }

            for (int i = particleSpawner.Count - 1; i > 0; --i)
            {
                particleSpawner.ElementAt(i).update(gameTime);
                if (particleSpawner.ElementAt(i).isSpawnerFinish())
                    particleSpawner.RemoveAt(i);
            }

            Keyboard.Key[] upgradeKeys = { Keyboard.Key.Num1, Keyboard.Key.Num2, Keyboard.Key.Num3, Keyboard.Key.Num4, Keyboard.Key.Num5 };
            UpgradeType[] upgradeTypes = { UpgradeType.AddCannon, UpgradeType.IncreaseDamage, UpgradeType.DecreaseCooldown, UpgradeType.AddDrone, UpgradeType.Heal };

            for (int i = 0; i < upgradeKeys.Length; ++i)
            {
                if (Game.keyboardInput.isClicked(upgradeKeys[i]))
                {
                    player.upgrade(upgradeTypes[i], entities);
                }
            }
        }

        private void spawnSmaragd()
        {
            String name = ((char)('A' + rand.Next(26))).ToString();
            Vec2f velocity;
            switch (rand.Next(4))
            {
                case 0:
                    velocity = new Vec2f((float)rand.Next((int)30, 255), (float)rand.Next((int)Game.WINDOWSIZE.Y));
                    velocity.normalize();
                    velocity *= 60;
                    entities.Add(new Smaragd(new Vec2f(-30, (float)rand.NextDouble() * Game.WINDOWSIZE.Y), 0, 2, 20, velocity, Team.Neutral, name));
                    break;
                case 1:
                    velocity = new Vec2f((float)rand.Next((int)-255, -30), (float)rand.Next((int)Game.WINDOWSIZE.Y));
                    velocity.normalize();
                    velocity *= 60;
                    entities.Add(new Smaragd(new Vec2f(Game.WINDOWSIZE.X + 30, (float)rand.NextDouble() * Game.WINDOWSIZE.Y), 0, 2, 20, velocity, Team.Neutral, name));
                    break;
                case 2:
                    velocity = new Vec2f((float)(float)rand.Next((int)Game.WINDOWSIZE.Y), (float)rand.Next((int)30, 255));
                    velocity.normalize();
                    velocity *= 60;
                    entities.Add(new Smaragd(new Vec2f((float)rand.NextDouble() * Game.WINDOWSIZE.X, -30), 0, 2, 20, velocity, Team.Neutral, name));
                    break;
                case 3:
                    velocity = new Vec2f((float)(float)rand.Next((int)Game.WINDOWSIZE.Y), (float)rand.Next((int)-255, -30));
                    velocity.normalize();
                    velocity *= 60;
                    entities.Add(new Smaragd(new Vec2f((float)rand.NextDouble() * Game.WINDOWSIZE.X, Game.WINDOWSIZE.Y + 30), 0, 2, 20, velocity, Team.Neutral, name));
                    break;


            }

        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Draw(backgroundSprite);

            foreach (Entity ent in entities)
                ent.draw(gameTime, window);
            foreach (PSpawner spawner in particleSpawner)
                spawner.draw(gameTime, window);
            window.Draw(buttonBar);
            for(int i = 0; i<upgradeButtons.Length;++i)
            {
                window.Draw(upgradeButtons[i]);
                Text t = new Text(""+i,Game.smaraFont);
                t.Color = Color.White;
                t.Position = new Vec2f(upgradeButtons[i].Position) + new Vec2f(21.0f, 45.0f);
                t.Scale = new Vec2f(0.5f, 0.5f);
                window.Draw(t);
            }
        }



    }
}
