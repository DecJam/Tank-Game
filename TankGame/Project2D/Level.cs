<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Level : GameObject
	{
        #region "Variables"
        private Tank m_Tank = null;
        #endregion

        #region "Constructor"
        
        // Loaded constructor for level
        public Level() : base("../Images/BackGround.png", "Level")
		{
            //Initalizes a new tank and sets its parent
			m_Tank = new Tank();		
			m_Tank.SetParent(this);
			CollisionManager.AddObject(m_Tank);
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

namespace Project2D
{
	class Level : GameObject
	{
        #region "Variables"
        private Tank m_Tank = null;
        #endregion

        #region "Constructor"
        
        // Loaded constructor for level
        public Level() : base("../Images/BackGround.png", "Level")
		{
            //Initalizes a new tank and sets its parent
			m_Tank = new Tank();		
			m_Tank.SetParent(this);
			CollisionManager.AddObject(m_Tank);
		}
        #endregion
    }
}
>>>>>>> Stashed changes
