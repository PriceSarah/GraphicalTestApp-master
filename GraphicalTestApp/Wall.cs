using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Wall : Actor
    {
        //public AABB Hitbox;

        //private Sprite _wallSprite = new Sprite("images/wall.jpg");

        ////public static Wall wall;

        //public static List<Wall> WallList = new List<Wall>();
        //public Wall(float x, float y)
        //{
        //    Hitbox = new AABB(_wallSprite.Height, _wallSprite.Width);

        //    AddChild(Hitbox);
        //    AddChild(_wallSprite);
        //    Hitbox.X = 0;
        //    Hitbox.Y = 0;
        //    OnUpdate += playerCollide;

        //    X = x;
        //    Y = y;

        //}
        
        ////checks if there is a collision with the player 
        //private void playerCollide(float deltatime)
        //{
        //    //check player collision
        //    if (Hitbox.DetectCollision(Player1.player1.hitbox))
        //    {
        //        Player1.player1.XVelocity = -Player1.player1.XVelocity;
        //        Player1.player1.YVelocity = -Player1.player1.YVelocity;
        //    }
        //    else if (Hitbox.DetectCollision(Player2.player2.hitbox))
        //    {
        //        Player2.player2.XVelocity = -Player2.player2.XVelocity;
        //        Player2.player2.YVelocity = -Player2.player2.YVelocity;
        //    }
        //}
    }
    class WallGenerator : Actor
    {
        //private Random _random = new Random();
        ////int count = 0;
        //public WallGenerator()
        //{
        //    OnUpdate += _wallGenerator;
        //}

        //private void _wallGenerator(int count)
        //{
        //    float XPos = _random.Next(0, Game.windowsizeX);
        //    float YPos = _random.Next(0, Game.windowsizeY);

        //    //randomly generate new astroid with random position and velocity
        //    Wall wall = new Wall(XPos, YPos);

        //    //checks if astroid will spawn on player
        //    if (wall.Hitbox.DetectCollision(Player1.player1.hitbox))
        //    {
        //        return;
        //    }

        //    else if (wall.Hitbox.DetectCollision(Player2.player2.hitbox))
        //    {
        //        return;
        //    }


           
        //    while (count < 20)
        //    {
        //        foreach (Entity e in _wallGenerator)
        //        {
                   
        //            //add astroid to root
        //            Parent.AddChild(wall);
        //            //add to the astroid list
        //            Wall.WallList.Add(wall);
        //            count++;
        //            e.Update();
        //        }
        //    }
            
        //}      
    }
}
