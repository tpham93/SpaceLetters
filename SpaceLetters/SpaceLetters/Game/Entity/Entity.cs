using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceLetters
{
    public enum EntityType
    {
        Player,
        Enemy,
        Weapon,
        Drone,
        Letter,
        Projectile,
        EnemyBreeder,

        Num
    }

    public enum Team
    {
        Good,
        Evil,
        Neutral,

        Num

    }

    abstract class Entity
    {
        protected Vec2f position;
        protected float rotation;
        protected float hp;
        protected float radius;
        protected Vec2f velocity;
        protected Team team;
        protected String name;
        protected Sprite sprite;

        public Vec2f Position
        {
            get { return position; }
        }

        public Entity(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, Sprite sprite)
        {
            this.position = position;
            this.rotation = rotation;
            this.hp = hp;
            this.radius = radius;
            this.velocity = velocity;
            this.team = team;
            this.name = name;
            this.sprite = sprite;

            initialize();
            
        }

        public abstract EntityType getEntityType();
        public abstract void initialize();

        public abstract void loadContent();
        public abstract void update(GameTime gameTime);
        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);


        public bool collide(Entity other)
        {
            if(Math.Pow(other.position.X - position.X,2) + Math.Pow(other.position.Y -position.Y,2) < Math.Pow(radius+ other.radius,2))
            {
                return true;
            }
            return false;
        }

    }
}
