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
		public Obstacle m_Obstacle;
		
		public Turret() : base("../Images/Sting.jpg", "Turret")
		{
		}
		public Matrix3 GetTranform()
		{
			return m_GlobalTransform;
		}
		public override void Update(float delta)
		{

			if (GetAlive() == true)
			{
				float rSpeed = 150;
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

				// Fires bullet
				if (IsKeyPressed(KeyboardKey.KEY_SPACE))
				{
					if (GetBulletCount() < 10)
					{
						AddBullet();
						m_Bullet = new Bullet(this);
						m_Bullet.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Bullet);
					}
					else 
					{

					}
				}

				if (IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
				{			
						m_Obstacle = new Obstacle(this);
						m_Obstacle.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Obstacle);				
				}

				Rotate(rotation * rSpeed * delta, false);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			base.Update(delta);
		}
	}
}
