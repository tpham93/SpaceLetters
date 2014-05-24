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
        private float hp;
        protected float radius;
        protected Vec2f velocity;
        private Team team;
        protected String name;
        protected Sprite sprite;
        protected bool toDelete;
        private float damage;

        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public float Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public bool ToDelete
        {
            get { return toDelete || hp<=0; }
        }
        public Vec2f Position
        {
            get { return position; }
        }
        public Team Team
        {
            get { return team; }
        }

        public Entity(Vec2f position, float rotation, float hp, float damage, float radius, Vec2f velocity, Team team, String name, Sprite sprite)
        {
            this.position = position;
            this.rotation = rotation;
            this.hp = hp;
            this.damage = damage;
            this.radius = radius;
            this.velocity = velocity;
            this.team = team;
            this.name = name;
            this.sprite = sprite;

            toDelete = false;

            initialize();
            
        }

        public abstract EntityType getEntityType();
        public abstract void initialize();

        public abstract void loadContent();
        public abstract void update(GameTime gameTime);
        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);
        public virtual void onDeath()
        {

        }

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
