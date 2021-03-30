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
		protected Vector2 m_AimDirection;
		protected float m_TimeRemaining = 10;
		protected int m_BulletCount = 0;

		public Bullet(Turret turret) : base("../Images/Ring.png", "Bullet")
		{
			m_LocalTransform = turret.GetTranform();
			
			m_AimDirection.x = m_LocalTransform.m4;
			m_AimDirection.y = m_LocalTransform.m5;
			m_AimDirection.Normalize();
		}


		public void AddBullet()
		{
			m_BulletCount++;
		}
		public void RemoveBullet()
		{
			m_BulletCount--;
		}
		public void BulletTimeout(float delta)
		{
			if (m_TimeRemaining > 0)
			{
				m_TimeRemaining -= delta;
			}

			else
			{
				SetAlive(false);
				CollisionManager.RemoveObject(this);
			}
			
		}
		
	
        public override void Update(float delta)
        {
			if (GetAlive() == true)
			{
				Translate(m_AimDirection, delta);
				BulletTimeout(delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			base.Update(delta);
        }

        public override void OnCollision(GameObject obj2)
        {
			if (obj2.GetName() == "Tank")
			{ }
			else if (obj2.GetName() == "Turret")
			{ }
			else if (obj2.GetName() == "Bullet")
			{ }
			else 
			{
				RemoveBullet();
				SetAlive(false);
				obj2.SetAlive(false);
				CollisionManager.RemoveObject(obj2);
			}
		
        }
       
	}
}
