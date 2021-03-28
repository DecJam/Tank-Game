using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Bullet : GameObject
    {
        protected Matrix3 m_BulletPos;
       
        public Bullet() : base("../Images/Ring.Png", "Bullet")
        {
        }

        public override void Update(float delta)
        {
          
            Vector2 direction = new Vector2();

            direction.x += 0;
            direction.y -= 1;

            Translate(direction, delta);
            base.Update(delta);
        }

        public override void OnCollision()
        {
        }
       
	}
}
