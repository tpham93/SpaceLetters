using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceLetters
{
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
        protected float radius;
        protected float velocity;
        protected Team team;
        protected String name;
        protected Sprite sprite;

        public Entity (Vec2f position, float rot, float radius, float velocity, Team team, String name, Sprite sprite)
        {
            this.position = position;
            this.rotation = rot;
            this.radius = radius;
            this.velocity = velocity;
            this.team = team;
            this.name = name;
            this.sprite = sprite;

        }

        public abstract void loadContent();

        public abstract void update();

        public abstract void draw();



    }
}
