using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Tank Battle");

            Actor root = new Actor();
            game.Root = root;

            Player1 player1 = new Player1(400, 400);

            Player2 player2 = new Player2(700, 700);
            

            root.AddChild(player1);
            root.AddChild(player2);
            //root.AddChild(wallgenerator);
            //## Set up game here ##//

            game.Run();
        }
    }
}
