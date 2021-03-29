<<<<<<< HEAD
﻿using System;
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
		int m_BulletCount = 0;
		int m_MaxBulletCount = 10;
		Vector2 m_AimDirection;

		public Bullet(Turret turret) : base("../Images/Ring.png", "Bullet")
		{
			m_BulletCount++;
			m_LocalTransform = turret.GetTranform();
			
			m_AimDirection.x = m_LocalTransform.m4;
			m_AimDirection.y = m_LocalTransform.m5;
			m_AimDirection.Normalize();
		}

		public void BulletCheck()
		{
			if (m_BulletCount > m_MaxBulletCount)
			{
				m_Children[6].SetAlive(false);
			}
		}
	
        public override void Update(float delta)
        {         
     
            Translate(m_AimDirection, delta);
			BulletCheck();
			UpdateMinMax();
			CollisionManager.CheckCollision();
			base.Update(delta);
        }

        public override void OnCollision(GameObject obj2)
        {
			this.SetAlive(false);
			obj2.SetAlive(false);
        }
       
	}
}
=======
﻿using System;
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
>>>>>>> main
