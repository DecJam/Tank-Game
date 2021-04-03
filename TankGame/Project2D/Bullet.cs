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
        #region "Variables"
        // Individual bullet variables
        protected Vector2 m_AimDirection;
		protected float m_TimeRemaining = 10;
		protected Matrix3 m_offset;
		#endregion

		#region "Constructor"
		// Constructor for newely created bullet
		public Bullet(Turret turret) : base("../Images/Bullet.png", "Bullet")
		{
			// Makes the bullets local transform the turrets transform then finds and normalises the forward direction
			m_LocalTransform = turret.GetTranform();
			
			m_AimDirection.x = m_LocalTransform.m4 * -1;
			m_AimDirection.y = m_LocalTransform.m5 * -1;
			m_AimDirection.Normalize();
			m_offset.Identity();
			m_offset.m7 = 50;
			m_offset.m8 = 50;
			m_LocalTransform = m_LocalTransform * m_offset;
	
		}
        #endregion

        #region "Update functions"
        // Functions to timeout and delete the bullet
        public void BulletTimeout(float delta)
		{
			// If the timer is more than 0 it will reduce the time by delta time 
			if (m_TimeRemaining > 0)
			{
				m_TimeRemaining -= delta;
			}

			// If timer is 0 it will 'timeout' / remove the bullet
			else
			{
				BulletCount.RemoveBullet();
				SetAlive(false);
				CollisionManager.RemoveObject(this);
			}
			
		}
		
		// Update function for the bullet
        public override void Update(float delta)
        {
			// If the bullet is alive it calls all its updates
			if (GetAlive() == true)
			{
				Translate(m_AimDirection, delta);
				BulletTimeout(delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}

			// Cycles back to the base to update all its functions
			BulletCount.BulletCounter();
			base.Update(delta);
        }

		// When colided with an object calls this function
        public override void OnCollision(GameObject obj2)
        {
			// Checks the name of the object it collides with and acts differently for each
			if (obj2.GetName() == "Tank")
			{ }
			else if (obj2.GetName() == "Turret")
			{ }
			else if (obj2.GetName() == "Obstacle")
			{
				BulletCount.RemoveBullet();
				SetAlive(false);
				obj2.SetAlive(false);
				CollisionManager.RemoveObject(obj2);
			}

			// If the object doesnt have a name it defaults to destroying it
			else 
			{
				BulletCount.RemoveBullet();
				SetAlive(false);
				obj2.SetAlive(false);
				CollisionManager.RemoveObject(obj2);
			}
		
        }
		#endregion	
	}
}
