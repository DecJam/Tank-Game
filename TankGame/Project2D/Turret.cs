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
	class Turret : GameObject
	{
		#region "Variables"

		public Bullet m_Bullet;
		public Obstacle m_Obstacle;
        #endregion

        #region "Constructor"
		// Turrets default constructor holding its file link and name
        public Turret() : base("../Images/Turret.png", "Turret")
		{}
        #endregion

        #region "Getter and setters"
		// Returns the global transform for the turret
        public Matrix3 GetTranform()
		{
			return m_GlobalTransform;
		}

		// Returns the texture size for the turret
		public Vector2 GetTextureSize()
        {
			Vector2 size;
			size.x = this.m_Texture.width;
			size.y = this.m_Texture.height;
			return size;
        }
        #endregion

        #region "Update Functions"
        // The update function for the turret
        public override void Update(float delta)
		{
			// Only updates if turret is alive
			if (GetAlive() == true)
			{
				float rSpeed = 150;
				float rotation = 0;

				// Checks for button imputs 
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
					// only spawns newbullet if there is less than 10 in the game
					if (BulletCount.GetBulletCount() < 10)
					{ 
						// spawns new bullet and sets its parent
						BulletCount.AddBullet();
						m_Bullet = new Bullet(this);
						m_Bullet.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Bullet);
					}
					// if thereis 10 or more bullets it does nothing
					else 
					{
					}
				}

				// Spawns new Obstacle (Test)
				if (IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
				{			
						m_Obstacle = new Obstacle(this);
						m_Obstacle.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Obstacle);				
				}

				// Sets the rotation and hitbox of the turret
				Rotate(rotation * rSpeed * delta, false);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			// Updates its base
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
	class Turret : GameObject
	{
		#region "Variables"

		public Bullet m_Bullet;
		public Obstacle m_Obstacle;
        #endregion

        #region "Constructor"
		// Turrets default constructor holding its file link and name
        public Turret() : base("../Images/Turret.png", "Turret")
		{}
        #endregion

        #region "Getter and setters"
		// Returns the global transform for the turret
        public Matrix3 GetTranform()
		{
			return m_GlobalTransform;
		}

		// Returns the texture size for the turret
		public Vector2 GetTextureSize()
        {
			Vector2 size;
			size.x = this.m_Texture.width;
			size.y = this.m_Texture.height;
			return size;
        }
        #endregion

        #region "Update Functions"
        // The update function for the turret
        public override void Update(float delta)
		{
			// Only updates if turret is alive
			if (GetAlive() == true)
			{
				float rSpeed = 150;
				float rotation = 0;

				// Checks for button imputs 
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
					// only spawns newbullet if there is less than 10 in the game
					if (BulletCount.GetBulletCount() < 10)
					{ 
						// spawns new bullet and sets its parent
						BulletCount.AddBullet();
						m_Bullet = new Bullet(this);
						m_Bullet.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Bullet);
					}
					// if thereis 10 or more bullets it does nothing
					else 
					{
					}
				}

				// Spawns new Obstacle (Test)
				if (IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT))
				{			
						m_Obstacle = new Obstacle(this);
						m_Obstacle.SetParent(GetParent().GetParent());
						CollisionManager.AddObject(m_Obstacle);				
				}

				// Sets the rotation and hitbox of the turret
				Rotate(rotation * rSpeed * delta, false);
				UpdateMinMax();
				CollisionManager.CheckCollision();
			}
			// Updates its base
			base.Update(delta);
		}
        #endregion
    }
}
>>>>>>> Stashed changes
