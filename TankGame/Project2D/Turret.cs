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
	class Turret : GameObject
	{
		public Bullet m_Bullet;
		public Turret() : base("../Images/Sting.jpg", "Turret")
		{

		}
		public override void Update(float delta)
		{
			float rSpeed = 80;
			float rotation = 0;

			// Rotate left
			if (IsKeyDown(KeyboardKey.KEY_Z))
			{
				rotation -= 0.005f;
			}

            // Rotate right
            if (IsKeyDown(KeyboardKey.KEY_X))
            {
                rotation += 0.005f;
            }

			if (IsKeyPressed(KeyboardKey.KEY_SPACE))
			{
				m_Bullet = new Bullet();
				m_Bullet.SetParent(this);
			} 

			Rotate(rotation * rSpeed * delta, false);
			base.Update(delta);
		}
	}
}
