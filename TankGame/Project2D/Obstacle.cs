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
	class Obstacle : GameObject
	{
	
		public Obstacle(Turret turret) : base("../Images/Frodo.jpg", "Obstacle")
		{
			
			m_LocalTransform.m7 = 300;
			m_LocalTransform.m8 = 100;

			
		}

		public override void Update(float delta)
		{
			if (GetAlive() == true)
			{
				Vector2 direction;
				direction.x = 0;
				direction.y = 0;

				Translate(direction, delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			base.Update(delta);
		}

	}
}
