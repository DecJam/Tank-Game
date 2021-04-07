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
	// Class created purely to store/hold and use bullet information can be used across classes
   static class BulletCount
    {
        #region "Variables"
        // Individual variable
        private static int m_BulletCount;
		private static int m_AmmoCount;
        #endregion

        #region "Getters and Setters"

		// Adds a bullet to the total count
        public static void AddBullet()
		{
			m_BulletCount += 1;
		}
		
		// Removes a bullet from the total count
		public static void RemoveBullet()
		{
			m_BulletCount -= 1;
		}

		// returns the total bullet count
		public static int GetBulletCount()
		{
			return m_BulletCount;
		}
        #endregion

        #region "Update functions"

		// A constantly updating counter for bullets
        public static void BulletCounter()
        {
			// Creates it countdown when a shot is taken
			m_AmmoCount = 10 - m_BulletCount;
			DrawText("Ammo = " + m_AmmoCount.ToString(), 10, 25, 14, RLColor.RED);
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
	// Class created purely to store/hold and use bullet information can be used across classes
   static class BulletCount
    {
        #region "Variables"
        // Individual variable
        private static int m_BulletCount;
		private static int m_AmmoCount;
        #endregion

        #region "Getters and Setters"

		// Adds a bullet to the total count
        public static void AddBullet()
		{
			m_BulletCount += 1;
		}
		
		// Removes a bullet from the total count
		public static void RemoveBullet()
		{
			m_BulletCount -= 1;
		}

		// returns the total bullet count
		public static int GetBulletCount()
		{
			return m_BulletCount;
		}
        #endregion

        #region "Update functions"

		// A constantly updating counter for bullets
        public static void BulletCounter()
        {
			// Creates it countdown when a shot is taken
			m_AmmoCount = 10 - m_BulletCount;
			DrawText("Ammo = " + m_AmmoCount.ToString(), 10, 25, 14, RLColor.RED);
		}
        #endregion

    }
}
>>>>>>> Stashed changes
