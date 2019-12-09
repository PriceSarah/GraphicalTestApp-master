using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Barrel : Entity
    {
        //set on tank's barrel
        public Barrel(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            Rotate((float)Math.PI);
        }

        //creates bullet and sends it in the direction the barrel is facing
        public virtual void Fire()
        {
            if (Parent is Tank)
            {
                Tank player = Parent as Tank;
                Bullet bullet = new Bullet(XAbsolute, YAbsolute, player.getPlayerNum(), "bulletSand1_outline.png");
                
                Parent.Parent.AddChild(bullet);
                bullet.SetRotate(GetRotation() + (float)Math.PI);
                bullet.XVelocity = (float)Math.Cos(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
                bullet.YVelocity = (float)Math.Sin(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
            }
        }

        //p1 barrel controls
        public virtual void p1BarrelConrols(float deltaTime)
        {
            //q
            if (Input.IsKeyDown(81))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime);
            }
            //e (nice)
            if (Input.IsKeyDown(69))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime);
            }
            //space
            if (Input.IsKeyPressed(32))
            {
                //shoot bullet
                Fire();
            }
        }

        //p2 barrel controls
        public virtual void p2BarrelConrols(float deltaTime)
        {
            //7 keypad
            if (Input.IsKeyDown(327))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime);
            }
            //9 keypad
            if (Input.IsKeyDown(329))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime);
            }
            //0 keypad
            if (Input.IsKeyPressed(320))
            {
                //shoot bullet
                Fire();
            }
        }

        //update every second
        public override void Update(float deltaTime)
        {
            
            //check if player 1
            if (this.Parent is Tank)
            {
                Tank player = this.Parent as Tank;
                if (player.getPlayerNum() == 1)
                { 
                    //bind player one's barrel controls to q and e and space
                    p1BarrelConrols(deltaTime);
                }
            }

            //check if player 2
            if (this.Parent is Tank)
            {
                Tank player = this.Parent as Tank;
                if (player.getPlayerNum() == 2)
                { 
                    //bind player two's barrel controls to 7 and 9 and 0
                    p2BarrelConrols(deltaTime);
                }
            }
            base.Update(deltaTime);
        }
    }
}
