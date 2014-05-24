using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    enum UpgradeType
    {
        AddCannon,
        IncreaseDamage,
        DecreaseCooldown,
        AddDrone,
        Heal,
    }

    class Player : Entity
    {
        private static Texture texture = new Texture("Content/InGame/player.png");

        Vec2f mouseTarget;

        List<Vec2f> weaponsPosition;

        float weaponRotation = 0;
        List<Entity> toSpawnEnemies;
        private Vec2f acceleration;
        private Lifebar lifebar;

        int points;
        int upgradeCosts;

        const float cannonBaseDamage = 1;
        const float cannonBaseCoolDown = 1000;
        List<Weapon> weapons = new List<Weapon>();

        public Player(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name)
            : base(position, rotation, hp, float.PositiveInfinity, radius, velocity, team, name, new Sprite(texture))
        {
            const uint DEFAULT_WEAPON_NUMBER = 3;
            for (int i = 0; i < DEFAULT_WEAPON_NUMBER; ++i)
            {
                weapons.Add(new Cannon(position, 0, 10, cannonBaseCoolDown, cannonBaseDamage));
            }
            foreach (Weapon w in weapons)
            {
                w.loadContent();
            }
            acceleration = new Vec2f(0, 0);
        }
        public override void loadContent()
        {
            sprite.Origin = new Vec2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);

            mouseTarget = new Vec2f(0, 0);

            lifebar = new Lifebar(this);
        }
        public override void update(GameTime gameTime)
        {
            rotation += (0.025f) * (float)gameTime.ElapsedTime.TotalSeconds * 360.0f;
            weaponRotation += (0.05f) * (float)gameTime.ElapsedTime.TotalSeconds * 360.0f;

            toSpawnEnemies = new List<Entity>();


            foreach (Weapon weapon in weapons)
            {
                weapon.update(gameTime);

            }

            Vec2f movement = new Vec2f();

            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.D))
                movement.X++;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.A))
                movement.X--;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.W))
                movement.Y--;
            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.S))
                movement.Y++;

            acceleration = acceleration * 0.6f + movement;
            velocity = acceleration * 1 + velocity * 0.95f;

            position += 4 * velocity * (float)gameTime.ElapsedTime.TotalSeconds;//100 * movement * (float)gameTime.ElapsedTime.TotalSeconds + 1/2* acceleration * (float)gameTime.ElapsedTime.TotalSeconds * (float)gameTime.ElapsedTime.TotalSeconds;

            if (Game.mouseInput.leftPressed())
            {
                mouseTarget = Game.mouseInput.getMousePos();
                fireWeapon(true);

            }
            else if (Game.mouseInput.rightPressed())
            {
                mouseTarget = Game.mouseInput.getMousePos();
                fireWeapon(false);

            }
            lifebar.update(gameTime);
        }

        private void fireWeapon(bool left)
        {

            foreach (Weapon weapon in weapons)
            {
                Entity entity = weapon.fire(mouseTarget, null,left,position,weapon);

                if (entity != null)
                    toSpawnEnemies.Add(entity);

            }

        }

        public List<Entity> spawnNewEnemy()
        {
            return toSpawnEnemies;

        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            //sprite.Rotation = rotation;
            sprite.Position = position;
            sprite.Rotation = rotation;
            renderWindow.Draw(sprite);

            //set weapon Positionsd
            const uint weaponRadiusOffset = 15;
            weaponsPosition = getWeaponPosition(weapons.Count, radius + weaponRadiusOffset, Position, -weaponRotation);
            for (int weaponID = 0; weaponID < weapons.Count; weaponID++)
            {
                weapons.ElementAt(weaponID).Sprite.Rotation = weaponRotation - ((float)weaponID / weapons.Count * 360.0f);
                weapons.ElementAt(weaponID).Position = weaponsPosition.ElementAt(weaponID);
                weapons.ElementAt(weaponID).draw(gameTime, renderWindow);
            }

            lifebar.draw(gameTime, renderWindow);
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

        public void addLetter(String s)
        {
            char letter = s[0];
            points += letter - 'A';
            Console.WriteLine(points);
        }

        public bool upgrade(UpgradeType upgradeType, List<Entity> entityList)
        {
            if (points < upgradeCosts)
            {
                return false;
            }
            else
            {
                points -= upgradeCosts;
                upgradeCosts = (int)(upgradeCosts * 1.8f);
                switch (upgradeType)
                {
                    case UpgradeType.AddCannon:
                        Weapon newWeapon = new Cannon(position, 0, 10, cannonBaseCoolDown, cannonBaseDamage);
                        newWeapon.loadContent();
                        weapons.Add(newWeapon);
                        break;
                    case UpgradeType.IncreaseDamage:
                        foreach (Weapon w in weapons)
                        {
                            w.ProjectileDamageFactor *= 1.5f;
                        }
                        break;
                    case UpgradeType.DecreaseCooldown:
                        foreach (Weapon w in weapons)
                        {
                            w.CoolDownFactor *= 0.8f;
                        }
                        break;
                    case UpgradeType.AddDrone:
                        Entity newDrone = new Drone(new Vec2f(0, 0), 0, 10, new Vec2f(0, 0), this);
                        newDrone.loadContent();
                        entityList.Add(newDrone);
                        break;
                    case UpgradeType.Heal:
                        Hp = 100;
                        break;
                    default:
                        break;
                }

                return true;

            }
        }
    }
}
