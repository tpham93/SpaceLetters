﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Player : Entity
    {
        Vec2f mouseTarget;

        List<Vec2f> weaponsPosition;

        float animatedCanonsPos = 0;

        public Vec2f Position
        {
            get { return position; }
        }

        List<Weapon> weapons = new List<Weapon>();

        public Player(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation, hp, radius, velocity, team, name,sprite)
        {
            weapons.Add(new Cannon(new Vec2f(position.X , position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));
            weapons.Add(new Cannon(new Vec2f(position.X , position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));
            weapons.Add(new Cannon(new Vec2f(position.X, position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));
            weapons.Add(new Cannon(new Vec2f(position.X, position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));
            weapons.Add(new Cannon(new Vec2f(position.X, position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));
            weapons.Add(new Cannon(new Vec2f(position.X, position.Y), 0, 10, new Sprite(new Texture("Content/InGame/cannon.png"))));

        
        }
        public override void loadContent()
        {

            sprite.Origin = new Vec2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y/2);
         
            mouseTarget = new Vec2f(0, 0);
        }
            


        public override void update(GameTime gameTime)
        {
            rotation = (float) gameTime.ElapsedTime.TotalMilliseconds/10;

            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.D))
                position.X++;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.A))
                position.X--;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.W))
                position.Y--;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.S))
                position.Y++;

            if(Game.mouseInput.leftClicked())
            {
                mouseTarget = Game.mouseInput.getMousePos();

            }

            Console.WriteLine(mouseTarget);
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {

            sprite.Rotation = rotation;
            sprite.Position = position;
            renderWindow.Draw(sprite);

            Console.WriteLine(radius);


            //set weapon Position
            weaponsPosition = getWeaponPosition(weapons.Count, radius*6, position);
            for (int weaponID = 0; weaponID < weapons.Count; weaponID++)
            {
                weapons.ElementAt(weaponID).position = /*rollWeapon*/( weaponsPosition.ElementAt(weaponID)-(weapons.ElementAt(weaponID).TextureSize/2)/*,3*/);
                weapons.ElementAt(weaponID).draw(gameTime, renderWindow);


            }


        }

        public override void initialize()
        {
           // throw new NotImplementedException();
        }

        public override EntityType getEntityType()
        {
            return EntityType.Player;
        }

        private Vec2f rollWeapon(Vec2f oldpos, float a)
        {
            Vec2f ans = oldpos - position;

            float a0 = (float) Math.Acos(ans.X /(Math.Sqrt(Math.Pow(ans.X,2)+Math.Pow(ans.Y,2))));

            ans.X = (float)Math.Cos(a0 + a);
            ans.Y = (float)Math.Sin(a0 + a);
            Console.WriteLine(ans.X + "  " + ans.Y);
            ans = ((float)(Math.Sqrt(Math.Pow(ans.X, 2) + Math.Pow(ans.Y, 2)))) * ans;
            return ans + position;
        }

        private List<Vec2f> getWeaponPosition(int numWeapons, float radius, Vec2f pos)
        {

            float place = (float)(2 * Math.PI / numWeapons);

            List<Vec2f> result = new List<Vec2f>();
            for (int i = 0; i < numWeapons; i++)
            {
                result.Add(new Vec2f(pos.X-(float)(radius * Math.Sin( i * place ))+animatedCanonsPos, pos.Y -(float)(radius * Math.Cos( i * place))));
            }

            return result;
        }
    }
}
