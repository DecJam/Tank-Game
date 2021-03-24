using System;
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
