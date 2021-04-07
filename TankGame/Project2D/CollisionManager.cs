<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Project2D
{
	static class CollisionManager
	{
		#region "Variables"
		private static List<GameObject> m_ObectList = new List<GameObject>();
		#endregion

		#region "Functions"
		// Adds a gameobject to the object list
		public static void AddObject (GameObject obj)
		{
			m_ObectList.Add(obj);
		}

		// Removes a gameobject from the object list
		public static void RemoveObject(GameObject obj)
		{
			m_ObectList.Remove(obj);
		}
        #endregion

        #region "Update functions"
		// Checks the collison for the object
        public static void CheckCollision()
		{			   
			// Cylcles through all the objects and makes it obj1
			for (int x = 0; x < m_ObectList.Count; x++)
			{
				GameObject obj1 = m_ObectList[x];		
				
				// Cycles through the objects and makes it obj2
				for (int i = 0; i < m_ObectList.Count; i++)
				{
					GameObject obj2 = m_ObectList[i];

					// Ignores if the objects are colliding with itself
					if (obj1 == obj2)
					{
						continue;
					}

					// Sets the minimum and maximum values for a AABB (Axis aligned bounding box)
					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					// Checks if the min and max values for each objects AABB
					if (obj1Max.x > obj2Min.x &&
						obj1Max.y > obj2Min.y &&
						obj2Max.x > obj1Min.x &&
						obj2Max.y > obj1Min.y)
						// Calls the collision funtion for the objects that collide
					{
						obj1.OnCollision(obj2);
					}
				}
			}
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

namespace Project2D
{
	static class CollisionManager
	{
		#region "Variables"
		private static List<GameObject> m_ObectList = new List<GameObject>();
		#endregion

		#region "Functions"
		// Adds a gameobject to the object list
		public static void AddObject (GameObject obj)
		{
			m_ObectList.Add(obj);
		}

		// Removes a gameobject from the object list
		public static void RemoveObject(GameObject obj)
		{
			m_ObectList.Remove(obj);
		}
        #endregion

        #region "Update functions"
		// Checks the collison for the object
        public static void CheckCollision()
		{			   
			// Cylcles through all the objects and makes it obj1
			for (int x = 0; x < m_ObectList.Count; x++)
			{
				GameObject obj1 = m_ObectList[x];		
				
				// Cycles through the objects and makes it obj2
				for (int i = 0; i < m_ObectList.Count; i++)
				{
					GameObject obj2 = m_ObectList[i];

					// Ignores if the objects are colliding with itself
					if (obj1 == obj2)
					{
						continue;
					}

					// Sets the minimum and maximum values for a AABB (Axis aligned bounding box)
					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					// Checks if the min and max values for each objects AABB
					if (obj1Max.x > obj2Min.x &&
						obj1Max.y > obj2Min.y &&
						obj2Max.x > obj1Min.x &&
						obj2Max.y > obj1Min.y)
						// Calls the collision funtion for the objects that collide
					{
						obj1.OnCollision(obj2);
					}
				}
			}
		}
        #endregion
    }
}
>>>>>>> Stashed changes
