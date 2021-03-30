using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathLibrary;

namespace Project2D
{
	class Tank : GameObject
	{
		public Turret m_Turret = null;
		public Tank() : base("../Images/Smeagol.jpg", "Tank")
		{
			m_LocalTransform.m7 = 300;
			m_LocalTransform.m8 = 300;
			m_Turret = new Turret();
			m_Turret.SetParent(this);
		
		}
	
		public override void Update(float delta)
		{
			if (GetAlive() == true)
			{
				Vector2 direction = new Vector2();
				float rotation = 0;
				float rSpeed = 60;

				// Drive forward 
				if (IsKeyDown(KeyboardKey.KEY_W))
				{
					direction.y -= 1;
				}

				// Drive backward
				if (IsKeyDown(KeyboardKey.KEY_S))
				{
					direction.y += 1;
				}

				//// Slide left
				//if (IsKeyDown(KeyboardKey.KEY_A))
				//{
				//	direction.x -= 1;
				//}

				//// Slide right
				//if (IsKeyDown(KeyboardKey.KEY_D))
				//{
				//	direction.x += 1;
				//}


				// Rotate left
				if (IsKeyDown(KeyboardKey.KEY_A))
				{
					rotation -= 0.005f;
				}

				// Rotate right
				if (IsKeyDown(KeyboardKey.KEY_D))
				{
					rotation += 0.005f;
				}

				Translate(direction, delta, false);
				Rotate(rotation * rSpeed * delta, false);


				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			base.Update(delta);
		}
		//public override void OnCollision(GameObject otherObj)
		//{
		//	// Circle collision - Calculate normal
		//	Vector2 v2Normal = otherObj.GetPosition() - GetPosition();

		//	// calculate reflection
		//	Vector2 reflection = -2.0f * m_v2Velocity.Dot(v2Normal) * v2Normal + m_Velocity;

		//	// Change diretion
		//	m_velocity
		//}
		public override void OnCollision(GameObject obj2)
		{
			if (obj2.GetName() == "Turret")
			{ }
			else if (obj2.GetName() == "Bullet")
			{ }
			else if (obj2.GetName() == "Obstacle")
			{
				obj2.SetAlive(false);
				CollisionManager.RemoveObject(obj2);
			}
			else
			{
				
				
				
			}

		}
	}
}

	

