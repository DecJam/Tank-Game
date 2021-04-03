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
        #region "Variables"
        public Turret m_Turret = null;
        #endregion

        #region "Constructor"
        public Tank() : base("../Images/Tank.png", "Tank")
		{
			// Sets tanks spawn position and spawns turret
			m_LocalTransform.m7 = 300;
			m_LocalTransform.m8 = 300;
			m_Turret = new Turret();
			m_Turret.SetParent(this);
		}
        #endregion

        #region "Update function"
        // Tanks update function
        public override void Update(float delta)
		{
			// Checks if tank is alive
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

				// Moveand rotates the tank
				Translate(direction, delta, false);
				Rotate(rotation * rSpeed * delta, false);

				// updates collision box and checks collision
				UpdateMinMax();
			}
			// updates its base
			base.Update(delta);
		}

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
		#endregion
	}
}

	

