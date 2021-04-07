<<<<<<< Updated upstream
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
	class Obstacle : GameObject
	{
		#region "Variables"
		// Variables purely for obstacle
		private Vector2 m_MinPos;
		private Vector2 m_MaxPos;
		private Vector2 m_Pos;
		private Vector2 m_AimDirection;
		#endregion

		#region "Constructor"
		// Loaded constructor
		public Obstacle(Turret turret) : base("../Images/ObstacleIntact.png", "Obstacle")
		{
			// Setting the minimum and maximum positions for a position
			m_MinPos.x = 0;
			m_MinPos.y = 0;
			m_MaxPos.x = 640;
			m_MaxPos.y = 480;

			// gets a random x,y position within the previously states min and max variables
			m_Pos = GetRandomPos(m_MinPos, m_MaxPos);

			// sets its position
			m_LocalTransform.m7 = m_Pos.x;
			m_LocalTransform.m8 = m_Pos.y;
		}
		#endregion

		#region "Update functions"
		// updates Obsticle
		public override void Update(float delta)
		{
			// Only updates if obstacle is alive
			if (GetAlive() == true)
			{
				Translate(m_AimDirection, delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			// Calls the base update 
			base.Update(delta);
		}
        #endregion
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
	class Obstacle : GameObject
	{
		#region "Variables"
		// Variables purely for obstacle
		private Vector2 m_MinPos;
		private Vector2 m_MaxPos;
		private Vector2 m_Pos;
		private Vector2 m_AimDirection;
		#endregion

		#region "Constructor"
		// Loaded constructor
		public Obstacle(Turret turret) : base("../Images/ObstacleIntact.png", "Obstacle")
		{
			// Setting the minimum and maximum positions for a position
			m_MinPos.x = 0;
			m_MinPos.y = 0;
			m_MaxPos.x = 640;
			m_MaxPos.y = 480;

			// gets a random x,y position within the previously states min and max variables
			m_Pos = GetRandomPos(m_MinPos, m_MaxPos);

			// sets its position
			m_LocalTransform.m7 = m_Pos.x;
			m_LocalTransform.m8 = m_Pos.y;
		}
		#endregion

		#region "Update functions"
		// updates Obsticle
		public override void Update(float delta)
		{
			// Only updates if obstacle is alive
			if (GetAlive() == true)
			{
				Translate(m_AimDirection, delta);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			// Calls the base update 
			base.Update(delta);
		}
        #endregion
    }
}
>>>>>>> Stashed changes
