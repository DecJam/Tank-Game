<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Game
    {

        #region "Variables"
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

		protected Level root;
        #endregion

        #region "Constuctor"

        // Default constructor to create object
        public Game()
        {
        }

        #endregion

        #region "Run and update functions"

        // Initialises the level and a stopwatch 
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }
			root = new Level();
		}

        // Calls when game shutsdown
		public void Shutdown()
        {
        }

        // Is called to update, updates deltatime.
        public void Update()
        {
            // Calculates deltatime
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;

            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }

            //  Adds a frame and calls all the levels updates
            frames++;	
			root.Update(deltaTime);
			root.UpdateTransforms();
		}

        // Draws the background and its objects
        public void Draw()
        {
            // Clears background, draws fps counter and draws the level with its obects
            BeginDrawing();
            ClearBackground(RLColor.WHITE);
            DrawText(fps.ToString(), 10, 10, 14, RLColor.RED);
            root.Draw();
            EndDrawing();
        }
    }
    #endregion
}
=======
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Game
    {

        #region "Variables"
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

		protected Level root;
        #endregion

        #region "Constuctor"

        // Default constructor to create object
        public Game()
        {
        }

        #endregion

        #region "Run and update functions"

        // Initialises the level and a stopwatch 
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }
			root = new Level();
		}

        // Calls when game shutsdown
		public void Shutdown()
        {
        }

        // Is called to update, updates deltatime.
        public void Update()
        {
            // Calculates deltatime
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;

            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }

            //  Adds a frame and calls all the levels updates
            frames++;	
			root.Update(deltaTime);
			root.UpdateTransforms();
		}

        // Draws the background and its objects
        public void Draw()
        {
            // Clears background, draws fps counter and draws the level with its obects
            BeginDrawing();
            ClearBackground(RLColor.WHITE);
            DrawText(fps.ToString(), 10, 10, 14, RLColor.RED);
            root.Draw();
            EndDrawing();
        }
    }
    #endregion
}
>>>>>>> Stashed changes
