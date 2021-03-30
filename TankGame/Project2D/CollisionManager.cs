using System;
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
			for (int x = 0; x < m_ObectList.Count; x++)
			{
				GameObject obj1 = m_ObectList[x];				
				for (int i = 0; i < m_ObectList.Count; i++)
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
