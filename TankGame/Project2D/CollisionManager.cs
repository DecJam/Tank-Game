<<<<<<< HEAD
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
		private static List<GameObject> m_ObectList = new List<GameObject>();
		public static void AddObject (GameObject obj)
		{
			m_ObectList.Add(obj);
		}

		public static void RemoveObject(GameObject obj)
		{
			m_ObectList.Remove(obj);
		}

		//
		// Collision Checking
		//

		public static void CheckCollision()
		{
			int count1 = m_ObectList.Count;
			for (int x = 0; x < count1; x++)
			{
				GameObject obj1 = m_ObectList[x];

				int count = m_ObectList.Count;
				for (int i = 0; i < count; i++)
				{
					GameObject obj2 = m_ObectList[i];
					//dont have objects collide with themselfs
					if (obj1 == obj2)
					{
						continue;
					}

					//test collision
					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					if (obj1Max.x > obj2Min.x &&
						obj1Max.y > obj2Min.y &&
						obj2Max.x > obj1Min.x &&
						obj2Max.y > obj1Min.y)
					{
						obj1.OnCollision(obj2);
					}
				}
			}
		}
	}
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	static class CollisionManager
	{
		private static List<GameObject> m_ObectList = new List<GameObject>();
		public static void AddObject (GameObject obj)
		{
			m_ObectList.Add(obj);
		}

		//
		// Collision Checking
		//

		public static void CheckCollision()
		{
			foreach(GameObject obj1 in m_ObectList)
			{
				foreach(GameObject obj2 in m_ObectList)
				{
					//dont have objects collide with themselfs
					if (obj1 == obj2)
					{
						continue;
					}
					//test collision
				}
			}
		}
	}
}
>>>>>>> main
