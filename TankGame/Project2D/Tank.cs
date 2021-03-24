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
			m_Turret = new Turret("../Images/Sting.jpg", "Turret");
			m_Turret.SetParent(this);
		}

	

		public override void Update(float delta)
		{
			Vector2 direction = new Vector2();
			float rotation;


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

			// Slide left
			if (IsKeyDown(KeyboardKey.KEY_A))
			{
				direction.x -= 1;
			}

			// Slide right
			if (IsKeyDown(KeyboardKey.KEY_D))
			{
				direction.x += 1;
			}

			

			// Rotate left
			if (IsKeyDown(KeyboardKey.KEY_Q))
			{

			}

			// Rotate right
			if (IsKeyDown(KeyboardKey.KEY_E))
			{

			}


			Translate(direction * 200 * delta, false);
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
	}

	
}
