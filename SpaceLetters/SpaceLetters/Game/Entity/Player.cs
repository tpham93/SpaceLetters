using SFML.Graphics;
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

        float weaponRotation = 0;
        List<Entity> toSpawnEnemies;

        float animatedCanonsPos = 0;

        

        List<Weapon> weapons = new List<Weapon>();

        public Player(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation, hp, radius, velocity, team, name,sprite)
        {
            const uint DEFAULT_WEAPON_NÙMBER = 3;
            Texture cannonTexture = new Texture("Content/InGame/cannon.png");
            for (int i = 0; i < DEFAULT_WEAPON_NÙMBER; ++i)
            {
                weapons.Add(new Cannon(new Vec2f(position.X, position.Y), 0, 10, new Sprite(cannonTexture)));
            }

            foreach(Weapon w in weapons)
            {
                w.loadContent();
            }
        }
        public override void loadContent()
        {
            sprite.Origin = new Vec2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y/2);
         
            mouseTarget = new Vec2f(0, 0);
        }
            


        public override void update(GameTime gameTime)
        {
            weaponRotation += (0.05f)*(float)gameTime.ElapsedTime.TotalSeconds * 360.0f;

            toSpawnEnemies = new List<Entity>();
            fireWeapon();

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
        }

        private void fireWeapon()
        {

            foreach (Weapon weapon in weapons)
                toSpawnEnemies.Add(weapon.fire(Position, mouseTarget,null));

        }

        public List<Entity> spawnNewEnemy()
        {
            return toSpawnEnemies;

        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            //sprite.Rotation = rotation;
            sprite.Position = Position;
            renderWindow.Draw(sprite);

            //set weapon Positionsd
            const uint weaponRadiusOffset = 30;
            weaponsPosition = getWeaponPosition(weapons.Count, radius + weaponRadiusOffset, Position, -weaponRotation);
            for (int weaponID = 0; weaponID < weapons.Count; weaponID++)
            {
                weapons.ElementAt(weaponID).Sprite.Rotation = weaponRotation -((float)weaponID / weapons.Count * 360.0f);
                weapons.ElementAt(weaponID).Position = weaponsPosition.ElementAt(weaponID);
                weapons.ElementAt(weaponID).draw(gameTime, renderWindow);
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

        private List<Vec2f> getWeaponPosition(int numWeapons, float radius, Vec2f pos, float rotation)
        {

            float place = (float)(2 * Math.PI / numWeapons);
            rotation = (float)(2 * Math.PI * rotation) / 360.0f;

            List<Vec2f> result = new List<Vec2f>();
            for (int i = 0; i < numWeapons; i++)
            {
                result.Add(pos - new Vec2f((float)(radius * Math.Sin(i * place + rotation)), (float)(radius * Math.Cos(i * place + rotation))));
            }

            return result;
        }
    }
}
