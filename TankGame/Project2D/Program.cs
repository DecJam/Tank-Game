using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Program
    {
        #region "Initialises"
        // runs as aplication opens
        static void Main(string[] args)
        {
            Game game = new Game();

            InitWindow(640, 480, "Tank Game");
            
            game.Init();

            // Call the first Update functions to loop whilst the window is open
            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            CloseWindow();
        }
        #endregion
    }
}
