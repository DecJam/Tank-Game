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
		Vector2 m_MinPos;
		Vector2 m_MaxPos;
		Vector2 m_Pos;
		Vector2 m_AimDirection;
		public Obstacle(Turret turret) : base("../Images/Frodo.jpg", "Obstacle")
		{
			m_MinPos.x = 0;
			m_MinPos.y = 0;
			m_MaxPos.x = 640;
			m_MaxPos.y = 480;

			m_Pos = GetRandomPos(m_MinPos, m_MaxPos);

			m_LocalTransform.m7 = m_Pos.x;
			m_LocalTransform.m8 = m_Pos.y;

			//	m_AimDirection.x = m_LocalTransform.m4;
			//	m_AimDirection.y = m_LocalTransform.m5;
			//	m_AimDirection.Normalize();
			//	m_LocalTransform = m_LocalTransform * GetRandomRotation();
	
		}

		public override void Update(float delta)
		{
			if (GetAlive() == true)
			{
				Translate(m_AimDirection, delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
				base.Update(delta);
		}

		public override void OnCollision(GameObject obj2)
		{
		
		}

	}
}
